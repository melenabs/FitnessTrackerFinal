using FitnessTracker.Data;
using FitnessTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FitnessTracker.Pages
{
    public class SearchModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public SearchModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public string? SearchTerm { get; set; }

        public IList<Workout> Workouts { get; set; } = new List<Workout>();

        public IList<Exercise> Exercises { get; set; } = new List<Exercise>();

        public IList<Meal> Meals { get; set; } = new List<Meal>();

        public IList<Goal> Goals { get; set; } = new List<Goal>();

        public bool HasSearched => !string.IsNullOrWhiteSpace(SearchTerm);

        public async Task OnGetAsync()
        {
            if (!HasSearched)
            {
                return;
            }

            var term = SearchTerm!.Trim();

            Workouts = await _context.Workouts
                .Where(w => w.WorkoutName.Contains(term)
                            || (w.WorkoutType != null && w.WorkoutType.Contains(term)))
                .OrderByDescending(w => w.WorkoutDate)
                .ToListAsync();

            Exercises = await _context.Exercises
                .Where(e => e.Name.Contains(term)
                            || (e.MuscleGroup != null && e.MuscleGroup.Contains(term)))
                .OrderBy(e => e.Name)
                .ToListAsync();

            Meals = await _context.Meals
                .Where(m => m.MealName.Contains(term))
                .OrderByDescending(m => m.MealDate)
                .ToListAsync();

            Goals = await _context.Goals
                .Where(g => g.GoalName.Contains(term)
                            || (g.GoalType != null && g.GoalType.Contains(term)))
                .OrderBy(g => g.GoalName)
                .ToListAsync();
        }
    }
}
