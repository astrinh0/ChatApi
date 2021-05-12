using ChatApi.Infrastructure.Models;
using ChatApi.Infrastructure.Repos.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatApi.Infrastructure.Services
{
    public class GroupService : IGroupService
    {

        private readonly IGroupRepository _groupRepository;

        public GroupService(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public Task<IEnumerable<Group>> GetGroups()
        {
            var groups = _groupRepository.GetAll();
            return groups;
        }

        public Group AddGroup(Group group)
        {
            _groupRepository.AddGroup(group);
            return group;
        }

        public bool RemoveGroup(int id)
        {
            if (_groupRepository.RemoveGroup(id) == true)
            {
                return true;
            }
            return false;
        }
    }
}
