﻿namespace Fitess.BL.Model
{
    [Serializable]
    public class Food
    {
        public string Name { get; }

        public double Proteins { get; }

        public double Fats { get; }

        public double Carbohydrates { get; }

        //Calories per 100 g
        public double Calories { get; }

        private double CaloriesPerGram { get { return Calories / 100.0; } }
        private double ProteinsPerGram { get { return Proteins / 100.0; } }
        private double FatsPerGram { get { return Fats / 100.0; } }
        private double CarbohydratesPerGram { get { return Carbohydrates / 100.0; } }

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
