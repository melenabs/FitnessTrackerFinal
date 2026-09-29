using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FitnessTracker.Data;
using FitnessTracker.Models;

namespace FitnessTracker.Pages.WorkoutExercises
{
    public class CreateModel : PageModel
    {
        private readonly FitnessTracker.Data.ApplicationDbContext _context;

        public CreateModel(FitnessTracker.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ExerciseID"] = new SelectList(_context.Exercises, "ID", "ID");
        ViewData["WorkoutID"] = new SelectList(_context.Workouts, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public WorkoutExercise WorkoutExercise { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.WorkoutExercises.Add(WorkoutExercise);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
