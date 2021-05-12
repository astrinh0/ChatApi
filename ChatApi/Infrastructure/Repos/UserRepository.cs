

using ChatApi.Infrastructure.DB;
using ChatApi.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatApi.Infrastructure.Repos
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task <IEnumerable<User>> GetAll()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }

        public User AddUser(User user)
        {
            user.CreatedAt = DateTime.UtcNow;
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public bool RemoveUser(int id)
        {
            var user = _context.Users.Find(id);

            if (user == null)
            {
                return false;
            }

            user.Active = Models.Enums.EnumFlag.N;
            _context.Users.Update(user);
            _context.SaveChanges();
            return true;
        }
    }
}