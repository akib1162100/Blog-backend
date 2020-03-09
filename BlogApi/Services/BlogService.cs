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
        public BlogRepository postRepository;
        public readonly IMapper _mapper;
        public BlogService (BlogRepository repository,IMapper mapper)
        {
            this.postRepository=repository;
            this._mapper=mapper;
        }
        public BlogDTO Get(int id)
        {
            Blog blog=postRepository.Get(id);
            BlogDTO blogDTO=_mapper.Map<BlogDTO>(blog);
            User user = blog.User;
            AuthorDTO author = _mapper.Map<User,AuthorDTO>(user,opt=>
            {
                opt.AfterMap((user, author)=>author.AuthorId=user.UserId);
            });
            blogDTO.Author = author;
            return blogDTO;
        }     
        public List<BlogDTO> GetAll()
        {   
            List<Blog> blogs=postRepository.GetAll();
            List<BlogDTO> blogDTOs=blogs.Select(blog=>_mapper.Map<BlogDTO>(blog)).ToList();
            return blogDTOs;
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