using ForumDataLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ForumDataLayer.Repository
{
    public  interface IForum
    {
        Forum GetById(int id);
        IEnumerable<Forum> GetAll();
        IEnumerable<ApplicationUser> GetAllActiveUsers();
        Task Create(Forum forum);
        Task Delete(int forumId);
        Task UpdateForumTitle(int formId, string newTitle);
        Task UpdateForumDescription(int formId, string newDescription);
    }
}
