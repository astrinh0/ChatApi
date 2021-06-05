using ChatApi.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApi.Infrastructure.Repos
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAll();
        User AddUser(string name, string email, string username, string password);

        bool RemoveUser(int id);

        bool UserExistsAndActive(int id);

        User FindUserByUsername(string username);

        User FindUser(string username, string password);

        bool ChangePassword(int userId, string password);

        string UserName(int id);
    }
}
