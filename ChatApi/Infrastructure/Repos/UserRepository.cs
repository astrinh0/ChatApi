

using ChatApi.Infrastructure.DB;
using ChatApi.Infrastructure.Helpers;
using ChatApi.Infrastructure.Models;
using ChatApi.Infrastructure.Models.Enums;
using Isopoh.Cryptography.Argon2;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public User AddUser(string name, string email, string username, string password)
        {




            var user = new User
            {
                Active = EnumFlag.Y,
                ChangedAt = null,
                CreatedAt = DateTime.UtcNow,
                Name = name,
                Email = email,
                Username = username,
                Password = password,

            };

            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public bool RemoveUser(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                return false;
            }

            user.Active = EnumFlag.N;
            _context.Users.Update(user);
            _context.SaveChanges();
            return true;
        }

        public bool UserExistsAndActive (int id)
        {

            if (_context.Users.FirstOrDefault(a => a.Id == id && 
                        a.Active == EnumFlag.Y) != null)
            {
                return true;
            }

            return false;
            
        }

        public User FindUserByUsername(string username)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username && u.Active == EnumFlag.Y);
            return user;
        }

        public string UserName(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id && u.Active == EnumFlag.Y);
            return user.Username;
        }

        public User FindUser(string username, string password)
        {
            
            return _context.Users.FirstOrDefault(a => a.Username == username && a.Password == password
            && a.Active == EnumFlag.Y);

        }

        public bool ChangePassword(int userId, string password)
        {
            var user = _context.Users.FirstOrDefault(c => c.Id == userId);


            user.Password = password;

            _context.Users.Update(user);
            _context.SaveChanges();

            return true;
        }
    }
}