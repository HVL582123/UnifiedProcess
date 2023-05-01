using FitnessTracker.Models.Domain;

namespace FitnessTracker.Models.ViewModels
{
    public class AddWorkoutLogViewModel
    {
        public int WorkoutId { get; set; }
        public int ExerciseId { get; set; }

        public int nSets { get; set; }
        public int Reps { get; set; }
        public double weight { get; set; }
    }
}
