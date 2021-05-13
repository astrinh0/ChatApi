using ChatApi.Infrastructure.DB;
using ChatApi.Infrastructure.Models;
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

        public Group AddGroup(Group group)
        {

            group.CreatedAt = DateTime.UtcNow;
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
    }
}
