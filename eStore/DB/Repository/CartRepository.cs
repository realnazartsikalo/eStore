using eStore.DB;
using eStore.AppSystem;
using eStore.DB.Repository.Interfaces;

namespace eStore.DB.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly DbContext _context;

        public CartRepository(DbContext context)
        {
            _context = context;
        }

        public void AddToCart(int userId, Product product, int quantity)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);
            if (user == null)
            {
                throw new InvalidOperationException("User not found.");
            }

            if (user.Cart.Products.ContainsKey(product))
            {
                user.Cart.Products[product] += quantity;
            }
            else
            {
                user.Cart.Products.Add(product, quantity);
            }
        }

        public Cart GetCartByUserId(int userId)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);
            return user.Cart;
        }

        public void ClearCart(int userId)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);
            if (user != null)
            {
                user.Cart.ClearCart();
            }
        }
    }
}