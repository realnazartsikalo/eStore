using eStore.DB.Controller;
using eStore.DB.Service;

namespace eStore.Terminal
{
    public class CartCommand : ICommand
    {
        private readonly CartController _cartController;
        private readonly UserController _userController;
        
        public CartCommand(CartController cartController, UserController userController)
        {
            _cartController = cartController;
            _userController = userController;
        }

        public void Execute(string args)
        {
            switch (args)
            {
                case "add":
                    _cartController.AddToCart(_userController.CurrentUser.Id);
                    break;
                case "view":
                    _cartController.ViewCart(_userController.CurrentUser.Id);
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
    }
}