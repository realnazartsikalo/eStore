using eStore.AppSystem;
using eStore.DB.Repository;

namespace eStore.DB.Service.Interfaces
{
     public interface ICartService
    {
        void AddToCart(int userId, int productId, int quantity);
        Cart ViewCart(int userId);
        void ClearCart(int userId);
        decimal CalculateTotal(int userId);
    }
}