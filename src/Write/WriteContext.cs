using Microsoft.EntityFrameworkCore;
using Write.Pocos;

namespace Write
{
    public class WriteContext : DbContext
    {
        public WriteContext(DbContextOptions<WriteContext> options)
        : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Presence>().HasKey(p => new { p.BarbecueId, p.ParticipantId });

            modelBuilder.Entity<Presence>()
                .HasOne(sc => sc.Barbecue)
                .WithMany(s => s.Presences)
                .HasForeignKey(sc => sc.BarbecueId);


            modelBuilder.Entity<Presence>()
                .HasOne(sc => sc.Participant)
                .WithMany(s => s.Presences)
                .HasForeignKey(sc => sc.ParticipantId);
        }

        public DbSet<Barbecue> Barbecues { get; set; }
    }
}
