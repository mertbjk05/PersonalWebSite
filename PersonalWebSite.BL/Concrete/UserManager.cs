using Microsoft.EntityFrameworkCore;
using PersonalWebSite.BL.Managers.Abstract;
using PersonalWebSite.DAL.Repository.Abstract;
using PersonalWebSite.Entities.DbContexts;
using PersonalWebSite.Entities.Models;

namespace PersonalWebSite.BL.Managers.Concrete
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _userRepository;

        private readonly PersonalWebContext _context;
        public UserManager(IUserRepository userRepository, PersonalWebContext context)
        {
            _userRepository = userRepository;
            _context = context;

        }

        public User GetUserById(int userId)
        {
            return _context.Users.Find(userId);
        }

        public void Register(User user)
        {
            
            _userRepository.Add(user);
        }

        public User Login(string email, string password)
        {
            

            return _context.Users.SingleOrDefault(u => u.Email == email && u.Password == password);
        }
    }
    
}
