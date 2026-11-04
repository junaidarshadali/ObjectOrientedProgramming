using System;
using System.Collections.Generic;
using RestaurantSystem.Drink;
using RestaurantSystem.Food;
using RestaurantSystem.Order;

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
                orderService.AddOrder(customerName, drink.drinkName, drink.drinkPrice, quantity);

                Console.WriteLine("\nAdded: " + drink.drinkName + " x" + quantity + " = Rs." + (drink.drinkPrice * quantity));
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

        public void SearchMenuScreen()
        {
            Console.Clear();
            Console.WriteLine("===== SEARCH MENU =====");

            Console.Write("Enter category (food / drink / all): ");
            string category = Console.ReadLine().ToLower();

            if (category != "food" && category != "drink" && category != "all")
            {
                Console.WriteLine("Invalid category!");
                Console.ReadKey();
                return;
            }

            Console.Write("Enter comparison (Above / Below): ");
            string comparison = Console.ReadLine().ToLower();

            if (comparison != "above" && comparison != "below")
            {
                Console.WriteLine("Invalid comparison!");
                Console.ReadKey();
                return;
            }

            Console.Write("Enter price: ");
            int price = Convert.ToInt32(Console.ReadLine());

            int found = 0;
            Console.WriteLine("\nCategory\tItem\t\t\tPrice");
            Console.WriteLine("----------------------------------------------------");

            if (category == "food" || category == "all")
            {
                List<FoodModel> foods = foodService.SearchByPrice(comparison, price);
                for (int i = 0; i < foods.Count; i++)
                {
                    Console.WriteLine("Food\t\t" + foods[i].Name + "\t\tRs." + foods[i].Price);
                    found++;
                }
            }

            if (category == "drink" || category == "all")
            {
                List<DrinkModel> drinks = drinkService.SearchByPrice(comparison, price);
                for (int i = 0; i < drinks.Count; i++)
                {
                    Console.WriteLine("Drink\t\t" + drinks[i].drinkName + "\t\tRs." + drinks[i].drinkPrice);
                    found++;
                }
            }

            if (found == 0)
            {
                Console.WriteLine("No items found!");
            }

            Console.WriteLine("\nPress any key to go back...");
            Console.ReadKey();
        }

        public void SearchByCategoryScreen()
        {
            Console.Clear();
            Console.WriteLine("===== SEARCH BY CATEGORY =====");

            Console.Write("Enter category (food / drink / all): ");
            string category = Console.ReadLine().ToLower();   // not case sensitive

            if (category != "food" && category != "drink" && category != "all")
            {
                Console.WriteLine("Invalid category!");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Category Item  And  Price");
            Console.WriteLine("----------------------------------------------------");

            if (category == "food" || category == "all")
            {
                List<FoodModel> foods = foodService.GetAllFoods();
                for (int i = 0; i < foods.Count; i++)
                {
                    Console.WriteLine("Food\t\t" + foods[i].Name + "\t\tRs." + foods[i].Price);
                }
            }

            if (category == "drink" || category == "all")
            {
                List<DrinkModel> drinks = drinkService.GetAllDrinks();
                for (int i = 0; i < drinks.Count; i++)
                {
                    Console.WriteLine("Drink\t\t" + drinks[i].drinkName + "\t\tRs." + drinks[i].drinkPrice);
                }
            }

            Console.WriteLine("\nPress any key to go back...");
            Console.ReadKey();
        }

    }

            // ---------- SIMPLE PAGES ----------
        public void SimplePageScreen()
        {
            Console.Clear();
            Console.Write("Enter category (food / drink / all): ");
            string category = Console.ReadLine().ToLower();

            // step 1: collect records in one list
            List<string> lines = new List<string>();

            if (category == "food" || category == "all")
            {
                List<FoodModel> foods = foodService.GetAllFoods();
                for (int i = 0; i < foods.Count; i++)
                {
                    lines.Add("Food\t" + foods[i].Name + "\tRs." + foods[i].Price);
                }
            }

            if (category == "drink" || category == "all")
            {
                List<DrinkModel> drinks = drinkService.GetAllDrinks();
                for (int i = 0; i < drinks.Count; i++)
                {
                    lines.Add("Drink\t" + drinks[i].drinkName + "\tRs." + drinks[i].drinkPrice);
                }
            }

            if (lines.Count == 0)
            {
                Console.WriteLine("No items found!");
                Console.ReadKey();
                return;
            }

            // step 2: find total pages (4 records per page)
            int pageSize = 4;
            int totalPages = lines.Count / pageSize;
            if (lines.Count % pageSize != 0)
            {
                totalPages = totalPages + 1;
            }

            int page = 1;

            // step 3: show one page, then ask what to do
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== RESULTS =====");

                int start = (page - 1) * pageSize;
                int end = start + pageSize;
                if (end > lines.Count)
                {
                    end = lines.Count;
                }
            }
        }

