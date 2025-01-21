using eStore.Accounts;

namespace eStore.AppSystem
{
    public class Order
    {
        public int Id { get; set; }
        public User User { get; set; } 
        public DateTime OrderDate { get; set; }
        public Dictionary<int, int> Products { get; set; }
    }
}