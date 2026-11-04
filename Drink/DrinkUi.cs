using System;

namespace RestaurantSystem.Drink
{
    public class DrinkUi
    {
        DrinkService service;

        public DrinkUi(DrinkService service)
        {
            this.service = service;
        }

        public void ShowMenu()
        {
            Console.WriteLine("\n===== DRINKS MENU =====");
            for (int i = 0; i < service.GetAllDrinks().Count; i++)
            {
                DrinkModel drink = service.GetAllDrinks()[i];
                Console.WriteLine((i + 1) + ".\t" + drink.drinkName + "\tRs." + drink.drinkPrice);
            }
        }

        public void AddDrinkScreen()
        {
            Console.Write("Enter Item Name : ");
            string name = Console.ReadLine();
            Console.Write("Enter Price : ");
            int price = Convert.ToInt32(Console.ReadLine());

            service.AddDrink(name, price);
            Console.WriteLine("\nItem Added Successfully!");
            Console.ReadKey();
        }

        public void UpdatePriceScreen()
        {
            Console.Clear();
            ShowMenu();

            Console.Write("\nEnter drink number to update price: ");
            int number = Convert.ToInt32(Console.ReadLine());

            if (service.IsValidNumber(number)) 
            {
                DrinkModel drink = service.GetDrink(number);
                Console.WriteLine("Current Price of " + drink.drinkName + " is Rs." + drink.drinkPrice);
                Console.Write("Enter New Price: ");
                int newPrice = Convert.ToInt32(Console.ReadLine());

                service.UpdatePrice(number, newPrice);
                Console.WriteLine("\nPrice Updated Successfully!");
            }
            else
            {
                Console.WriteLine("\nInvalid Drink Number!");
            }
            Console.ReadKey();
        }
    }
}