using System;
using System.ComponentModel.DataAnnotations;

namespace FitnessTracker.Models
{
    public class Meal
    {
        public int ID { get; set; }

        public string? ApplicationUserId { get; set; }

        public ApplicationUser? ApplicationUser { get; set; }

        [Display(Name = "Meal Name")]
        public string MealName { get; set; } = string.Empty;

        public int? Calories { get; set; }

        public double? Protein { get; set; }

        public double? Carbs { get; set; }

        public double? Fat { get; set; }

        [Display(Name = "Meal Date")]
        public DateTime MealDate { get; set; }

        public string? Notes { get; set; }
    }
}
