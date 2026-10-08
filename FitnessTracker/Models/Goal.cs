using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessTracker.Models
{
    public class Goal
    {
        public int ID { get; set; }

        public string? ApplicationUserId { get; set; }

        public ApplicationUser? ApplicationUser { get; set; }

        [Display(Name = "Goal Name")]
        public string GoalName { get; set; } = string.Empty;

        [Display(Name = "Goal Type")]
        public string? GoalType { get; set; }

        [Display(Name = "Target Value")]
        public double? TargetValue { get; set; }

        [Display(Name = "Current Value")]
        public double? CurrentValue { get; set; }

        [Display(Name = "Target Date")]
        [DataType(DataType.Date)]
        public DateTime? TargetDate { get; set; }

        [NotMapped]
        public bool IsCompleted => CurrentValue.HasValue
                                   && TargetValue.HasValue
                                   && CurrentValue.Value >= TargetValue.Value;
    }
}
