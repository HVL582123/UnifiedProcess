using FitnessTracker.Data;
using FitnessTracker.Models.Domain;
using FitnessTracker.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FitnessTracker.Pages.Workouts
{
    public class AddExercisesModel : PageModel
    {
        private readonly FitnessTrackerDbContext dbContext;

        [BindProperty(SupportsGet = true)]
        public int WorkoutId { get; set; }

        [BindProperty]
        public string ExerciseName { get; set; }

        [BindProperty]
        public int Weight { get; set; }

        [BindProperty]
        public int Reps { get; set; }

        [BindProperty]
        public int Sets { get; set; }

        [BindProperty]
        public AddExerciseViewModel AddExerciseRequest { get; set; }

        [BindProperty]
        public int SelectedExerciseId { get; set; }

        public List<WorkoutLog> workoutExercises { get; set; }

        public IList<Exercise> exercises { get; set; }

        public SelectList ExerciseOptions { get; set; }

        public AddExercisesModel(FitnessTrackerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public void OnGet()
        {
            workoutExercises = dbContext.WorkoutLog
                .Where(e => e.WorkoutId == WorkoutId)
                .ToList();

            exercises = dbContext.Exercise.ToList();

            ExerciseOptions = new SelectList(exercises, "ExerciseId", "Name");
        }

        public IActionResult OnPost()
        {
                var workoutLog = new WorkoutLog
                {
                    WorkoutId = WorkoutId,
                    ExerciseId = SelectedExerciseId,
                    nSets = Sets,
                    Reps = Reps,
                    weight = Weight
                };
                dbContext.WorkoutLog.Add(workoutLog);
                dbContext.SaveChanges();
           
            return RedirectToPage("/Workouts/AddExercises", new { WorkoutId });
        }
    }
}
