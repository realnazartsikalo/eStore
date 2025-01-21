using eStore.DB.Service.Interfaces;
using eStore.AppSystem;

namespace eStore.DB.Controller
{
    public class ProductController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public void ListAllProducts()
        {
            try
            {
                var products = _productService.GetAllProducts();
                if (products != null)
                {
                    foreach (var product in products)
                    {
                        Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price}, Quantity: {product.Quantity}");
                    }
                }
                else
                {
                    Console.WriteLine("No products available.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void AddNewProduct()
        {
            Console.WriteLine("Enter product name:");
            var name = Console.ReadLine();
            Console.WriteLine("Enter product price:");
            if (!decimal.TryParse(Console.ReadLine(), out decimal price) || price < 0)
            {
                Console.WriteLine("Invalid price. Please enter a valid number.");
                return;
            }
            Console.WriteLine("Enter product quantity:");
            if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity < 0)
            {
                Console.WriteLine("Invalid quantity. Please enter a valid number.");
                return;
            }

            var newProduct = new Product { Name = name, Price = price, Quantity = quantity };
            try
            {
                _productService.AddProduct(newProduct);
                Console.WriteLine("Product added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void UpdateProduct()
        {
            Console.WriteLine("Enter product ID:");
            if (!int.TryParse(Console.ReadLine(), out int productId))
            {
                Console.WriteLine("Invalid product ID. Please enter a valid number.");
                return;
            }
            Console.WriteLine("Enter new product name:");
            var name = Console.ReadLine();
            Console.WriteLine("Enter new product price:");
            if (!decimal.TryParse(Console.ReadLine(), out decimal price) || price < 0)
            {
                Console.WriteLine("Invalid price. Please enter a valid number.");
                return;
            }
            Console.WriteLine("Enter new product quantity:");
            if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity < 0)
            {
                Console.WriteLine("Invalid quantity. Please enter a valid number.");
                return;
            }

            var updatedProduct = new Product { Id = productId, Name = name, Price = price, Quantity = quantity };
            try
            {
                _productService.UpdateProduct(updatedProduct);
                Console.WriteLine("Product updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void DeleteProduct()
        {
            Console.WriteLine("Enter product ID:");
            if (!int.TryParse(Console.ReadLine(), out int productId))
            {
                Console.WriteLine("Invalid product ID. Please enter a valid number.");
                return;
            }
            try
            {
                _productService.DeleteProduct(productId);
                Console.WriteLine("Product deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}