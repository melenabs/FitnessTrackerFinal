using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace FitnessTracker.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int MemberNumber { get; set; }

        public UserProfile? UserProfile { get; set; }

        public ICollection<Workout> Workouts { get; set; } = new List<Workout>();

        public ICollection<Meal> Meals { get; set; } = new List<Meal>();

        public ICollection<Goal> Goals { get; set; } = new List<Goal>();
    }
}
