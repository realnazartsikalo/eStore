using eStore.DB;
using eStore.Accounts;
using eStore.AppSystem;
using eStore.DB.Repository;
using eStore.DB.Service;
using eStore.DB.Controller;

namespace eStore.Terminal
{
    public class Terminal
    {
        public void Show()
        {
            Console.WriteLine("Welcome to eStore!");
            Console.WriteLine("Type 'help' to see available commands.");
        }

        public void Run()
        {
            var dbContext = new DbContext();
            var userRepository = new UserRepository(dbContext);
            var productRepository = new ProductRepository(dbContext);
            var orderRepository = new OrderRepository(dbContext);

            var userService = new UserService(userRepository);
            var productService = new ProductService(productRepository);
            var orderService = new OrderService(orderRepository, userRepository);
            var cartService = new CartService(userRepository, productRepository);

            var userController = new UserController(userService);
            var productController = new ProductController(productService);
            var orderController = new OrderController(orderService);
            var cartController = new CartController(cartService);

            var commands = new List<ICommand>()
            {
                new UserCommand(userController),
                new ProductCommand(productController),
                new OrderCommand(orderController, userController),
                new CartCommand(cartController, userController)
            };
            try
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Welcome to eStore!");
                    Console.WriteLine("1. Login\n2. Register\n3. Exit");
                    Console.Write("Choose an option: ");
                    var input = Console.ReadLine();
                    switch (input)
                    {
                        case "1":
                            commands[0].Execute("login");
                            break;
                        case "2":
                            commands[0].Execute("register");
                            PressAnyKeyToContinue();
                            continue;
                        case "3":
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid option.");
                            PressAnyKeyToContinue();
                            continue;
                    }
                    Console.Clear();
                    if (userController.CurrentUser.Role == User.Roles.Administrator)
                    {
                        Console.WriteLine($"Welcome, {userController.CurrentUser.Username} !");
                        while (UserCommand.LoggedIn)
                        {
                            Console.Clear();
                            Console.WriteLine(
                                "1. View all products\n2. Add new product\n3. Update product\n4. Delete product\n5. Logout\n6. Exit");
                            Console.Write("Choose an option: ");
                            var input2 = Console.ReadLine();
                            switch (input2)
                            {
                                case "1":
                                    commands[1].Execute("view");
                                    PressAnyKeyToContinue();
                                    break;
                                case "2":
                                    commands[1].Execute("add");
                                    PressAnyKeyToContinue();
                                    break;
                                case "3":
                                    commands[1].Execute("update");
                                    PressAnyKeyToContinue();
                                    break;
                                case "4":
                                    commands[1].Execute("delete");
                                    PressAnyKeyToContinue();
                                    break;
                                case "5":
                                    commands[0].Execute("logout");
                                    PressAnyKeyToContinue();
                                    break;
                                case "6":
                                    Environment.Exit(0);
                                    break;
                                default:
                                    Console.WriteLine("Invalid option.");
                                    PressAnyKeyToContinue();
                                    break;
                            }
                        }
                    }
                    while (UserCommand.LoggedIn)
                    {
                        Console.Clear();
                        Console.WriteLine(
                            $"Welcome, {userController.CurrentUser.Username}! Balance: {userController.CurrentUser.Balance}");
                        Console.WriteLine(
                            "1. View all products\n2. Add item to cart\n3. View cart\n4. Create order\n5. View order history\n6. Top up balance\n7. Logout\n8. Exit");
                        Console.Write("Choose an option: ");
                        var input3 = Console.ReadLine();
                        switch (input3)
                        {
                            case "1":
                                commands[1].Execute("view");
                                PressAnyKeyToContinue();
                                break;
                            case "2":
                                commands[3].Execute("add");
                                PressAnyKeyToContinue();
                                break;
                            case "3":
                                commands[3].Execute("view");
                                PressAnyKeyToContinue();
                                break;
                            case "4":
                                commands[2].Execute("create");
                                PressAnyKeyToContinue();
                                break;
                            case "5":
                                commands[2].Execute("view");
                                PressAnyKeyToContinue();
                                break;
                            case "6":
                                commands[0].Execute("top_up");
                                PressAnyKeyToContinue();
                                break;
                            case "7":
                                commands[0].Execute("logout");
                                PressAnyKeyToContinue();
                                break;
                            case "8":
                                Environment.Exit(0);
                                break;
                            default:
                                Console.WriteLine("Invalid option.");
                                PressAnyKeyToContinue();
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void PressAnyKeyToContinue()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
