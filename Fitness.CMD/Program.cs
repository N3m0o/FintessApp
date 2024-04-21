using Fitess.BL.Controller;
using Fitess.BL.Model;
using System.Data;
using System.Globalization;
using System.Resources;

namespace Fitness.CMD
{
    class Program
    {
        public static void Main(string[] args)
        {
            var culture = CultureInfo.CreateSpecificCulture("en-us");
            var resourceManager = new ResourceManager("Fitness.CMD.Languages.Masseges", typeof(Program).Assembly);

            Console.WriteLine(resourceManager.GetString("Hello", culture));

            Console.WriteLine(resourceManager.GetString("EnterName", culture));
            var name = Console.ReadLine();

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);
            var exerciseController = new ExerciseController(userController.CurrentUser);

            if (userController.IsNewUser)
            {
                Console.Write("Введите пол: ");
                var gender = Console.ReadLine();
                var bithdate = ParseDataTime("дата рождения");
                var height = ParseDouble("вес");
                var weight = ParseDouble("рост");

                userController.SetNewUserData(gender, bithdate, weight, height);
            }

            while (true)
            {
                Console.WriteLine(userController.CurrentUser);

                Console.WriteLine("Что вы хотите сделать?");
                Console.WriteLine("Е - ввести приём пищи");
                Console.WriteLine("A - ввести упражнение");
                Console.WriteLine("Q - выход");
                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.E:
                        {
                            var foods = EnterEating();
                            eatingController.Add(foods.Food, foods.Weight);

                            foreach (var item in eatingController.Eating.Food)
                            {
                                Console.WriteLine($"\t{item.Key} - {item.Value}");
                            }
                            break;
                        }
                    case ConsoleKey.A:
                        {
                            var exe = EnterExercise();
                            exerciseController.Add(exe.Activity,exe.Begin, exe.End);
                            break;
                        }
                    case ConsoleKey.Q:
                        {
                            Environment.Exit(0);
                            break;
                        }
                }

                Console.ReadLine();

            }
        }

        private static (DateTime Begin, DateTime End, Activity Activity) EnterExercise()
        {
            Console.Write("Введите название упражнения:");
            var name = Console.ReadLine();
            var energy = ParseDouble("расход энергии в минуту");
            var begin = ParseDataTime("начало упражнения");
            var end = ParseDataTime("конец упражнения");
            var activity = new Activity(name,energy);
            return (begin,end,activity);
        }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.Write("Введите название продукта");
            var food = Console.ReadLine();

            var calories = ParseDouble("калорийность");
            var proteins = ParseDouble("белки");
            var fats = ParseDouble("жиры");
            var carbohydrates = ParseDouble("углеводы");

            var weight = ParseDouble("вес порции");
            var product = new Food(food, calories, proteins, fats, carbohydrates);

            return (Food: product, Weight: weight);
        }

        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.Write($"Введите {name}: ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Неверный формат поля {name}");
                }
            }
        }
        private static DateTime ParseDataTime(string value)
        {
            DateTime bithdate;
            while (true)
            {
                Console.Write($"Введите {value} (dd.MM.yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out bithdate))
                {
                    return bithdate;
                }
                else
                {
                    Console.WriteLine($"Неверный формат {value}");
                }
            }
        }




    }




}