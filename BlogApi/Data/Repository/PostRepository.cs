using System.Collections.Generic;
using System.Linq;
using BlogApi.Data.Models;
using BlogApi.Data;

namespace BlogApi.Data.Repository
{
    public class PostRepository : IRepository<int, Blog>
    {
        public BlogContext Context;
        public int contextSize;
        public int getContextSize()
        {
            contextSize = Context.Blogs.Count();
            return contextSize;
        }
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
        public int Add(Blog blog)
        {
            Context.Add(blog);
            int status= Context.SaveChanges();
            if(status==1)
            {
                return blog.Id;
            }
            else
            {
                return 0;
            }
        }    
        public MessageEnum Update (int blogId)
        {
            Blog findBlog =Get(blogId);
            if (findBlog == null)
            {
                return MessageEnum.NotFound;
            }
            Context.Blogs.Update(findBlog);
            var status = Context.SaveChanges();
            return (status == 1) ? MessageEnum.Updated : MessageEnum.NotModified;
        }
        
        public MessageEnum Delete (int id)
        {
            var blog = Get(id);
            if(blog==null)
            {
                return MessageEnum.NotFound;
            }
            Context.Remove(blog);
            var status= Context.SaveChanges();
            return (status == 1) ? MessageEnum.Deleted : MessageEnum.NotModified;
        }
    }

}