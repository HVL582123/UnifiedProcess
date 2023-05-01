namespace FitnessTracker.Models.Domain
{
    public class WorkoutLog
    {
        public int WorkoutLogId { get; set; }
        //FK for Workout
        public int WorkoutId { get; set; }
        public Workout Workout { get; set; }

        //FK for Exercise
        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }

        public int nSets { get; set; }
        public int Reps { get; set; }
        public double weight { get; set; }

    }
}
