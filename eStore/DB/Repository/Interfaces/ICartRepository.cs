using eStore.AppSystem;

namespace eStore.DB.Repository.Interfaces
{
    public interface ICartRepository
    {
        Cart GetCartByUserId(int userId);
        void AddToCart(int userId, Product product, int quantity);
        void ClearCart(int userId);
    }
}