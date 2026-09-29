using System.ComponentModel.DataAnnotations;

namespace FitnessTracker.Models
{
    public class WorkoutExercise
    {
        public int ID { get; set; }

        public int WorkoutID { get; set; }

        public Workout? Workout { get; set; }

        public int ExerciseID { get; set; }

        public Exercise? Exercise { get; set; }

        public int? Sets { get; set; }

        public int? Reps { get; set; }

        [Display(Name = "Weight Used")]
        public double? WeightUsed { get; set; }
    }
}
