using PersonalWebSite.Entities.Models.Abstract;
using System;
namespace PersonalWebSite.Entities.Models
{
    public class Post : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }


     
        public int AuthorId { get; set; }
        public User Author { get; set; }
    }
}
