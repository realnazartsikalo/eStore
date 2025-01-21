using eStore.DB.Controller;
using eStore.DB.Service;

namespace eStore.Terminal
{
    public class OrderCommand : ICommand
    {
        private readonly OrderController _orderController;
        private readonly UserController _userController;
        
        public OrderCommand(OrderController orderController, UserController userController)
        {
            _orderController = orderController;
            _userController = userController;
        }
        
        public void Execute(string args)
        {
            switch (args)
            {
                case "create":
                    _orderController.CreateOrder(_userController.CurrentUser.Id);
                    break;
                case "view":
                    _orderController.ViewOrderHistory(_userController.CurrentUser.Id);
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
        
    }
}