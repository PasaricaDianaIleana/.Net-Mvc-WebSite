using ForumApp.ViewModels.Forum;
using System.Collections.Generic;

namespace ForumApp.ViewModels.Posts
{
    public class ForumPostList
    {
        public ForumListModel Forum { get; set; }
        public IEnumerable<PostListViewModel> Posts { get; set; }

    }
}
