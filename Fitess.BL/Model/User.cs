namespace Fitess.BL.Model
{
    [Serializable]
    public class User
    {
        #region Properties
        public int Id { get; set; }
        public string Name { get; set;  }
        public int? GenderId { get; set; }
        public virtual Gender Gender { get; set; }
        public DateTime BirthDate { get; set; } = DateTime.Now;
        public double Weight { get; set; }
        public double Height { get; set; }
        public virtual ICollection<Eating> Eatings { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }

        public int Age { get { return DateTime.Now.Year - BirthDate.Year; } }
        #endregion

        /// <summary>
        /// Create a new user
        /// </summary>
        /// <param name="name"> Name</param>
        /// <param name="gender"> Gender</param>
        /// <param name="birthDate"> BirthDate</param>
        /// <param name="weight"> Weight</param>
        /// <param name="heigth"> Height</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public User(string name
                   , Gender gender
                   , DateTime birthDate
                   , double weight
                   , double heigth)
        {
            #region Checking values
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Username entered incorrectly", nameof(name));
            }
            if (gender == null)
            {
                throw new ArgumentNullException("Gender cannot be equal null", nameof(gender));
            }
            if (birthDate < DateTime.Parse("01.01.1900") || birthDate >= DateTime.Now)
            {
                throw new ArgumentException("Date of birth entered incorrectly", nameof(birthDate));
            }
            if (weight < 0)
            {
                throw new ArgumentException("weight cannot be less than one", nameof(weight));
            }
            if (heigth <= 0)
            {
                throw new ArgumentException("height cannot be less than one", nameof(heigth));
            }
            #endregion

            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = heigth;
        }
        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Username entered incorrectly", nameof(name));
            }
            Name = name;
        }
        public User() { }
        public override string ToString()
        {
            return Name + " " + Age;
        }
    }
}
