using ChatApi.Infrastructure.Models;
using ChatApi.Infrastructure.Models.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatApi.Infrastructure.Services
{
    public interface IGroupService
    {
        Task<IEnumerable<Group>> GetGroups();
        Group AddGroupOrChannel(EnumTypeGroup type, string username, string name);

        bool AddUserToGroup(string name, string owner, string userToAdd);

        bool SubscribeToChannel(string username, string channelName);

        bool UnsubscribeToChannel(string username, string channelName);

        bool RemoveUserToGroup(string name, string owner, string userToAdd);
        bool RemoveGroupOrChannel(string groupName, string ownerName);




    }
}
