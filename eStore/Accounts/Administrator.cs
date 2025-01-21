namespace eStore.Accounts
{
    public class Administrator : User
    {
        public Administrator()
        {
            Role = Roles.Administrator;
        }
    }
}