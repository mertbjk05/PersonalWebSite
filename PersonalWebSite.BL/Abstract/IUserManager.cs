using PersonalWebSite.Entities.Models;

namespace PersonalWebSite.BL.Managers.Abstract
{
    public interface IUserManager
    {

        User GetUserById(int userId);
        void Register(User user);
        User Login(string email, string password);
        
    }
}
