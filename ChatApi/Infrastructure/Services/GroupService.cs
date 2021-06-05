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
            var groups = _groupRepository.GetAllGroups();
            return groups;
        }

        public Group AddGroupOrChannel(EnumTypeGroup type, string username, string name)
        {
            var owner = _userRepository.FindUserByUsername(username);

            if (owner != null)
            {
                var group = _groupRepository.AddGroup(type, owner.Id, name);
                return group;
            }
            
            return null;
        }



        public bool RemoveGroup(string groupName, string ownerName)
        {
            var group = _groupRepository.GetGroupByName(groupName);
            var owner = _userRepository.FindUserByUsername(ownerName);
            

           if (group != null && owner != null && group.OwnerId == owner.Id && group.Type == EnumTypeGroup.G)
           {
                _groupRepository.RemoveGroupOrChannel(group.Id);
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
                    var aux = _groupRepository.CheckIfUserBelongsToGroupOrChannel(user.Id, group.Id);

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
                    var aux = _groupRepository.CheckIfUserBelongsToGroupOrChannel(user.Id, group.Id);

                    if (aux == false)
                    {
                        var addUser = _groupRepository.RemoveUserFromGroupOrChannel(user.Id, group.Id);
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

        public bool SubscribeToChannel(string username, string channelName)
        {
            var user = _userRepository.FindUserByUsername(username);

            var channel = _groupRepository.GetChannelByName(channelName);

            if (user != null && channel != null)
            {
                return _groupRepository.SubscribeToChannel(user.Id, channel.Id);
            }

            return false;
        }

        public bool UnsubscribeToChannel(string username, string channelName)
        {
            var user = _userRepository.FindUserByUsername(username);

            var channel = _groupRepository.GetChannelByName(channelName);

            if (user != null && channel != null)
            {
                return _groupRepository.RemoveUserFromGroupOrChannel(user.Id, channel.Id);
            }

            return false;
        }

        public bool RemoveChannel(string channelName, string ownerName)
        {
            var channel = _groupRepository.GetChannelByName(channelName);
            var owner = _userRepository.FindUserByUsername(ownerName);


            if (channel != null && owner != null && channel.OwnerId == owner.Id && channel.Type == EnumTypeGroup.C)
            {
                _groupRepository.RemoveGroupOrChannel(channel.Id);
                return true;

            }

            return false;


        }

    }
}
