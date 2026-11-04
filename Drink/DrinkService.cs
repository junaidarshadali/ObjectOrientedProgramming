using System.Collections.Generic;
using RestaurantSystem.Drink;

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
            repo.drinks[number - 1].drinkPrice = newPrice;
            repo.SaveToFile();
        }

        public List<DrinkModel> SearchByPrice(string comparison, int price)
        {
            List<DrinkModel> result = new List<DrinkModel>();
            comparison = comparison.ToLower();   // not case sensitive

            for (int i = 0; i < repo.drinks.Count; i++)
            {
                if (comparison == "above" && repo.drinks[i].drinkPrice > price)
                {
                    result.Add(repo.drinks[i]);
                }
                else if (comparison == "below" && repo.drinks[i].drinkPrice < price)
                {
                    result.Add(repo.drinks[i]);
                }
            }
            return result;
        }
    }
}


