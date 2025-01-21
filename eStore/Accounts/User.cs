using eStore.AppSystem;

namespace eStore.Accounts
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public decimal Balance { get; set; }
        public Cart Cart { get; set; }
        
        public Roles Role { get; set; }

        public enum Roles
        {
            Administrator,
            Customer
        }

        public User()
        {
            Cart = new Cart();
            Role = Roles.Customer;
        }
    }
}