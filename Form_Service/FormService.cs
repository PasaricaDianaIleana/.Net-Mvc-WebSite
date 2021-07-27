using ForumApp.Data;
using ForumDataLayer.Repository;
using ForumDataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Form_Service
{
    public class FormService : IForum
    {
        private readonly ApplicationDbContext _context;
        public FormService(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task Create(Forum forum)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int forumId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Forum> GetAll()
        {
            return _context.Forums
                .Include(x=>x.Posts);
        }

        public IEnumerable<ApplicationUser> GetAllActiveUsers()
        {
            throw new NotImplementedException();
        }

        public Forum GetById(int id)
        {
            var forumById = _context.Forums.Where(x => x.Id == id)
               .Include(p => p.Posts).ThenInclude(u => u.User)
               .Include(p => p.Posts).ThenInclude(r => r.Replies)
               .ThenInclude(u=>u.User).FirstOrDefault();
            return forumById;
        }

        public Task UpdateForumDescription(int formId, string newDescription)
        {
            throw new NotImplementedException();
        }

        public Task UpdateForumTitle(int formId, string newTitle)
        {
            throw new NotImplementedException();
        }
    }
}
