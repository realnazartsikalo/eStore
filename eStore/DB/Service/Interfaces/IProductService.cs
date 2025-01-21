using eStore.AppSystem;

namespace eStore.DB.Service.Interfaces
{
    public interface IProductService
    {
        Product GetProductById(int productId);
        IEnumerable<Product> GetAllProducts();
        void AddProduct(Product newProduct);
        void UpdateProduct(Product updatedProduct);
        void DeleteProduct(int productId);
    }
}
