using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalWebSite.BL.Managers.Abstract;
using PersonalWebSite.Entities.Models;
using System.Security.Claims;

namespace PersonalWebSite.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        private readonly IPostManager _postManager;
        private readonly IUserManager _userManager;

        public PostController(IPostManager postManager, IUserManager userManager)
        {
            _postManager = postManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var posts = _postManager.GetAllPosts();
            return View(posts);
        }

        public IActionResult Create()
        {
            return View(new PostViewModel());
        }

        [HttpPost]
        public IActionResult Create(PostViewModel model)
        {
            
            var userIdValue = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userIdValue))
            {
                ModelState.AddModelError("", "User ID bulunamadı.");
                return View(model);
            }

            int userId = int.Parse(userIdValue);

           
            var user = _userManager.GetUserById(userId);
            if (user == null)
            {
                ModelState.AddModelError("", "User bulunamadı.");
                return View(model);
            }
            ModelState.Remove("Author");
            
            var post = new Post
            {
                Title = model.Title,
                Content = model.Content,
                AuthorId = userId,
                Author = user
            };

            if (ModelState.IsValid)
            {
                _postManager.CreatePost(post);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Details(int id)
        {
            var post = _postManager.GetPostById(id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }





        [HttpGet]
        public IActionResult Edit(int id)
        {
            var post = _postManager.GetPostById(id);
            if (post == null)
            {
                return NotFound();
            }

            var model = new PostViewModel
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                Author = post.Author 
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(int id, PostViewModel model)
        {

            ModelState.Remove("Author");
            if (ModelState.IsValid)
            {
                var post = _postManager.GetPostById(id);
                if (post == null)
                {
                    return NotFound();
                }

                post.Title = model.Title;
                post.Content = model.Content;
                

                _postManager.UpdatePost(post);

                return RedirectToAction("Details", new { id = post.Id });
            }

            return View(model);
        }



        
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var post = _postManager.GetPostById(id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _postManager.DeletePost(id);
            return RedirectToAction("Index");
        }

    }
}
