
using FitnessTrackerApp.Models;
using System.Data.Entity;

namespace FitnessTrackerApp.DAL
{
    public class FitnessTrackerDbContext : DbContext
    {
        public FitnessTrackerDbContext()
            : base("name=FitnessTrackerConnectionString")
        {
        }
        public DbSet<Workout> Workouts { get; set; }
    }
}