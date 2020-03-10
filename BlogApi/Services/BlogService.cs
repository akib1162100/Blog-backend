using BlogApi.Data.Models;
using BlogApi.Data;
using BlogApi.Data.Repository;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace BlogApi.Services
{
    public class BlogService : IBlogService
    {
        public IRepository postRepository;
        public readonly IMapper _mapper;
        public BlogService (IRepository repository,IMapper mapper)
        {
            this.postRepository=repository;
            this._mapper=mapper;
        }
        public BlogDTO Get(int id)
        {
            Blog blog=postRepository.Get(id);
            BlogDTO blogDTO=_mapper.Map<BlogDTO>(blog);
            blogDTO.Author = GetMapper(blog.User);
            return blogDTO;
        }     
        public List<BlogDTO> GetAll()
        {   
            List<Blog> blogs=postRepository.GetAll();
            BlogDTO blogDTO;
            List<BlogDTO> blogDTOs=blogs.Select(blog=>blogDTO=_mapper.Map<Blog,BlogDTO>(blog,opt=>
            {
                opt.AfterMap((blog, blogDTO)=>blogDTO.Author=GetMapper(blog.User));
            })).ToList();
            return blogDTOs;
        }  
        public AuthorDTO GetMapper(User user)
        {
            AuthorDTO author = _mapper.Map<User, AuthorDTO>(user, opt =>
            {
                opt.AfterMap((user, author) => author.AuthorId = user.UserId);
            });
            return author;
        }
        public DbResponse Update (BlogDTO blogDTO,string userId)
        {
            if(userId==null)
            {
                return DbResponse.DoesnotExists;
            }
            DbResponse messageEnum=postRepository.Update(blogDTO,userId);
            return messageEnum;
        }
        public (BlogDTO blogDTO,DbResponse response) Add(BlogDTO blogDTO, string userId)
        {
            if (userId == null)
            {
                return (null,DbResponse.DoesnotExists);
            }
            Blog blog=_mapper.Map<BlogDTO,Blog>(blogDTO,opt =>
            {
                opt.BeforeMap((blogDTO,blog)=>blogDTO.Id=null);
            });
            blog.UserId = userId;
            int receivedId=postRepository.Add(blog);
            if(receivedId!=0)
            {
                blogDTO.Id = receivedId;
                return (blogDTO,DbResponse.Added);
            }
            else
            {
                return (null,DbResponse.Failed);
            }
        }
        public DbResponse Delete(int blogId, string userId)
        {
            if (userId == null)
            {
                return DbResponse.DoesnotExists;
            }
            var messageEnum = postRepository.Delete(blogId, userId);
            return messageEnum;
        }
    }
}