using BlogApi.Data.Models;
using BlogApi.Data;
using BlogApi.Data.Repository;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace BlogApi.Services
{
    public class AuthServices:IAuthService
    {
        public AuthRepository authRepository;
        public readonly IMapper _mapper;
        public AuthServices(AuthRepository repository,IMapper mapper)
        {
            this.authRepository=repository;
            this._mapper=mapper;
        }
        public DbResponse Register(UserRegistrationDTO userRegistrationDTO)
        {
            var password= userRegistrationDTO.Password;
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);
            User user=_mapper.Map<UserRegistrationDTO,User>(userRegistrationDTO,opt =>
            {
                opt.BeforeMap((userRegistrationDTO,user)=>userRegistrationDTO.Password=null);
                opt.AfterMap((userRegistrationDTO,user)=>user.PasswordHash = passwordHash);
                opt.AfterMap((userRegistrationDTO,user)=>user.PasswordSalt = passwordSalt);
            });
            // user.PasswordHash = passwordHash;
            // user.PasswordSalt = passwordSalt;
            bool userExist=authRepository.UserExists(userRegistrationDTO);
            if(userExist)
            {
                return DbResponse.Exists;
            }
            var response= authRepository.Register(user);
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

        public DbResponse Login(UserLoginDTO userLoginDTO)
        {
            var userId=userLoginDTO.UserID;
            var password=userLoginDTO.Password;

            var user = authRepository.Login(userId);
            if(user == null)
                return DbResponse.DoesNotExists; 

            if(!VerifyPassword(password, user.PasswordHash,user.PasswordSalt))
                return DbResponse.PasswordMissmach;
            
            return DbResponse.Successful;
        }
        private bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt)){ 
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password)); 
                for (int i = 0; i < computedHash.Length; i++){ 
                    if(computedHash[i] != passwordHash[i]) return false; 
                }    
            }
            return true;
        }

    }

}