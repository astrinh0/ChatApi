using ChatApi.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApi.Infrastructure.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsers();
        User AddUser(User user);
    }
}
