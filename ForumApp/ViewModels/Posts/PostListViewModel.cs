using ForumApp.ViewModels.Forum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumApp.ViewModels.Posts
{
    public class PostListViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string UserName { get; set; }
        public int UserRaiting { get; set; }
        public int UserId { get; set; }
        public string DatePosted { get; set; }
        public int RepliesNumber { get; set; }

        public  ForumListModel Forum { get; set; }
    }
}
