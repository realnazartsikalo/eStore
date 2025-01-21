using eStore.DB;
using eStore.AppSystem;
using eStore.DB.Repository.Interfaces;

namespace eStore.DB.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DbContext _context;

        public ProductRepository(DbContext context)
        {
            _context = context;
        }

        public Product GetProductById(int productId)
        {
            return _context.Products.FirstOrDefault(p => p.Id == productId);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public void AddProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            product.Id = _context.Products.Count + 1;
            _context.Products.Add(product);
        }

        public void UpdateProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            var existingProduct = GetProductById(product.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
                existingProduct.Quantity = product.Quantity;
            }
            else
            {
                throw new InvalidOperationException($"Product with ID {product.Id} not found.");
            }
        }

        public void DeleteProduct(int productId)
        {
            var product = GetProductById(productId);
            if (product != null)
            {
                _context.Products.Remove(product);
            }
            else
            {
                throw new InvalidOperationException($"Product with ID {productId} not found.");
            }
        }
    }
}