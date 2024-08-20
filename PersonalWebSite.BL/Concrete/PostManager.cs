using Microsoft.EntityFrameworkCore;
using PersonalWebSite.BL.Managers.Abstract;
using PersonalWebSite.DAL.Repository.Abstract;
using PersonalWebSite.Entities.DbContexts;
using PersonalWebSite.Entities.Models;
using System.Collections.Generic;

namespace PersonalWebSite.BL.Managers.Concrete
{
    public class PostManager : IPostManager
    {
        private readonly IPostRepository _postRepository;
        private readonly PersonalWebContext _context;
        public PostManager(IPostRepository postRepository, PersonalWebContext context)
        {
            _postRepository = postRepository;
            _context = context;
        }

        public void CreatePost(Post post)
        {
            _postRepository.Add(post);
            _context.SaveChanges();
        }

        public void UpdatePost(Post post)
        {
            _postRepository.Update(post);
            _context.SaveChanges();
        }

        public IEnumerable<Post> GetAllPosts()
        {
            return _postRepository.GetAll();
        }

        public Post GetPostById(int id)
        {
            return _postRepository.Get(p => p.Id == id);
        }

        public void DeletePost(int id)
        {
            var post = _postRepository.Get(p => p.Id == id);
            if (post != null)
            {
                _postRepository.Delete(post);
                _context.SaveChanges();
            }
        }
    }
}
