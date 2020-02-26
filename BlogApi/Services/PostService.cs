using BlogApi.Data.Models;
using BlogApi.Data.Repository;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace BlogApi.Services
{
    public class PostService : IDbService<int, Blog>
    {
        // public BlogContext Context;
        public PostRepository postRepository;

        
        
        public PostService (PostRepository repository)
        {
            postRepository=repository;
        }


        public Blog Get(int id)
        {
            return postRepository.Get(id);
        }
        
        public List<Blog> GetAll()
        {
            return postRepository.GetAll();
        }
        
        public Blog Add(BlogDTO blogDTO)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<BlogDTO, Blog>());
            var mappre=new Mapper(config);
            Blog blog=mappre.Map<Blog>(blogDTO);
            return postRepository.Add(blog);

        }
        
        public Blog Update (Blog blog)
        {
            return postRepository.Update(blog);

        }
        
        public Blog Delete (int id)
        {
            return postRepository.Delete(id);
        }
     
    }
}