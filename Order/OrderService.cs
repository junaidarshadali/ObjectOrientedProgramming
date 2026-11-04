using System.Collections;
using System.Collections.Generic;

namespace RestaurantSystem.Order
{
    public class OrderService
    {
        OrderRepo repo;

        public OrderService(OrderRepo repo)
        {
            this.repo = repo;
        }

        public void AddOrder(string customerName, string itemName, int price, int quantity)
        {
            OrderModel order = new OrderModel(customerName, itemName, price, quantity);
            repo.orders.Add(order);
            repo.SaveToFile();
        }

        public List<OrderModel> GetAllOrders()
        {
            return repo.orders;
        }

        public List<OrderModel> GetOrdersByCustomer(string customerName)
        {

            List<OrderModel> result = new List<OrderModel>();
            for (int i = 0; i < repo.orders.Count; i++)
            {
                if (repo.orders[i].CustomerName == customerName)
                {
                    result.Add(repo.orders[i]);
                }
            }
            return result;
        }

        public int CalculateTotal(string customerName)
        {
            int total = 0;
            List<OrderModel> myOrders = GetOrdersByCustomer(customerName);
            for (int i = 0; i < myOrders.Count; i++)
            {
                total = total + myOrders[i].GetSubtotal();
            }
            return total;
        }
    }
}



 









//SearchOption by category and price category is not case 
//    Casesenstive and for price user enter above and below for comparison than enter price so this filter records make it easy so my sir dont understand its ai