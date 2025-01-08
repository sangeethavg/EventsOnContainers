using EventCatalogAPI.Domain;
using Microsoft.EntityFrameworkCore;

namespace EventCatalogAPI.Data
{
    public class EventContext : DbContext
    {
        public EventContext(DbContextOptions options) : base(options) { }
        public DbSet<EventType> EventTypes { get; set; }    
        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventType>(e =>
            {
                e.Property(t => t.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

                e.Property(t => t.Type)
                .IsRequired()
                .HasMaxLength(100);
            });

            modelBuilder.Entity<Event>(e =>
            {
                e.Property(i => i.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

                e.Property(i => i.Name)
                .IsRequired()
                .HasMaxLength(250);

                e.Property(i => i.Location)
                .IsRequired()
                .HasMaxLength(300);
               
                e.Property(i => i.Time)
                .IsRequired();

                e.Property(i => i.Duration)
               .IsRequired();

                e.Property(i => i.Ticket)
                .IsRequired();

                e.HasOne(i => i.EventType)
                .WithMany()
                .HasForeignKey(i => i.EventTypeId);


            });
        }

    }
}
