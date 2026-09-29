using System.ComponentModel.DataAnnotations;

namespace FitnessTracker.Models
{
    public class UserProfile
    {
        public int ID { get; set; }

        public string? ApplicationUserId { get; set; }

        public ApplicationUser? ApplicationUser { get; set; }

        [Display(Name = "Full Name")]
        public string Name { get; set; } = string.Empty;

        public int? Age { get; set; }

        public double? Weight { get; set; }

        public double? Height { get; set; }

        [Display(Name = "Fitness Goal")]
        public string? FitnessGoal { get; set; }
    }
}
