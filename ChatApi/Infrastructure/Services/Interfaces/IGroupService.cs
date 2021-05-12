using ChatApi.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApi.Infrastructure.Services
{
    public interface IGroupService
    {
        Task<IEnumerable<Group>> GetGroups();
        Group AddGroup(Group group);
        bool RemoveGroup(int id);
    }
}
