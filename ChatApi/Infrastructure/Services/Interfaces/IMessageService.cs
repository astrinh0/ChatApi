using ChatApi.Infrastructure.Data.DTO;
using ChatApi.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatApi.Infrastructure.Services
{
    public interface IMessageService
    {


        Message SendMessageToUser(string sender, string receiver, string message);

        bool RemoveMessage(int id);

        IEnumerable<MessageForJson> GetSentMessages(string username);

        IEnumerable<MessageForJson> GetReceivedMessages(string username);

        IEnumerable<MessageForJson> GetReceivedMessagesUnread(string username);

        Message SendMessageToGroup(string sender, string groupName, string message);

        Message SendMessageToChannel(string sender, string channelName, string message);

        int? GetNumberOfMessages(string username);

        Task<int?> GetNumberOfMessagesUnread(string username);

    }
}
