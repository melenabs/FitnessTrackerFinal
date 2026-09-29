using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FitnessTracker.Models
{
    public class Exercise
    {
        public int ID { get; set; }

        public string Name { get; set; } = string.Empty;

        [Display(Name = "Muscle Group")]
        public string? MuscleGroup { get; set; }

        public string? Description { get; set; }

        public ICollection<WorkoutExercise> WorkoutExercises { get; set; } = new List<WorkoutExercise>();
    }
}
