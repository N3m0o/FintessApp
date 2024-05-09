using Fitess.BL.Model;
using System.Data.Entity;
using System.Diagnostics;

namespace Fitess.BL.Controller
{
    internal class FitnessContext : DbContext
    {
        public FitnessContext() : base("DbConnection") { }
        public DbSet<Model.Activity> Activities { get; set; }
        public DbSet<Eating> Eatings { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<User> Users { get; set; }




    }
}
