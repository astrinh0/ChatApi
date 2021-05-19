

using ChatApi.Infrastructure.DB;
using ChatApi.Infrastructure.Helpers;
using ChatApi.Infrastructure.Models;
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
            return users.WithoutPasswords();
        }

        public User AddUser(User user)
        {
            user.CreatedAt = DateTime.UtcNow;
            _context.Users.Add(user);
            _context.SaveChanges();
            return user.WithoutPassword();
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

        public bool UserExistsAndActive (int id)
        {

            if (_context.Users.FirstOrDefault(a => a.Id == id && 
                        a.Active == Models.Enums.EnumFlag.Y) != null)
            {
                return true;
            }

            return false;
            
        }

        public User FindUser(string username, string password)
        {

            return _context.Users.FirstOrDefault(a => a.Username == username && a.Password == password
            && a.Active == Models.Enums.EnumFlag.Y).WithoutPassword();

        }
    }
}