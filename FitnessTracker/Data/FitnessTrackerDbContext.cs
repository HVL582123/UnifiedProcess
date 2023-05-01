using FitnessTracker.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace FitnessTracker.Data
{
    public class FitnessTrackerDbContext : DbContext
    {
        // Hold over class name then ctrl + . to create constructor
        public FitnessTrackerDbContext(DbContextOptions options) : base(options)
        {
        }

        //Table name
        public DbSet<Workout> Workout { get; set;}
        public DbSet<Exercise> Exercise { get; set; }
        public DbSet<WorkoutLog> WorkoutLog { get; set;}
    }
}
