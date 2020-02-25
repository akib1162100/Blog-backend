using BlogApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace BlogApi.Services
{
    public class PostService : IDbService<int, Blog>
    {
        public BlogContext Context;
        
        public PostService (BlogContext context)
        {
            Context=context;
        }

        public Blog Get(int id)
        {
            return Context.Blogs.Find(id);
        }
        
        public List<Blog> GetAll()
        {
            return Context.Blogs.ToList();
        }
        
        public Blog Add(Blog blog)
        {
            var result = Context.Add(blog);
            Context.SaveChanges();
            return result.Entity;
        }
        
        public Blog Update (Blog blog)
        {
            var result=Context.Update(blog);
            Context.SaveChanges();
            return result.Entity;

        }
        
        public Blog Delete (int id)
        {
            var blog = Get(id);
            var result =Context.Remove(blog);
            Context.SaveChanges();
            return result.Entity;
        }
     
    }
}