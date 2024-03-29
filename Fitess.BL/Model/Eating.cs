namespace Fitess.BL.Model
{
    [Serializable]
    public class Eating
    {
        public DateTime Moment { get; }
        public Dictionary<Food, double> Food { get; }
        public User User { get; }

        public Eating(User user)
        {
            User = user ?? throw new ArgumentNullException("User name cannot be empty", nameof(user));
            Moment = DateTime.UtcNow;
            Food = new Dictionary<Food, double>();
        }
        public void AddFood(Food food, double foodWeight)
        {
            var product = Food.Keys.FirstOrDefault(f => f.Name.Equals(food.Name));
            if (product == null)
            {
                Food.Add(food, foodWeight);
            }
            else 
            {
                Food[food] += foodWeight;
            }
        }
    }
}
