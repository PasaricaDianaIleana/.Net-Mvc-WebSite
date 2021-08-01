using ForumApp.ViewModels.Posts;
using ForumApp.ViewModels.Reply;
using ForumDataLayer.Models;
using ForumDataLayer.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumApp.Controllers
{
    public class PostController : Controller
    {
        private readonly IPosts _postRepository;
        private readonly IForum _forumRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public PostController(IPosts postRepository,IForum forumRepository,UserManager<ApplicationUser> userManager)
        {
            _postRepository = postRepository;
            _forumRepository = forumRepository;
            _userManager = userManager;
        }
        public IActionResult Index(int id)
        {
            var post = _postRepository.GetById(id);
            var replies = GetReplies(post.Replies);

            var model = new PostIndexModel
            {
                Id = post.Id,
                Title = post.Title,
                UserId = post.User.Id,
                UserName = post.User.UserName,
                ImageUrl = post.User.ProfileImage,
                UserRaiting = post.User.Rating,
                Created = post.Created,
                PostContent = post.Content,
                Replies = replies,
                ForumId = post.Forum.Id,
                ForumName = post.Forum.Title,
                IsAdmin = IsAdmin(post.User)
            };
            return View(model);
        }

        private  bool IsAdmin(ApplicationUser user)
        {
            return _userManager.GetRolesAsync(user).Result.Contains("Admin");
        }

        public IActionResult CreatePost(int Id)
        {
            var forum = _forumRepository.GetById(Id);
            var model = new NewPostModel
            {

                ForumName = forum.Title,
                ForumId = forum.Id,
                FormImage = forum.ImageUrl,
                UserName = User.Identity.Name
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddPost(NewPostModel model)
        {
            var userId = _userManager.GetUserId(User);
            var user =  _userManager.FindByIdAsync(userId).Result;
            var post = CreatePost(model, user);

            _postRepository.Add(post).Wait();//Block the current thread until the post method is complete
            return RedirectToAction("Index", "Post",post.Id );
        }
        private IEnumerable<PostReplyModel> GetReplies(IEnumerable<PostReply> replies)
        {
            return replies.Select(reply => new PostReplyModel
            {
                Id = reply.Id,
                UserName = reply.User.UserName,
                UserId = reply.User.Id,
                ImageUrl = reply.User.ProfileImage,
                UserRaiting = reply.User.Rating,
                Created = reply.Created,
                ReplyContent = reply.Content,
                IsAuthorAdmin = IsAdmin(reply.User)
            }); ;
        }
        private  Post  CreatePost(NewPostModel model,ApplicationUser user)
        {
            var forum = _forumRepository.GetById(model.ForumId);
            return new Post
            {
                Title = model.ForumName,
                Content = model.Content,
                Created = DateTime.Now,
                User = user,
                Forum = forum
            };
        }
    }
}
