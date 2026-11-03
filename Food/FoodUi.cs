using System;

namespace RestaurantSystem.Food
{
    public class FoodUi
    {
        FoodService service;
        // constructor
        public FoodUi(FoodService service)
        {
            this.service = service;
        }

        public void ShowMenu()
        {
            Console.WriteLine("\n===== FOOD MENU =====");
            for (int i = 0; i < service.GetAllFoods().Count; i++)
            {
                FoodModel food = service.GetAllFoods()[i];
                Console.WriteLine((i + 1) + ".\t" + food.Name + "\tRs." + food.Price);
            }
        }

        public void AddFoodScreen()
        {
            Console.Write("Enter Item Name : ");
            string name = Console.ReadLine();
            Console.Write("Enter Price : ");
            int price = Convert.ToInt32(Console.ReadLine());

            service.AddFood(name, price);
            Console.WriteLine("\nItem Added Successfully!");
            Console.ReadKey();
        }

        public void UpdatePriceScreen()
        {
            Console.Clear();
            ShowMenu();

            Console.Write("\nEnter food number to update price: ");
            int number = Convert.ToInt32(Console.ReadLine());

            if (service.IsValidNumber(number))
            {
                FoodModel food = service.GetFood(number);
                Console.WriteLine("Current Price of " + food.Name + " is Rs." + food.Price);
                Console.Write("Enter New Price: ");
                int newPrice = Convert.ToInt32(Console.ReadLine());

                service.UpdatePrice(number, newPrice);
                Console.WriteLine("\nPrice Updated Successfully!");
            }
            else
            {
                Console.WriteLine("\nInvalid Food Number!");
            }
            Console.ReadKey();
        }

        public void RemoveFoodScreen()
        {
            Console.Clear();
            ShowMenu();

            Console.Write("\nEnter food number to remove: ");
            int number = Convert.ToInt32(Console.ReadLine());

            if (service.IsValidNumber(number))
            {
                service.RemoveFood(number);
                Console.WriteLine("\nItem Removed Successfully!");
            }
            else
            {
                Console.WriteLine("\nInvalid Food Number!");
            }
            Console.ReadKey();
        }
    }
}