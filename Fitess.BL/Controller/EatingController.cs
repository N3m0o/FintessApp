using Fitess.BL.Model;

namespace Fitess.BL.Controller
{
    public class EatingController : ControllerBase
    {
        private const string FOODS_FILE_NAME = "users.dat";
        private const string EATINGS_FILE_NAME = "eatings.dat";
        private readonly User User;
        public List<Food> Foods { get; }
        public Eating Eating { get; }
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
            return Load<Eating>(EATINGS_FILE_NAME) ?? new Eating(User);
        }

        private List<Food> GetAllFoods()
        {
            return Load<List<Food>>(FOODS_FILE_NAME) ?? new List<Food>();
        }
        private void Save()
        {
            Save(FOODS_FILE_NAME, Foods);
            Save(EATINGS_FILE_NAME, Eating);
        }
    }
}
