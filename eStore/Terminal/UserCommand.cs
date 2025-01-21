using System;
using eStore.DB.Controller;
using eStore.DB.Service;

namespace eStore.Terminal
{
    public class UserCommand : ICommand
    {
        private readonly UserController _userController;

        public static bool LoggedIn { get; set; }
        
        public UserCommand(UserController userController)
        {
            _userController = userController;
        }
        
        public void Execute(string args)
        {
            switch (args)
            {
                case "register":
                    _userController.Register();
                    break;
                case "login":
                    LoggedIn = _userController.Login();
                    break;
                case "logout":
                    LoggedIn = !_userController.Logout();
                    break;
                case "top_up":
                    _userController.TopUpBalance(_userController.CurrentUser.Id);
                    break;
                
                default:
                    System.Console.WriteLine("Invalid command.");
                    break;
            }
        }
    }
}