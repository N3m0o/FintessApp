using Fitess.BL.Controller;
using System.Data;

namespace Fitness.CMD
{
    class Program
    {
        public static void Main(string[] args)
        {

            Console.WriteLine("Вас приветствует приложение:");

            Console.WriteLine("Введите имя пользователя");
            var name = Console.ReadLine();

            var userController = new UserController(name);

            if (userController.IsNewUser)
            {
                Console.Write("Введите пол: ");
                var gender = Console.ReadLine();
                var bithdate = ParseDataTime();
                var height = ParseDouble("вес");
                var weight = ParseDouble("рост");
                 
                userController.SetNewUserData(gender,bithdate,weight,height);
            }

            Console.WriteLine(userController.CurrentUser);
            Console.ReadLine();

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
                    Console.WriteLine($"Неверный формат {name}");
                }
            }
        }
        private static DateTime ParseDataTime() 
        {
            DateTime bithdate;
            while (true)
            {
                Console.Write("Введите дату рождения (dd.MM.yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out bithdate))
                {
                    return bithdate;
                }
                else
                {
                    Console.WriteLine("Неверный формат даты рождения");
                }
            }
        }




    }




}