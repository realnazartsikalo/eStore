namespace eStore.DB
{
    public class DbContext
    {
        public List<User> Users { get; set; }
        public List<Product> Products { get; set; }
        public List<Order> Orders { get; set; }

        public ShopDbContext()
        {
            // Initialize with some dummy data
            Users = new List<User>
            {
                new User { Id = 1, Username = "user", Password = "user", Balance = 100.0m },
                new Administrator { Id = 2, Username = "admin", Password = "admin", Balance = 0m },
            };
            Products = new List<Product>
            {
                new Product { Id = 1, Name = "iPhone 16", Price = 50000.0m, Quantity = 5},
                new Product { Id = 2, Name = "AirPods", Price = 7000.0m, Quantity = 10 },
                new Product { Id = 3, Name = "Lightning", Price = 1300.0m, Quantity = 50 }
            };
            Orders = new List<Order>();
        }
    }
}