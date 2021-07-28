using ForumApp.ViewModels;
using ForumApp.ViewModels.Forum;
using ForumApp.ViewModels.Home;
using ForumApp.ViewModels.Posts;
using ForumDataLayer.Models;
using ForumDataLayer.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Linq;

namespace ForumApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPosts _postRepository;
        public HomeController(IPosts postRepository)
        {
            _postRepository = postRepository;
        }

        public IActionResult Index()
        {
            var model = HomeIndex();
            return View(model);
        }

        private HomeIndexModel HomeIndex()
        {
            var latestPosts = _postRepository.GetLatestPosts(10);
          
            var posts = latestPosts.Select(posts => new PostListViewModel
            {
                Id = posts.Id,
                Title = posts.Title,
                UserId = posts.User.Id,
                UserName = posts.User.UserName,
                UserRaiting = posts.User.Rating,
                DatePosted = posts.Created.ToString(),
                RepliesNumber=posts.Replies.Count(),
                Forum=GetForum(posts)


            });

            return new HomeIndexModel
            {
                LatestPosts = posts,
                SearchQuery=""
            };
        }

        private ForumListModel GetForum(Post posts)
        {
            var forum = posts.Forum;
            return new ForumListModel
            {
                Id = forum.Id,
                Title = forum.Title,
                Image = forum.ImageUrl,
                Description = forum.Description
            };
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
