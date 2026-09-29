using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FitnessTracker.Data;
using FitnessTracker.Models;

namespace FitnessTracker.Pages.WorkoutExercises
{
    public class DeleteModel : PageModel
    {
        private readonly FitnessTracker.Data.ApplicationDbContext _context;

        public DeleteModel(FitnessTracker.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public WorkoutExercise WorkoutExercise { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workoutexercise = await _context.WorkoutExercises.FirstOrDefaultAsync(m => m.ID == id);

            if (workoutexercise is not null)
            {
                WorkoutExercise = workoutexercise;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workoutexercise = await _context.WorkoutExercises.FindAsync(id);
            if (workoutexercise != null)
            {
                WorkoutExercise = workoutexercise;
                _context.WorkoutExercises.Remove(WorkoutExercise);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
