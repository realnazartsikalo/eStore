using eStore.Accounts;

namespace eStore.DB.Service.Interfaces
{
    public interface IUserService
    {
        void Register(User newUser);
        User Login(string username, string password);
        IEnumerable<User> GetAllUsers();
        void UpdateUser(User user);
        void DeleteUser(int userId);
        void TopUpBalance(int userId, decimal amount);
    }
}
