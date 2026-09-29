using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FitnessTracker.Models
{
    public class Workout
    {
        public int ID { get; set; }

        public string? ApplicationUserId { get; set; }

        public ApplicationUser? ApplicationUser { get; set; }

        [Display(Name = "Workout Name")]
        public string WorkoutName { get; set; } = string.Empty;

        [Display(Name = "Workout Type")]
        public string? WorkoutType { get; set; }

        [Display(Name = "Duration Minutes")]
        public int? DurationMinutes { get; set; }

        [Display(Name = "Calories Burned")]
        public int? CaloriesBurned { get; set; }

        [Display(Name = "Workout Date")]
        public DateTime WorkoutDate { get; set; }

        public string? Notes { get; set; }

        public ICollection<WorkoutExercise> WorkoutExercises { get; set; } = new List<WorkoutExercise>();
    }
}
