namespace RestaurantSystem.Food
{
    public class FoodModel
    {
        public string Name;
        public int Price;

        public FoodModel(string Name, int Price)
        {
            this.Name = Name;
            this.Price = Price;
        }
    }
}