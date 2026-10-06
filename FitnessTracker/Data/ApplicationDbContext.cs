using FitnessTracker.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FitnessTracker.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>().HasIndex(u => u.MemberNumber).IsUnique();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            AssignMemberNumbers();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            AssignMemberNumbers();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void AssignMemberNumbers()
        {
            var newUsers = ChangeTracker.Entries<ApplicationUser>()
                .Where(e => e.State == EntityState.Added && e.Entity.MemberNumber == 0)
                .Select(e => e.Entity)
                .ToList();
            if (newUsers.Count == 0) return;

            var next = (Users.Max(u => (int?)u.MemberNumber) ?? 1000) + 1;
            foreach (var user in newUsers) user.MemberNumber = next++;
        }

        public DbSet<UserProfile> UserProfiles { get; set; }

        public DbSet<Workout> Workouts { get; set; }

        public DbSet<Exercise> Exercises { get; set; }

        public DbSet<WorkoutExercise> WorkoutExercises { get; set; }

        public DbSet<Meal> Meals { get; set; }

        public DbSet<Goal> Goals { get; set; }
    }
}
