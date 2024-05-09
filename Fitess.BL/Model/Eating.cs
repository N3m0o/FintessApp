namespace Fitess.BL.Model
{
    [Serializable]
    public class Eating
    {
        public int Id { get; set; }
        public DateTime Moment { get; set; }
        public Dictionary<Food, double> Food { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public Eating() { }

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
