using FitnessTracker.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FitnessTracker.Models.ViewModels;
using FitnessTracker.Models.Domain;

namespace FitnessTracker.Pages.Workouts
{
    public class AddWorkoutsModel : PageModel
    {
        private readonly FitnessTrackerDbContext dbContext;

        public AddWorkoutsModel(FitnessTrackerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [BindProperty]
        public AddWorkoutViewModel AddWorkoutRequest { get; set; }

        public void OnGet()
        { 
        }

        public IActionResult OnPost()
        {
            var workoutDomainModel = new Workout
            {
                WorkoutName = AddWorkoutRequest.WorkoutName,
                WorkoutDate = AddWorkoutRequest.WorkoutDate
            };

            dbContext.Workout.Add(workoutDomainModel);
            dbContext.SaveChanges();

            int workoutId = workoutDomainModel.WorkoutId;

           return RedirectToPage("/Workouts/AddExercises", new { workoutId});
        }
    }
}
