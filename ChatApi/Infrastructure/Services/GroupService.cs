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

        public Group AddGroup(EnumTypeGroup type, string username, string name)
        {
            var owner = _userRepository.FindUserByUsername(username);

            if (owner != null)
            {
                var group = _groupRepository.AddGroup(type, owner.Id, name);
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

        public bool AddUserToGroup(string name, string owner, string userToAdd)
        {
            var ownerAux = _userRepository.FindUserByUsername(owner);

            var group = _groupRepository.GetGroupByName(name);

            if (ownerAux.Id == group.OwnerId && group != null && ownerAux != null)
            {
                var user = _userRepository.FindUserByUsername(userToAdd);

                if (user != null)
                {
                    var aux = _groupRepository.CheckIfUserBelongsToGroup(user.Id, group.Id);

                    if (aux == false)
                    {
                        var addUser = _groupRepository.AddUserToGroup(user.Id, group.Id);
                        return true;
                    }

                    return false;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool RemoveUserToGroup(string name, string owner, string userToAdd)
        {
            var ownerAux = _userRepository.FindUserByUsername(owner);

            var group = _groupRepository.GetGroupByName(name);

            if (ownerAux.Id == group.OwnerId && group != null && ownerAux != null)
            {
                var user = _userRepository.FindUserByUsername(userToAdd);

                if (user != null)
                {
                    var aux = _groupRepository.CheckIfUserBelongsToGroup(user.Id, group.Id);

                    if (aux == false)
                    {
                        var addUser = _groupRepository.RemoveUserFromGroup(user.Id, group.Id);
                        return true;
                    }

                    return false;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

    }
}
