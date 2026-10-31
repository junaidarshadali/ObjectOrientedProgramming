using System;
using System.Collections.Generic;
using System.IO;

namespace RestaurantSystem.Order
{
    public class OrderRepo
    {
        public List<OrderModel> orders = new List<OrderModel>();
        string path = "orders.txt";

        public OrderRepo()
        {
            LoadFromFile();
        }

        // Read the file and fill the list
        public void LoadFromFile()
        {
            // If no file yet, there are no old orders
            if (File.Exists(path) == false)
            {
                return;
            }

            StreamReader reader = new StreamReader(path);
            string line = reader.ReadLine();
            while (line != null)
            {
                if (line != "")
                {
                    string[] parts = line.Split('|');
                    string customerName = parts[0];
                    string itemName = parts[1];
                    int price = Convert.ToInt32(parts[2]);
                    int quantity = Convert.ToInt32(parts[3]);
                    orders.Add(new OrderModel(customerName, itemName, price, quantity));
                }
                line = reader.ReadLine();
            }
            reader.Close();
        }

        // Write the whole list into the file
        public void SaveToFile()
        {
            StreamWriter writer = new StreamWriter(path);
            for (int i = 0; i < orders.Count; i++)
            {
                writer.WriteLine(orders[i].CustomerName + "|" + orders[i].ItemName + "|" +
                                 orders[i].Price + "|" + orders[i].Quantity);
            }
            writer.Close();
        }
    }
}