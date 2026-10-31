namespace RestaurantSystem.Order
{
    public class OrderModel
    {
        public string CustomerName;
        public string ItemName;
        public int Price;
        public int Quantity;

        public OrderModel(string customerName, string itemName, int price, int quantity)
        {
            CustomerName = customerName;
            ItemName = itemName;
            Price = price;
            Quantity = quantity;
        }

        public int GetSubtotal()
        {
            return Price * Quantity;
        }
    }
}