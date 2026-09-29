using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FitnessTracker.Data;
using FitnessTracker.Models;

namespace FitnessTracker.Pages.Workouts
{
    public class DetailsModel : PageModel
    {
        private readonly FitnessTracker.Data.ApplicationDbContext _context;

        public DetailsModel(FitnessTracker.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Workout Workout { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workout = await _context.Workouts.FirstOrDefaultAsync(m => m.ID == id);

            if (workout is not null)
            {
                Workout = workout;

                return Page();
            }

            return NotFound();
        }
    }
}
