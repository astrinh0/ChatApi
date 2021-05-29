using ChatApi.Infrastructure.Models;
using ChatApi.Infrastructure.Models.Enums;
using ChatApi.Infrastructure.Repos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatApi.Infrastructure.Services
{
    public class GroupService : IGroupService
    {

        private readonly IGroupRepository _groupRepository;
        private readonly IUserRepository _userRepository;

        public GroupService(IGroupRepository groupRepository, IUserRepository userRepository)
        {
            _groupRepository = groupRepository;
            _userRepository = userRepository;
        }


        public Task<IEnumerable<Group>> GetGroups()
        {
            var groups = _groupRepository.GetAll();
            return groups;
        }

        public Group AddGroup(EnumTypeGroup type, string username)
        {
            var owner = _userRepository.FindUserByUsername(username);

            if (owner != null)
            {
                var group = _groupRepository.AddGroup(type, owner.Id);
                return group;
            }
            
            return null;
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
