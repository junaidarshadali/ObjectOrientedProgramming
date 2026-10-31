namespace RestaurantSystem.Admin
{
    public class AdminModel
    {
        public string UserName;
        public string Password;

        public AdminModel(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }
}