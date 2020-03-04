using BlogApi.Data.Models;
using BlogApi.Data;
using BlogApi.Jwt;
using BlogApi.Data.Repository;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace BlogApi.Services
{
    public class AuthServices:IAuthService
    {
        public AuthRepository _authRepository;
        public readonly IMapper _mapper;
        private readonly JwtOptions _jwtOptions;
        public AuthServices(AuthRepository repository,IMapper mapper, JwtOptions jwtOptions)
        {
            this._authRepository=repository;
            this._mapper=mapper;
            this._jwtOptions = jwtOptions;
        }
        public DbResponse Register(UserRegistrationDTO userRegistrationDTO)
        {
            var password= userRegistrationDTO.Password;
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);
            User user=_mapper.Map<UserRegistrationDTO,User>(userRegistrationDTO,opt =>
            {
                opt.BeforeMap((userRegistrationDTO,user)=>userRegistrationDTO.Password=null);
            });
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            bool userExist=_authRepository.UserExists(userRegistrationDTO);
            if(userExist)
            {
                return DbResponse.Exists;
            }
            var response= _authRepository.Register(user);
            return response;
        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public (UserDTO userDTO,DbResponse response) Login(UserLoginDTO userLoginDTO)
        {
            var userId=userLoginDTO.UserID;
            var password=userLoginDTO.Password;
            var user = _authRepository.Login(userId);
            if(user == null)
                return (null,DbResponse.DoesNotExists); 
            
            var userDTO = _mapper.Map<User, UserDTO>(user, opt=>
            {
                opt.AfterMap((user, userDTO) => userDTO.JwtToken = _jwtOptions.GetToken(user));
            }); 

            if(!VerifyPassword(password,user.PasswordHash,user.PasswordSalt))
                return (null,DbResponse.PasswordMissmach);
            return (userDTO, DbResponse.Successful);
        }
        private bool VerifyPassword(string password,byte[] passwordHash, byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt)){ 
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password)); 
                for (int i = 0; i < computedHash.Length; i++){ 
                    if(computedHash[i] != passwordHash[i])
                        return false; 
                }    
            }
            return true;
        }

    }

}