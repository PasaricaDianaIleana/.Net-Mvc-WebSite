using ForumApp.ViewModels.Forum;
using ForumApp.ViewModels.Posts;
using ForumApp.ViewModels.Search;
using ForumDataLayer.Models;
using ForumDataLayer.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumApp.Controllers
{
    public class SearchController : Controller
    {
        private readonly IPosts _postService;
        public SearchController(IPosts postService)
        {
            _postService = postService;
        }
        public IActionResult Results(string searchQuery)
        {
          
            var posts = _postService.GetPostBySearch(searchQuery);
            var results = (!string.IsNullOrEmpty(searchQuery) && !posts.Any());
            var postList = posts.Select(post => new PostListViewModel
            {
                Id = post.Id,
                UserId = post.User.Id,
                UserName = post.User.UserName,
                UserRaiting = post.User.Rating,
                Title = post.Title,
                DatePosted = post.Created.ToString(),
                RepliesNumber = post.Replies.Count(),
                Forum=ForumResults(post)
            });

            var model = new SearchResultModel
            {
                posts = postList,
                SearchQuery = searchQuery,
                EmptySearchResults = results
            };
            return View(model);
        }

        private ForumListModel ForumResults(Post post)
        {
            var forum = post.Forum;
            return new ForumListModel
            {
               Id=forum.Id,
               Image=forum.ImageUrl,
               Title=forum.Title,
               Description=forum.Description
            };
        }

        [HttpPost]
        public IActionResult Search(string searchQuery)
        {
            return RedirectToAction("Results", new { searchQuery });
        }
    }
}
