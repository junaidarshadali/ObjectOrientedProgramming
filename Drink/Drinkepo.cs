using System;
using System.Collections.Generic;
using System.IO;

namespace RestaurantSystem.Drink
{
    public class DrinkRepo
    {
        public List<DrinkModel> drinks= new List<DrinkModel>();

        string path = "drink.txt";

        public DrinkRepo(){
            LoadFromFile();
        }

        public void LoadFromFile()
        {
            // First time: file does not exist, so add default drinks
            if (File.Exists(path) == false)
            {
                drinks.Add(new DrinkModel("7up", 100));
                drinks.Add(new DrinkModel("Coca-Cola", 120));
                drinks.Add(new DrinkModel("Pepsi", 120));
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
                    drinks.Add(new DrinkModel(name, price));
                }
                line = reader.ReadLine();
            }
            reader.Close();
        }

        public void SaveToFile()
        {
            StreamWriter writer = new StreamWriter(path);
            for (int i = 0; i < drinks.Count; i++)
            {
                writer.WriteLine(drinks[i].drinkName + "|" + drinks[i].drinkPrice);
            }
            writer.Close();
        }

       
    }
}