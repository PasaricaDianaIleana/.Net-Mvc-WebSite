using ForumDataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumDataLayer.Repository
{
   public interface IPosts
    {
        Post GetById(int id);
       IEnumerable<Post> GetPostsByForumId(int id);
        IEnumerable<Post> GetAll();
        IEnumerable<Post> GetPostBySearch(Forum forum,string searchQuery);
        Task Add(Post post);
        Task Delete(int id);
        Task Edit(int id, string text);
        Task AddReply(PostReply reply);
        IEnumerable<Post> GetLatestPosts(int number);
    }
}
