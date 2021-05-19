using ChatApi.Infrastructure.Helpers;
using ChatApi.Infrastructure.Models;
using ChatApi.Infrastructure.Repos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatApi.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
   
        public Task<IEnumerable<User>> GetUsers()
        {
            var users =  _userRepository.GetAll();
            return users;
        }

        public User AddUser(User user)
        {
            _userRepository.AddUser(user);
            return user;
        }

        public bool RemoveUser(int id)
        {
            if (_userRepository.RemoveUser(id) == true)
            {
                return true;
            }
            return false;
        }

        public async Task<User> Authenticate(string username, string password)
        {
            var user = await Task.Run(() => _userRepository.FindUser(username, password));
            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so return user details without password
            return user;
        }
    }
}