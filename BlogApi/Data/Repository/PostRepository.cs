using System.Collections.Generic;
using System.Linq;
using BlogApi.Data.Models;

namespace BlogApi.Data.Repository
{
    public class PostRepository : IRepository<int, Blog>
    {
    public BlogContext Context;
        
        public PostRepository (BlogContext context)
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