using System;
using RestaurantSystem.Food;
using RestaurantSystem.Drink;
using RestaurantSystem.Order;
using RestaurantSystem.Admin;

namespace RestaurantSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // ----- Repos (data layer, these read the files) -----
            FoodRepo foodRepo = new FoodRepo();
            DrinkRepo drinkRepo = new DrinkRepo();
            OrderRepo orderRepo = new OrderRepo();
            AdminRepo adminRepo = new AdminRepo();

            // ----- Services (logic layer) -----
            FoodService foodService = new FoodService(foodRepo);
            DrinkService drinkService = new DrinkService(drinkRepo);
            OrderService orderService = new OrderService(orderRepo);
            AdminService adminService = new AdminService(adminRepo);

            // ----- Uis (screen layer) -----
            FoodUi foodUi = new FoodUi(foodService);
            DrinkUi drinkUi = new DrinkUi(drinkService);
            OrderUi orderUi = new OrderUi(orderService, foodService, drinkService, foodUi, drinkUi);
            AdminUi adminUi = new AdminUi(adminService, foodUi, drinkUi, orderUi);

            // ----- Main Menu -----
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Restaurant Order Management System\n");
                Console.WriteLine("1. User Panel");
                Console.WriteLine("2. Admin Panel");
                Console.WriteLine("3. Exit");
                Console.Write("Choose Option: ");
                int mainOption = Convert.ToInt32(Console.ReadLine());

                if (mainOption == 1)
                {
                    Console.Clear();
                    Console.Write("Enter Your Name: ");
                    string customerName = Console.ReadLine();
                    orderUi.ShowUserPanel(customerName);
                }
                else if (mainOption == 2)
                {
                    adminUi.Login();
                }
                else if (mainOption == 3)
                {
                    break;
                }
            }
        }
    }
}