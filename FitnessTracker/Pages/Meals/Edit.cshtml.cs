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

namespace FitnessTracker.Pages.Meals
{
    public class EditModel : PageModel
    {
        private readonly FitnessTracker.Data.ApplicationDbContext _context;

        public EditModel(FitnessTracker.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Meal Meal { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meal =  await _context.Meals.FirstOrDefaultAsync(m => m.ID == id);
            if (meal == null)
            {
                return NotFound();
            }
            Meal = meal;
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

            _context.Attach(Meal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MealExists(Meal.ID))
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

        private bool MealExists(int id)
        {
            return _context.Meals.Any(e => e.ID == id);
        }
    }
}
