using Microsoft.EntityFrameworkCore;
using virtusstructura_backend.Models;

namespace virtusstructura_backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<Microcycle> Microcycles { get; set; }
        public DbSet<Mesocycle> Mesocycles { get; set; }
        public DbSet<Macrocycle> Macrocycles { get; set; }
        public DbSet<TrainingPlan> TrainingPlans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TrainingPlan>()
                .HasOne(tp => tp.User)
                .WithMany(u => u.TrainingPlans)
                .HasForeignKey(tp => tp.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Macrocycle>()
                .HasOne(mc => mc.TrainingPlan)
                .WithMany(t => t.Macrocycles)
                .HasForeignKey(mc => mc.TrainingPlanId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Mesocycle>()
                .HasOne(mc => mc.Macrocycle)
                .WithMany(mc => mc.Mesocycles)
                .HasForeignKey(mc=> mc.MacrocycleId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Microcycle>()
                .HasOne(mc => mc.Mesocycle)
                .WithMany(mc => mc.Microcycles)
                .HasForeignKey(mc => mc.MesocycleId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Workout>()
                .HasOne(w => w.Microcycle)
                .WithMany(w => w.Workouts)
                .HasForeignKey(w => w.MicrocycleId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Exercise>()
                .HasOne(e => e.Workout)
                .WithMany(w => w.Exercises)
                .HasForeignKey(e => e.WorkoutId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
