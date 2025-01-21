using eStore.DB.Controller;
using eStore.DB.Service;

namespace eStore.Terminal
{
     public class ProductCommand : ICommand
    {
        private readonly ProductController _productController;
        
        public ProductCommand(ProductController productController)
        {
            _productController = productController;
        }
        
        public void Execute(string args)
        {
            switch (args)
            {
                case "add":
                    _productController.AddNewProduct();
                    break;
                case "view":
                    _productController.ListAllProducts();
                    break;
                case "update":
                    _productController.UpdateProduct();
                    break;
                case "delete":
                    _productController.DeleteProduct();
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
    }
}