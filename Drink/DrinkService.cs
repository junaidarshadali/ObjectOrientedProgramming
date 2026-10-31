using System.Collections.Generic;

namespace RestaurantSystem.Drink
{
    public class DrinkService
    {
        DrinkRepo repo;

        public DrinkService(DrinkRepo repo)
        {
            this.repo = repo;
        }

        public List<DrinkModel> GetAllDrinks()
        {
            return repo.drinks;
        }

        public void AddDrink(string name, int price)
        {
            DrinkModel drink = new DrinkModel(name, price);
            repo.drinks.Add(drink);
            repo.SaveToFile();
        }

        public bool IsValidNumber(int number)
        {
            if (number >= 1 && number <= repo.drinks.Count)
            {
                return true;
            }
            return false;
        }

        public DrinkModel GetDrink(int number)
        {
            return repo.drinks[number - 1];
        }

        public void UpdatePrice(int number, int newPrice)
        {
            repo.drinks[number - 1].Price = newPrice;
            repo.SaveToFile();
        }
    }
}