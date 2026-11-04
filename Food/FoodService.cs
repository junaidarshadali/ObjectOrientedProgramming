using System.Collections.Generic;
using RestaurantSystem.Food;

namespace RestaurantSystem.Food
{
    public class FoodService
    {
        FoodRepo repo;
       
        public FoodService(FoodRepo repo)
        {
            this.repo = repo;
        }
        
        public List<FoodModel> GetAllFoods()
        {
            return repo.foods;
        }

        public void AddFood(string name, int price)
        {
            FoodModel food = new FoodModel(name, price);
            repo.foods.
                Add(food);
            repo.SaveToFile();
        }

        // number starts from 1 (same as menu)
        public bool IsValidNumber(int number)
        {
            if (number >= 1 && number <= repo.foods.Count)
            {
                return true;
            }
            return false;
        }

        public FoodModel GetFood(int number)
        {
            return repo.foods[number - 1];
        }

        public void UpdatePrice(int number, int newPrice)
        {
            repo.foods[number - 1].Price = newPrice;
            repo.SaveToFile();
        }

        public void RemoveFood(int number)
        {
            repo.foods.RemoveAt(number - 1);
            repo.SaveToFile();
        }

        public List<FoodModel> SearchByPrice(string comparison, int price)
        {
            List<FoodModel> result = new List<FoodModel>();
            comparison = comparison.ToLower();   // not case sensitive for it 

            for (int i = 0; i < repo.foods.Count; i++)
            {
                if (comparison == "above" && repo.foods[i].Price > price)
                {
                    result.Add(repo.foods[i]);
                }
                else if (comparison == "below" && repo.foods[i].Price < price)
                {
                    result.Add(repo.foods[i]);
                }
            }
            return result;
        }
    }
}

