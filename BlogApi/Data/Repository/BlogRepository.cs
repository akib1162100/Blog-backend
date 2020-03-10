using System.Collections.Generic;
using System.Linq;
using BlogApi.Data.Models;
using BlogApi.Data;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Data.Repository
{
    public class BlogRepository : IRepository
    {
        private readonly BlogContext _context;
        public BlogRepository (BlogContext context)
        {
            _context=context;
        }
        public Blog Get(int id)
        {
            var blog = _context.Blogs.Include(blog => blog.User).FirstOrDefault(blog => blog.Id == id);
            return blog;
        }        
        public List<Blog> GetAll()
        {
            List<Blog>blogs= _context.Blogs.Include(blog => blog.User).ToList();

            return blogs;
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
        public DbResponse Update (BlogDTO blogDTO,string userId)
        {
            Blog findBlog = _context.Blogs.FirstOrDefault(b => b.Id == blogDTO.Id); 
            if(findBlog.UserId!=userId)
            {
                return DbResponse.NotAllowed;
            } 
            if (findBlog == null)
            {
                return DbResponse.NotFound;
            }
            findBlog.Title = blogDTO.Title;
            findBlog.Body = blogDTO.Body;
            findBlog.PublishedDate = blogDTO.PublishedDate;
            var status = _context.SaveChanges();
            return (status == 1) ? DbResponse.Updated : DbResponse.NotModified;
        }  
        public DbResponse Delete (int id, string userId)
        {
            var blog = Get(id);
            if(blog==null)
            {
                return DbResponse.NotFound;
            }
            if(blog.UserId!=userId)
            {
                return DbResponse.NotAllowed;
            }
            _context.Remove(blog);
            var status= _context.SaveChanges();
            return (status == 1) ? DbResponse.Deleted : DbResponse.NotModified;
        }
    }

}