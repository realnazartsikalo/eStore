using eStore.DB.Service.Interfaces;
using eStore.Accounts;

namespace eStore.DB.Controller
{
    public class UserController
    {
        private readonly IUserService _userService;
        public User CurrentUser { get; set; }
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public void Register()
        {
            Console.WriteLine("Enter username:");
            var username = Console.ReadLine();
            Console.WriteLine("Enter password:");
            var password = Console.ReadLine();

            var newUser = new User { Username = username, Password = password };
            try
            {
                _userService.Register(newUser);
                Console.WriteLine("Registration successful.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public bool Login()
        {
            Console.WriteLine("Enter username:");
            var username = Console.ReadLine();
            Console.WriteLine("Enter password:");
            var password = Console.ReadLine();

            var user = _userService.Login(username, password);
            if (user != null)
            {
                CurrentUser = user;
                Console.WriteLine($"User {user.Username} logged in successfully.");
                return true;
            }
            else
            {
                Console.WriteLine("Invalid username or password.");
                return false;
            }
        }
        
        public bool Logout()
        {
            if (CurrentUser != null)
            {
                Console.WriteLine($"User {CurrentUser.Username} logged out successfully.");
                CurrentUser = null;
                return true;
            }
            else
            {
                Console.WriteLine("No user currently logged in.");
                return false;
            }
        }

        public void UpdateUser(User user)
        {
            try
            {
                _userService.UpdateUser(user);
                Console.WriteLine("User updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void DeleteUser(int userId)
        {
            try
            {
                _userService.DeleteUser(userId);
                Console.WriteLine("User deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        
        public void TopUpBalance(int userId)
        {
            Console.WriteLine("Enter amount to top up:");
            if (!decimal.TryParse(Console.ReadLine(), out decimal amount) || amount < 0)
            {
                Console.WriteLine("Invalid amount. Please enter a positive number.");
                return;
            }
            try
            {
                _userService.TopUpBalance(userId, amount);
                Console.WriteLine("Balance topped up successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}