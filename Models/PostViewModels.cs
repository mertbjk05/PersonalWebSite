using Microsoft.AspNetCore.Mvc.ModelBinding;
using PersonalWebSite.Entities.Models;

public class PostViewModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }

    [BindNever] 
    public User Author { get; set; }
}
