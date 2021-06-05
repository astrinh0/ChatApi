using ChatApi.Infrastructure.Helpers;
using ChatApi.Infrastructure.Models;
using ChatApi.Infrastructure.Repos;
using System.Collections.Generic;
using System.Text;
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

        public User AddUser(string admin, string name, string email, string username, string password)
        {
            if (admin == "admin")
            {
                var passHash = ExtensionMethods.Encrypt(password);
                var user = _userRepository.AddUser(name, email, username, passHash);
                return user;
            }

            return null;
        }

        public bool RemoveUser(string actualUser, string userToRemove)
        {
            if (actualUser == userToRemove)
            {
                var user = _userRepository.FindUserByUsername(actualUser);

                if (user != null)
                {
                    var aux = _userRepository.RemoveUser(user.Id);
                    return aux;
                }

                return false;
            }
            else if (actualUser == "admin")
            {
                var user = _userRepository.FindUserByUsername(userToRemove);
                if (user != null)
                {
                    var aux = _userRepository.RemoveUser(user.Id);
                    return aux;
                }

                return false;
            }
            else
            {
                return false;
            }

           
        }

        public async Task<User> Authenticate(string username, string password)
        {
            var passHash = ExtensionMethods.Encrypt(password);
            var user = await Task.Run(() => _userRepository.FindUser(username, passHash));
            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so return user details without password


            return user;
        }

        public bool ChangePassword(string username, string password)
        {
            var user = _userRepository.FindUserByUsername(username);

            if (user != null)
            {
                var pashHash = ExtensionMethods.Encrypt(password);
                var aux = _userRepository.ChangePassword(user.Id, pashHash);
                return aux;
            }

           
            return false;
        }
    }
}