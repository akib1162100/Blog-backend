using BlogApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApi.Data.Repository
{
    public class UserRepo : IUserRepo
    {
        private BlogContext _context;
        public UserRepo(BlogContext blogContext)
        {
            _context = blogContext;
        }
        public DbResponse Add(User user)
        {
            _context.Users.Add(user);
            int staus=_context.SaveChanges();
            if (staus == 1)
            {
                return DbResponse.Added;
            }
            else
                return DbResponse.Failed;
        }

        public User Get(string uid)
        {
            return _context.Users.FirstOrDefault(user=>user.UserId==uid);
        }
        public DbResponse Update(string uid)
        {
            throw new NotImplementedException();
        }
    }
}
