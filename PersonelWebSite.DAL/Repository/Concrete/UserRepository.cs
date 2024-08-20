using PersonalWebSite.DAL.Repository.Abstract;
using PersonalWebSite.Entities.DbContexts;
using PersonalWebSite.Entities.Models;

namespace PersonalWebSite.DAL.Repository.Concrete
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(PersonalWebContext context) : base(context)
        {
        }

    }
}
