using ChatApi.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApi.Infrastructure.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsers();
        User AddUser(string name, string email, string username, string password);

        bool RemoveUser(int id);
        Task<User> Authenticate(string username, string password);
    }
}
