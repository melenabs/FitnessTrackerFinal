using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FitnessTracker.Data;
using FitnessTracker.Models;

namespace FitnessTracker.Pages.Exercises
{
    public class IndexModel : PageModel
    {
        private readonly FitnessTracker.Data.ApplicationDbContext _context;

        public IndexModel(FitnessTracker.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Exercise> Exercise { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Exercise = await _context.Exercises.ToListAsync();
        }
    }
}
