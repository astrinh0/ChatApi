﻿using ChatApi.Infrastructure.Models;
using ChatApi.Infrastructure.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApi.Infrastructure.Repos
{
    public interface IGroupRepository
    {
        Task<IEnumerable<Group>> GetAll();
        Group AddGroup(EnumTypeGroup type, int ownerId);
        bool RemoveGroup(int id);

        Group GetGroup(int groupId);

        bool CheckIfUserBelongsToGroup(int userId, int groupId);

    }
}
