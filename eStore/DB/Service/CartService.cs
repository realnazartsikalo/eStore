using eStore.AppSystem;
using eStore.DB.Repository.Interfaces;
using eStore.DB.Service.Interfaces;

namespace eStore.DB.Service
{
    public class CartService : ICartService
    {
        private readonly IUserRepository _userRepository;
        private readonly IProductRepository _productRepository;

        public CartService(IUserRepository userRepository, IProductRepository productRepository)
        {
            _userRepository = userRepository;
            _productRepository = productRepository;
        }

        public void AddToCart(int userId, int productId, int quantity)
        {
            if (quantity <= 0)
            {
                throw new InvalidOperationException("Quantity must be greater than zero.");
            }

            var user = _userRepository.GetUserById(userId);
            if (user == null)
            {
                throw new InvalidOperationException("User not found.");
            }

            var product = _productRepository.GetProductById(productId);
            if (product == null)
            {
                throw new InvalidOperationException("Product not found.");
            }

            if (product.Quantity < quantity)
            {
                throw new InvalidOperationException("Insufficient product quantity available.");
            }

            user.Cart.AddProduct(product, quantity);
            product.Quantity -= quantity;
        }

        public Cart ViewCart(int userId)
        {
            var user = _userRepository.GetUserById(userId);
            if (user == null)
            {
                throw new InvalidOperationException("User not found.");
            }

            return user.Cart;
        }

        public void ClearCart(int userId)
        {
            var user = _userRepository.GetUserById(userId);
            if (user == null)
            {
                throw new InvalidOperationException("User not found.");
            }
            user.Cart.ClearCart();
        }

        public decimal CalculateTotal(int userId)
        {
            var user = _userRepository.GetUserById(userId);
            if (user == null)
            {
                throw new InvalidOperationException("User not found.");
            }

            return user.Cart.TotalPrice();
        }
    }
}