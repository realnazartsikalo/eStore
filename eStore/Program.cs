using eStore.DB;
using eStore.Accounts;
using eStore.AppSystem;
using eStore.Terminal;
using eStore.DB.Service;
using eStore.DB.Repository;

class Program
{
    static void Main()
    {
        var terminal = new Terminal();
        terminal.Run();
    }
}