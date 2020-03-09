using AutoMapper;
using BlogApi.Data;
using BlogApi.Data.Models;
using BlogApi.Data.Repository;
using BlogApi.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;
        private readonly IMapper _mapper;
        private readonly JwtOptions _jwtOptions;

        public UserService(UserRepo userRepo,IMapper mapper, JwtOptions jwtOptions)
        {
            _userRepo = userRepo;
            _mapper = mapper;
            _jwtOptions = jwtOptions;
        }
        public (UserDTO userDTO, DbResponse response) Login(UserLoginDTO loginDTO)
        {
            User user = _userRepo.Get(loginDTO.UserId);
            if(user==null)
            {
                return (null,DbResponse.DoesnotExists);
            }
            var verify = VerifyPassword(loginDTO.PassWord, user.PasswordHash, user.PasswordSalt);
            if(!verify)
            {
                return (null,DbResponse.Failed);
            }
            UserDTO userDTO = _mapper.Map<User, UserDTO>(user, opt=>
            {
                opt.AfterMap((user, userDTO) => userDTO.JwtToken = _jwtOptions.GetToken(user));
            });
            return (userDTO, DbResponse.Success);
        }

        public DbResponse Registration(UserRegisterDTO registerDTO)
        {
            User user = _mapper.Map<User>(registerDTO);
            byte[] passWordHash, passWordSalt;
            CreatePasswordHash(registerDTO.Password, out passWordHash, out passWordSalt);
            user.PasswordHash = passWordHash;
            user.PasswordSalt = passWordSalt;
            if (_userRepo.Get(user.UserId) == null)
            {
                return _userRepo.Add(user);
            }
            else
                return DbResponse.Exists;
        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        private bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                { 
                    if (computedHash[i] != passwordHash[i]) return false; 
                }
            }
            return true; 
        }
    }
}
