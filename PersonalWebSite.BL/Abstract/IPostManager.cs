using PersonalWebSite.Entities.Models;
using System.Collections.Generic;

namespace PersonalWebSite.BL.Managers.Abstract
{
    public interface IPostManager
    {
        void CreatePost(Post post);
        void DeletePost(int id);
        void UpdatePost(Post post);
        IEnumerable<Post> GetAllPosts();
        Post GetPostById(int id);
    }
}
