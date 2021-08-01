using ForumApp.ViewModels.Forum;
using ForumApp.ViewModels.Posts;
using ForumDataLayer.Models;
using ForumDataLayer.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ForumApp.Controllers
{
    public class ForumController : Controller
    {
        private readonly IForum _repository;
        private readonly IPosts _postsRepository;
        public ForumController(IForum repository,IPosts postRepository)
        {
            _repository = repository;
            _postsRepository = postRepository;
        }
        public IActionResult Index()
        {
            var forums = _repository.GetAll()
                .Select(forum => new ForumListModel
                {
                    Id = forum.Id,
                Title=forum.Title,
                Description=forum.Description
                });

            var model = new ForumIndexModel
            {
                FormLists = forums
            };
            return View(model);
        }
        public IActionResult Topic(int id,string searchQuery)
        {
            var forum = _repository.GetById(id);
            var posts = new List<Post>();
            posts = _postsRepository.GetPostBySearch(forum, searchQuery).ToList();
            var postsList = posts.Select(post => new PostListViewModel
            {
                Id=post.Id,
                UserId=post.User.Id,
                UserName=post.User.UserName,
                UserRaiting=post.User.Rating,
                Title=post.Title,
                DatePosted=post.Created.ToString("dd/MM/yyyy"),
                RepliesNumber=post.Replies.Count(),
                Forum= ForumData(post)

            });
            var model = new ForumPostList
            {
                Posts = postsList,
                Forum = ForumData(forum)
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Search(int id,string searchQuery)
        {
            return RedirectToAction("Topic", new { id, searchQuery });
        }
        private static ForumListModel ForumData(Post post)
        {
            var forum = post.Forum;
           return ForumData(forum);

        }
        private static ForumListModel ForumData(Forum forum)
        {
          
            return new ForumListModel
            {
                Id = forum.Id,
                Title = forum.Title,
                Description = forum.Description,
                Image = forum.ImageUrl
            };

        }
    }
}
