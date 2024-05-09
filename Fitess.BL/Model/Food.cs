namespace Fitess.BL.Model
{
    [Serializable]
    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public double Proteins { get; set; }

        public double Fats { get; set; }

        public double Carbohydrates { get; set; }
        public virtual ICollection<Eating> Eatings { get; set; }

        //Calories per 100 g
        public double Calories { get; set;   }

        private double CaloriesPerGram { get { return Calories / 100.0; } }
        private double ProteinsPerGram { get { return Proteins / 100.0; } }
        private double FatsPerGram { get { return Fats / 100.0; } }
        private double CarbohydratesPerGram { get { return Carbohydrates / 100.0; } }
        public Food () { }

        public Food(string name):this(name,0, 0, 0, 0) { }

        public Food(string name,double calories, double proteins, double fats, double carbohydrates)
        {
            Name = name;
            Calories = calories/100.0;
            Proteins = proteins/100.0;
            Fats = fats/ 100.0;
            Calories = carbohydrates/100.0;

        }
        public override string ToString()
        {
            return Name;
        }
    }
}
