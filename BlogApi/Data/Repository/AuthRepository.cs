using System.Linq;
using BlogApi.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Data.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly BlogContext _context;
        public AuthRepository (BlogContext context)
        {
            _context=context;
        }
        public User Login(string userId)
        {
            var user = _context.Users.Find(userId);
            if(user == null)
                return null; 
            return user;
        }
        public DbResponse Register(User user)
        {
            _context.Users.Add(user);
            var status = _context.SaveChanges();
            return(status==1)? DbResponse.Added:DbResponse.Failed; 
        }
        public bool UserExists(UserRegistrationDTO userRegistrationDTO)
        {
            var userId =userRegistrationDTO.UserID;
            if(_context.Users.Any(x => x.UserID == userId))
            {
                return true;
            }
            return false;
        }
    }
}