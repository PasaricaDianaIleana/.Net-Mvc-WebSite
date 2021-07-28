﻿using ForumApp.ViewModels.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumApp.ViewModels.Home
{
    public class HomeIndexModel
    {
        public IEnumerable<PostListViewModel> LatestPosts { get; set; }
        public string SearchQuery { get; set; }
    }
}
