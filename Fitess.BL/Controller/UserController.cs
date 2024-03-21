using Fitess.BL.Model;
using System.Runtime.Serialization.Formatters.Binary;

namespace Fitess.BL.Controller
{
    /// <summary>
    /// User controller
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// Users
        /// </summary>
        public List<User> Users { get; }
        public User CurrentUser { get; }
        public bool IsNewUser { get; } = false;
        /// <summary>
        /// New user controller creation
        /// </summary>
        /// <param name="user"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("User name cannot be empty", nameof(userName));
            }

            Users = GetUsersData();

            CurrentUser = Users.SingleOrDefault(user => user.Name == userName);

            if (CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }
        }
        /// <summary>
        /// Save user data.
        /// </summary>
        public void Save()
        {
#pragma warning disable SYSLIB0011
            var formatter = new BinaryFormatter();
            using (var fc = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fc, Users);
            }
        }
        /// <summary>
        /// Get user data.
        /// </summary>
        /// <returns> User </returns>
        /// <exception cref="FileLoadException"></exception>
        private List<User> GetUsersData()
        {
            var formatter = new BinaryFormatter();
            using (var fc = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fc) is List<User> users)
                {
                    return users;
                }
                else
                {
                    return new List<User>();
                }
            }
        }
        public void SetNewUserData(string genderName, DateTime birthDate, double weight = 1, double height = 1)
        {
            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;    
            Save();
        }
    }
}
