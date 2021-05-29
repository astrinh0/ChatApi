using ChatApi.Infrastructure.DB;
using ChatApi.Infrastructure.Models;
using ChatApi.Infrastructure.Models.Enums;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApi.Infrastructure.Repos
{
    public class GroupRepository : IGroupRepository
    {
        private readonly DataContext _context;

        public GroupRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Group>> GetAll()
        {
            var group = await _context.Groups.ToListAsync();
            return group;
        }

        public Group AddGroup(EnumTypeGroup type, int ownerId)
        {
            var group = new Group
            {
                Type = type,
                OwnerId = ownerId,
                CreatedAt = DateTime.UtcNow,
                Active = EnumFlag.Y
            };
            

            _context.Groups.Add(group);
            _context.SaveChanges();

            return group;
        }

        public bool RemoveGroup(int id)
        {
            var group = _context.Groups.Find(id);

            if (group == null)
            {
                return false;
            }

            group.Active = Models.Enums.EnumFlag.N;
            _context.Groups.Update(group);
            _context.SaveChanges();
            return true;
        }

        public Group GetGroup(int groupId)
        {
            var group = _context.Groups.FirstOrDefault(g => g.Id == groupId);


            if (group != null)
            {
                return group;
            }

            return null;
        }

        public bool CheckIfUserBelongsToGroup(int userId, int groupId)
        {
            var aux = _context.GroupUsers.FirstOrDefault(gu => gu.UserId == userId && gu.GroupId == groupId);
            if (aux != null)
            {
                return true;
            }

            return false;
        }
    }
}
