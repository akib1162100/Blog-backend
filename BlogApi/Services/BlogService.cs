using BlogApi.Data.Models;
using BlogApi.Data.Repository;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace BlogApi.Services
{
    public class BlogService : IBlogService
    {
        public PostRepository postRepository;
        public readonly IMapper _mapper;
        public BlogService (PostRepository repository,IMapper mapper)
        {
            this.postRepository=repository;
            this._mapper=mapper;
        }
        public BlogDTO Get(int id)
        {
            Blog blog=postRepository.Get(id);
            BlogDTO blogDTO=_mapper.Map<BlogDTO>(blog);
            return blogDTO;
        }
        
        public List<BlogDTO> GetAll()
        {   
            List<Blog> blogs=postRepository.GetAll();
            List<BlogDTO> blogDTOs=blogs.Select(blog=>_mapper.Map<BlogDTO>(blog)).ToList();
            return blogDTOs;

        }  
        public int Update (BlogDTO blogDTO)
        {
            Blog blog = _mapper.Map<Blog>(blogDTO);
            int statusCount=postRepository.Update(blog);
            if(statusCount != 0)
            {
                if(blogDTO.Id>statusCount)
                {
                    return 2;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                return 0;
            }

        }
        public BlogDTO Add(BlogDTO blogDTO)
        {
            Blog blog=_mapper.Map<BlogDTO,Blog>(blogDTO,opt =>
            {
                opt.BeforeMap((blogDTO,blog)=>blogDTO.Id=null);
            });
            int receivedId=postRepository.Add(blog);
            if(receivedId!=0)
            {
                blogDTO.Id = receivedId;
                return blogDTO;
            }
            else
            {
                return null;
            }


        }
    }
}