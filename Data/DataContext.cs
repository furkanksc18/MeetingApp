using MeetingApp.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace MeetingApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Meeting> Meetings => Set<Meeting>();
        public DbSet<User> Users => Set<User>();
        public DbSet<MeetingMapUser> MeetingMapUsers => Set<MeetingMapUser>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MeetingMapUser>()
                .HasIndex(m => new { m.MeetingId, m.UserId })
                .IsUnique();
        }
    }
}