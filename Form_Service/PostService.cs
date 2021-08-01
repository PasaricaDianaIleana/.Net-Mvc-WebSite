using ForumApp.Data;
using ForumDataLayer.Models;
using ForumDataLayer.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Form_Service
{
    public class PostService : IPosts
    {
        private readonly ApplicationDbContext _context;
        public PostService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Add(Post post)
        {
            _context.Add(post);
            await _context.SaveChangesAsync();
        }

        public Task AddReply(PostReply reply)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task Edit(int id, string text)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetAll()
        {
            return _context.Posts
                .Include(post=>post.User)
                .Include(post=>post.Replies).ThenInclude(reply=>reply.User)
                .Include(post=>post.Forum);
        }

        public Post GetById(int id)
        {
            return _context.Posts.Where(x => x.Id == id)
                  .Include(u => u.User)
                  .Include(p => p.Replies)
                  .ThenInclude(u=>u.User)
                  .Include(f => f.Forum).FirstOrDefault();
        }

        public IEnumerable<Post> GetLatestPosts(int number)
        {
          return  GetAll().OrderByDescending(p => p.Created).Take(number);
        }

        public IEnumerable<Post> GetPostBySearch(Forum forum,string searchQuery)
        {
          
            return String.IsNullOrEmpty(searchQuery)? forum.Posts :
                forum.Posts.Where(x => x.Title.Contains(searchQuery) || x.Content.Contains(searchQuery));
        }

        public IEnumerable<Post> GetPostsByForumId(int id)
        {
            return _context.Forums.Where(x => x.Id == id).FirstOrDefault().Posts;
        }
    }
}
