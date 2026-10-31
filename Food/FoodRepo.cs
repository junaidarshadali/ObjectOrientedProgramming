using System;
using System.Collections.Generic;
using System.IO;

namespace RestaurantSystem.Food
{
    public class FoodRepo
    {
        public List<FoodModel> foods = new List<FoodModel>();
        string path = "foods.txt";

        public FoodRepo()
        {
            LoadFromFile();
        }

        // Read the file and fill the list
        public void LoadFromFile()
        {
            // First time: file does not exist, so add default items
            if (File.Exists(path) == false)
            {
                foods.Add(new FoodModel("Chicken Burger", 300));
                foods.Add(new FoodModel("Beef Burger", 400));
                foods.Add(new FoodModel("Pizza", 600));
                foods.Add(new FoodModel("Pepperoni Pizza", 700));
                foods.Add(new FoodModel("Chicken Shawarma", 800));
                foods.Add(new FoodModel("Beef Shawarma", 350));
                foods.Add(new FoodModel("Fries", 450));
                foods.Add(new FoodModel("Garlic Bread", 100));
                SaveToFile();
                return;
            }

            StreamReader reader = new StreamReader(path);
            string line = reader.ReadLine();
            while (line != null)
            {
                if (line != "")
                {
                    string[] parts = line.Split('|');
                    string name = parts[0];
                    int price = Convert.ToInt32(parts[1]);
                    foods.Add(new FoodModel(name, price));
                }
                line = reader.ReadLine();
            }
            reader.Close();
        }

        // Write the whole list into the file
        public void SaveToFile()
        {
            StreamWriter writer = new StreamWriter(path);
            for (int i = 0; i < foods.Count; i++)
            {
                writer.WriteLine(foods[i].Name + "|" + foods[i].Price);
            }
            writer.Close();
        }
    }
}