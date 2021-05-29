﻿using ChatApi.Infrastructure.Models;
using ChatApi.Infrastructure.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApi.Infrastructure.Services
{
    public interface IGroupService
    {
        Task<IEnumerable<Group>> GetGroups();
        Group AddGroup(EnumTypeGroup type, string username);
        bool RemoveGroup(int id);
    }
}
