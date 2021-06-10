using ChatApi.Infrastructure.Models;
using ChatApi.Infrastructure.Models.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatApi.Infrastructure.Repos
{
    public interface IGroupRepository
    {
        List<Group> GetAllGroups();
        Group AddGroup(EnumTypeGroup type, int ownerId, string name);
        bool RemoveGroupOrChannel(int id);

        Group GetGroup(int groupId);

        Group GetGroupByName(string groupName);

        bool CheckIfUserBelongsToGroupOrChannel(int userId, int groupId);

        bool AddUserToGroup(int userId, int groupId);

        bool RemoveUserFromGroupOrChannel(int userId, int groupId);

        Group GetChannelByName(string channelName);
        Group GetChannel(int channelId);
        bool SubscribeToChannel(int userId, int channelId);

    }
}
