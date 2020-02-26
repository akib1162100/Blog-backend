using BlogApi.Data.Models;
using BlogApi.Data.Repository;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace BlogApi.Services
{
    public class PostService : IPostService<int,Blog>
    {
        public PostRepository postRepository;
        public readonly IMapper _mapper;
        public PostService (PostRepository repository,IMapper mapper)
        {
            this.postRepository=repository;
            this._mapper=mapper;
        }

        public Blog Get(int id)
        {
            return postRepository.Get(id);
        }
        
        public List<Blog> GetAll()
        {
            return postRepository.GetAll();
        }  
        public Blog Update (Blog blog)
        {
            return postRepository.Update(blog);
        }
        
        public Blog Delete (int id)
        {
            return postRepository.Delete(id);
        }

        public bool Add(BlogDTO blogDTO)
        {
            Blog blog=_mapper.Map<Blog>(blogDTO);
            int status=postRepository.Add(blog);
            return status==1 ;
        }
    }
}