using ChatApi.Infrastructure.Data.Models;
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

        public async Task<IEnumerable<Group>> GetAllGroups()
        {
            var group = await _context.Groups.Where(g => g.Type == EnumTypeGroup.G).ToListAsync();
            return group;
        }

        public Group AddGroup(EnumTypeGroup type, int ownerId, string name)
        {
            var group = new Group
            {
                Type = type,
                Name = name,
                OwnerId = ownerId,
                CreatedAt = DateTime.UtcNow,
                Active = EnumFlag.Y
            };
            

            _context.Groups.Add(group);
            _context.SaveChanges();

            return group;
        }

        public bool RemoveGroupOrChannel(int id)
        {
            var group = _context.Groups.Find(id);

            if (group == null)
            {
                return false;
            }

            group.Active = EnumFlag.N;
            _context.Groups.Update(group);
            _context.SaveChanges();
            return true;
        }

        


        public Group GetGroup(int groupId)
        {
            var group = _context.Groups.FirstOrDefault(g => g.Id == groupId && g.Type == EnumTypeGroup.G);


            if (group != null)
            {
                return group;
            }

            return null;
        }

        public Group GetGroupByName(string groupName)
        {
            var group = _context.Groups.FirstOrDefault(g => g.Name == groupName && g.Type == EnumTypeGroup.G);


            if (group != null)
            {
                return group;
            }

            return null;
        }

        public bool CheckIfUserBelongsToGroupOrChannel(int userId, int groupId)
        {
            var aux = _context.GroupUsers.FirstOrDefault(gu => gu.UserId == userId && gu.GroupId == groupId);
            if (aux != null)
            {
                return true;
            }

            return false;
        }

        public bool AddUserToGroup(int userId, int groupId)
        {

            var groupUsers = new GroupUser
            {
                GroupId = groupId,
                UserId = userId,
                CreatedAt = DateTime.UtcNow
            };

            _context.GroupUsers.Add(groupUsers);
            _context.SaveChanges();

            return true;
        }

        public bool RemoveUserFromGroupOrChannel(int userId, int groupId)
        {

            var groupUsers = _context.GroupUsers.FirstOrDefault(gu => gu.UserId == userId && gu.GroupId == groupId);

            _context.GroupUsers.Remove(groupUsers);
            _context.SaveChanges();
            

            return true;
        }

        public Group GetChannel(int channelId)
        {
            var group = _context.Groups.FirstOrDefault(g => g.Id == channelId && g.Type == EnumTypeGroup.C);


            if (group != null)
            {
                return group;
            }

            return null;
        }

        public Group GetChannelByName(string channelName)
        {
            var group = _context.Groups.FirstOrDefault(g => g.Name == channelName && g.Type == EnumTypeGroup.C);


            if (group != null)
            {
                return group;
            }

            return null;
        }

        public bool SubscribeToChannel(int userId, int channelId)
        {

            var groupUsers = new GroupUser
            {
                GroupId = channelId,
                UserId = userId,
                CreatedAt = DateTime.UtcNow
            };

            _context.GroupUsers.Add(groupUsers);
            _context.SaveChanges();

            return true;
        }

    }
}
