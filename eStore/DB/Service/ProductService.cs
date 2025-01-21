using eStore.AppSystem;
using eStore.DB.Repository.Interfaces;
using eStore.DB.Service.Interfaces;

namespace eStore.DB.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product GetProductById(int productId)
        {
            var product = _productRepository.GetProductById(productId);
            if (product == null)
            {
                throw new InvalidOperationException("Product not found.");
            }

            return product;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }

        public void AddProduct(Product newProduct)
        {
            if (newProduct == null)
            {
                throw new ArgumentNullException(nameof(newProduct));
            }

            _productRepository.AddProduct(newProduct);
        }

        public void UpdateProduct(Product updatedProduct)
        {
            if (updatedProduct == null)
            {
                throw new ArgumentNullException(nameof(updatedProduct));
            }

            var existingProduct = GetProductById(updatedProduct.Id);
            if (existingProduct == null)
            {
                throw new InvalidOperationException("Product not found.");
            }

            _productRepository.UpdateProduct(updatedProduct);
        }

        public void DeleteProduct(int productId)
        {
            var product = GetProductById(productId);
            if (product == null)
            {
                throw new InvalidOperationException("Product not found.");
            }

            _productRepository.DeleteProduct(productId);
        }
    }
}