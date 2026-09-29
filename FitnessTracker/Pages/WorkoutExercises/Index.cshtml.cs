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
    public class IndexModel : PageModel
    {
        private readonly FitnessTracker.Data.ApplicationDbContext _context;

        public IndexModel(FitnessTracker.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<WorkoutExercise> WorkoutExercise { get;set; } = default!;

        public async Task OnGetAsync()
        {
            WorkoutExercise = await _context.WorkoutExercises
                .Include(w => w.Exercise)
                .Include(w => w.Workout).ToListAsync();
        }
    }
}
