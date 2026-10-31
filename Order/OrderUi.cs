using System;
using System.Collections.Generic;
using RestaurantSystem.Food;
using RestaurantSystem.Drink;

namespace RestaurantSystem.Order
{
    public class OrderUi
    {
        OrderService orderService;
        FoodService foodService;
        DrinkService drinkService;
        FoodUi foodUi;
        DrinkUi drinkUi;

        public OrderUi(OrderService orderService, FoodService foodService,
                       DrinkService drinkService, FoodUi foodUi, DrinkUi drinkUi)
        {
            this.orderService = orderService;
            this.foodService = foodService;
            this.drinkService = drinkService;
            this.foodUi = foodUi;
            this.drinkUi = drinkUi;
        }

        // ---------- USER PANEL ----------
        public void ShowUserPanel(string customerName)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine("                   User Panel                       ");
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine("1. View Full Menu");
                Console.WriteLine("2. Order Food");
                Console.WriteLine("3. Order Drinks");
                Console.WriteLine("4. View Current Order");
                Console.WriteLine("5. Total Bill");
                Console.WriteLine("6. Exit");
                Console.Write("Choose Option: ");
                int option = Convert.ToInt32(Console.ReadLine());

                if (option == 1)
                {
                    Console.Clear();
                    foodUi.ShowMenu();
                    drinkUi.ShowMenu();
                    Console.WriteLine("\nPress any key to go back...");
                    Console.ReadKey();
                }
                else if (option == 2)
                {
                    OrderFoodScreen(customerName);
                }
                else if (option == 3)
                {
                    OrderDrinkScreen(customerName);
                }
                else if (option == 4)
                {
                    ViewCurrentOrder(customerName);
                }
                else if (option == 5)
                {
                    ShowBill(customerName);
                }
                else if (option == 6)
                {
                    Console.WriteLine("\nThank you, " + customerName);
                    Console.ReadKey();
                    break;
                }
            }
        }

        // ---------- ORDER FOOD ----------
        void OrderFoodScreen(string customerName)
        {
            while (true)
            {
                Console.Clear();
                foodUi.ShowMenu();

                Console.Write("\nEnter item number (0 to go back): ");
                int choose = Convert.ToInt32(Console.ReadLine());

                if (choose == 0)
                {
                    break;
                }

                if (foodService.IsValidNumber(choose) == false)
                {
                    Console.WriteLine("Invalid choice! Press any key...");
                    Console.ReadKey();
                    continue;
                }

                Console.Write("Enter quantity: ");
                int quantity = Convert.ToInt32(Console.ReadLine());

                FoodModel food = foodService.GetFood(choose);
                orderService.AddOrder(customerName, food.Name, food.Price, quantity);

                Console.WriteLine("\nAdded: " + food.Name + " x" + quantity + " = Rs." + (food.Price * quantity));
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        // ---------- ORDER DRINKS ----------
        void OrderDrinkScreen(string customerName)
        {
            while (true)
            {
                Console.Clear();
                drinkUi.ShowMenu();

                Console.Write("\nEnter drink number (0 to go back): ");
                int choose = Convert.ToInt32(Console.ReadLine());

                if (choose == 0)
                {
                    break;
                }

                if (drinkService.IsValidNumber(choose) == false)
                {
                    Console.WriteLine("Invalid choice! Press any key...");
                    Console.ReadKey();
                    continue;
                }

                Console.Write("Enter quantity: ");
                int quantity = Convert.ToInt32(Console.ReadLine());

                DrinkModel drink = drinkService.GetDrink(choose);
                orderService.AddOrder(customerName, drink.Name, drink.Price, quantity);

                Console.WriteLine("\nAdded: " + drink.Name + " x" + quantity + " = Rs." + (drink.Price * quantity));
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        // ---------- VIEW CURRENT ORDER ----------
        void ViewCurrentOrder(string customerName)
        {
            Console.Clear();
            Console.WriteLine("Current Order for: " + customerName + "\n");

            List<OrderModel> orders = orderService.GetOrdersByCustomer(customerName);

            if (orders.Count == 0)
            {
                Console.WriteLine("No items ordered yet!");
            }
            else
            {
                Console.WriteLine("No.\tItem\t\t\tQuantity\tSubtotal");
                Console.WriteLine("----------------------------------------------------");
                for (int i = 0; i < orders.Count; i++)
                {
                    Console.WriteLine((i + 1) + ".\t" + orders[i].ItemName + "\t\t" +
                                      orders[i].Quantity + "\tRs." + orders[i].GetSubtotal());
                }
            }

            Console.WriteLine("\nPress any key to go back...");
            Console.ReadKey();
        }

        // ---------- TOTAL BILL ----------
        void ShowBill(string customerName)
        {
            Console.Clear();
            Console.WriteLine("====================================================");
            Console.WriteLine("            BILL for: " + customerName);
            Console.WriteLine("====================================================");
            Console.WriteLine("No.\tItem\t\t\tQuantity\tSubtotal");
            Console.WriteLine("----------------------------------------------------");

            List<OrderModel> orders = orderService.GetOrdersByCustomer(customerName);
            for (int i = 0; i < orders.Count; i++)
            {
                Console.WriteLine((i + 1) + ".\t" + orders[i].ItemName + "\t\t" +
                                  orders[i].Quantity + "\tRs." + orders[i].GetSubtotal());
            }

            Console.WriteLine("====================================================");
            Console.WriteLine("\t\t\tTOTAL:\tRs." + orderService.CalculateTotal(customerName));
            Console.WriteLine("====================================================");

            Console.WriteLine("\nPress any key to go back...");
            Console.ReadKey();
        }

        // ---------- ADMIN: ALL ORDERS ----------
        public void ShowAllOrders()
        {
            Console.Clear();
            Console.WriteLine("All Orders : ");
            Console.WriteLine("Customer Name\tOrder Name\tQty\tPrice");
            Console.WriteLine("----------------------------------------------------");

            List<OrderModel> orders = orderService.GetAllOrders();
            for (int i = 0; i < orders.Count; i++)
            {
                Console.WriteLine(orders[i].CustomerName + "\t\t" + orders[i].ItemName + "\t" +
                                  orders[i].Quantity + "\t" + orders[i].GetSubtotal());
            }
            Console.ReadKey();
        }
    }
}