using eStore.Accounts;

namespace eStore.DB.Repository.Interfaces
{
    public interface IUserRepository
    {
        User GetUserById(int userId);
        User GetUserByUsername(string username);
        IEnumerable<User> GetAllUsers();
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int userId);
    }
}