using System;
using Microsoft.VisualBasic.FileIO;
using RestaurantSystem.Drink;
using RestaurantSystem.Food;
using RestaurantSystem.Order;

namespace RestaurantSystem.Admin
{
    public class AdminUi
    {
        AdminService adminService;
        FoodUi foodUi;
        DrinkUi drinkUi;
        OrderUi orderUi;

        public AdminUi(AdminService adminService, FoodUi foodUi,
                       DrinkUi drinkUi, OrderUi orderUi)
        {
            this.adminService = adminService;
            this.foodUi = foodUi;
            this.drinkUi = drinkUi;
            this.orderUi = orderUi;
        }

        // ---------- LOGIN (3 attempts) ----------
        public void Login()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.Clear();
                Console.WriteLine("Admin Panel : login attempt " + (i + 1));
                Console.Write("Enter User Name : ");
                string userName = Console.ReadLine();
                Console.Write("Enter Password : ");
                string password = Console.ReadLine();

                if (adminService.Login(userName, password))
                {
                    Console.WriteLine("Login Successful");
                    Console.ReadKey();
                    ShowAdminPanel();
                    return;
                }

                Console.WriteLine("Wrong username or password!");
                Console.ReadKey();
            }

            Console.WriteLine("Too many failed attempts!");
            Console.ReadKey();
        }

        // ---------- ADMIN PANEL ----------
        void ShowAdminPanel()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("                   Admin Panel                        ");
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("1. Add New Food Items");
                Console.WriteLine("2. Add New Drink");
                Console.WriteLine("3. Update Food Price");
                Console.WriteLine("4. Update Drink Price");
                Console.WriteLine("5. Total Number of Orders");
                Console.WriteLine("6. Remove Food Items");
                Console.WriteLine("7. Exit");
                Console.Write("Choose an Option: ");
                int option = Convert.ToInt32(Console.ReadLine());

                if (option == 1)
                {
                    foodUi.AddFoodScreen();
                }
                else if (option == 2)
                {
                    drinkUi.AddDrinkScreen();
                }
                else if (option == 3)
                {
                    foodUi.UpdatePriceScreen();
                }
                else if (option == 4)
                {
                    drinkUi.UpdatePriceScreen();
                }
                else if (option == 5)
                {
                    orderUi.ShowAllOrders();
                }
                else if (option == 6)
                {
                    foodUi.RemoveFoodScreen();
                }
                else if (option == 7)
                {
                    Console.WriteLine("Thank You");
                    Console.ReadKey();
                    break;
                }
            }
        }
    }
}




