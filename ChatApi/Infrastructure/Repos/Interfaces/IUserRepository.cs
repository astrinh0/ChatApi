using ChatApi.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApi.Infrastructure.Repos
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAll();
        User AddUser(User user);

        Task<bool> RemoveUser(int id);
    }
}
