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
    public class IndexModel : PageModel
    {
        private readonly FitnessTracker.Data.ApplicationDbContext _context;

        public IndexModel(FitnessTracker.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Workout> Workout { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Workout = await _context.Workouts
                .Include(w => w.ApplicationUser).ToListAsync();
        }
    }
}
