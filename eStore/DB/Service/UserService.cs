using eStore.Accounts;
using eStore.DB.Repository.Interfaces;
using eStore.DB.Service.Interfaces;

namespace eStore.DB.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Register(User newUser)
        {
            if (newUser == null)
            {
                throw new ArgumentNullException(nameof(newUser));
            }

            var existingUser = _userRepository.GetUserByUsername(newUser.Username);
            if (existingUser != null)
            {
                throw new InvalidOperationException("Username already exists.");
            }

            _userRepository.AddUser(newUser);
        }

        public User Login(string username, string password)
        {
            var user = _userRepository.GetUserByUsername(username);
            if (user != null &&
                user.Password == password)
            {
                return user;
            }

            return null;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public void UpdateUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var existingUser = _userRepository.GetUserById(user.Id);
            if (existingUser == null)
            {
                throw new InvalidOperationException("User not found.");
            }
            _userRepository.UpdateUser(user);
        }

        public void DeleteUser(int userId)
        {
            var user = _userRepository.GetUserById(userId);
            if (user == null)
            {
                throw new InvalidOperationException("User not found.");
            }
            _userRepository.DeleteUser(userId);
        }

        public void TopUpBalance(int userId, decimal amount)
        {
            var user = _userRepository.GetUserById(userId);
            if (user == null)
            {
                throw new InvalidOperationException("User not found.");
            }
            user.Balance += amount;
        }
    }
}