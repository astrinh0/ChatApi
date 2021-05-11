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
    }
}