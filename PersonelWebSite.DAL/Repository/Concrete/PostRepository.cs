using PersonalWebSite.DAL.Repository.Abstract;
using PersonalWebSite.Entities.DbContexts;
using PersonalWebSite.Entities.Models;

namespace PersonalWebSite.DAL.Repository.Concrete
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(PersonalWebContext context) : base(context)
        {
        }

    }
}
