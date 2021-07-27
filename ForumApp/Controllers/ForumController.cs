using ForumApp.ViewModels.Forum;
using ForumDataLayer.Repository;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Topic(int id)
        {
            var forum = _repository.GetById(id);
            var posts = _postsRepository.GetPostsByForumId(id);
            
            return View();
        }
    }
}
