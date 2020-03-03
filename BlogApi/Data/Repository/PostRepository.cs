using System.Collections.Generic;
using System.Linq;
using BlogApi.Data.Models;
using BlogApi.Data;

namespace BlogApi.Data.Repository
{
    public class PostRepository : IPostRepository<int, Blog>
    {
        private readonly BlogContext _context;
        public PostRepository (BlogContext context)
        {
            _context=context;
        }
        public Blog Get(int id)
        {
            return _context.Blogs.Find(id);
        }        
        public List<Blog> GetAll()
        {
            return _context.Blogs.ToList();
        }
        public int Add(Blog blog)
        {
            _context.Add(blog);
            int status= _context.SaveChanges();
            if(status==1)
            {
                return blog.Id;
            }
            else
            {
                return 0;
            }
        }    
        public DbResponse Update (int blogId)
        {
            Blog findBlog =Get(blogId);
            if (findBlog == null)
            {
                return DbResponse.NotFound;
            }
            _context.Blogs.Update(findBlog);
            var status = _context.SaveChanges();
            return (status == 1) ? DbResponse.Updated : DbResponse.NotModified;
        }
        
        public DbResponse Delete (int id)
        {
            var blog = Get(id);
            if(blog==null)
            {
                return DbResponse.NotFound;
            }
            _context.Remove(blog);
            var status= _context.SaveChanges();
            return (status == 1) ? DbResponse.Deleted : DbResponse.NotModified;
        }
    }

}