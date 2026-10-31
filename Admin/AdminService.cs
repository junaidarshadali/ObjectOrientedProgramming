namespace RestaurantSystem.Admin
{
    public class AdminService
    {
        AdminRepo repo;

        public AdminService(AdminRepo repo)
        {
            this.repo = repo;
        }

        public bool Login(string userName, string password)
        {
            if (repo.admin.UserName == userName && repo.admin.Password == password)
            {
                return true;
            }
            return false;
        }
    }
}