using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FitnessTracker.Data;
using FitnessTracker.Models;

namespace FitnessTracker.Pages.Goals
{
    public class EditModel : PageModel
    {
        private readonly FitnessTracker.Data.ApplicationDbContext _context;

        public EditModel(FitnessTracker.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Goal Goal { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goal =  await _context.Goals.FirstOrDefaultAsync(m => m.ID == id);
            if (goal == null)
            {
                return NotFound();
            }
            Goal = goal;
           ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "MemberNumber");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Goal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GoalExists(Goal.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool GoalExists(int id)
        {
            return _context.Goals.Any(e => e.ID == id);
        }
    }
}
