using Fitess.BL.Model;

namespace Fitess.BL.Controller
{
    public class EatingController : ControllerBase
    {
        private readonly User User;
        public List<Food> Foods { get; set; }
        public Eating Eating { get; set; }
        public EatingController(User user)
        {
            User = user ?? throw new ArgumentNullException("User name cannot me empty", nameof(user));
            Foods = GetAllFoods();
            Eating = GetEating();
        }
        public void Add(Food food, double weight)
        {
            var product = Foods.SingleOrDefault(f => f.Name ==food.Name);
            if (product == null)
            {
                Foods.Add(food);
                Eating.AddFood(food, weight);
                Save();
            }
            else 
            {
                Eating.AddFood(product, weight);
                Save();
            }
        }

        private Eating GetEating()
        {
            return Load<Eating>().FirstOrDefault() ?? new Eating(User);
        }

        private List<Food> GetAllFoods()
        {
            return Load<Food>() ?? new List<Food>();
        }
        private void Save()
        {
            Save(Foods);
            Save(new List<Eating>() { Eating });
        }
    }
}
