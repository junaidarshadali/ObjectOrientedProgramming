namespace RestaurantSystem.Food
{
    public class FoodModel
    {
        public string Name;
        public int Price;

        public FoodModel(string name, int price)
        {
            Name = name;
            Price = price;
        }
    }
}