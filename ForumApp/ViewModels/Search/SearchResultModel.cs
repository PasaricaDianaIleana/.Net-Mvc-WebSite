using ForumApp.ViewModels.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumApp.ViewModels.Search
{
    public class SearchResultModel
    {
        public IEnumerable<PostListViewModel> posts { get; set; }
        public string SearchQuery { get; set; }
        public bool EmptySearchResults { get; set; }

    }
}
