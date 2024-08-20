using PersonalWebSite.Entities.Models.Abstract;
using System.Collections.Generic;

namespace PersonalWebSite.Entities.Models
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }


        public ICollection<Post> Posts { get; set; } = new List<Post>();
    }
}
