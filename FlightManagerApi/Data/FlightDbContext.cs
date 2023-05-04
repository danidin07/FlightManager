using FlightManagerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightManagerApi.Data
{
    public class FlightDbContext:DbContext
    {
        public virtual DbSet<Flight> Flights { get; set; }
        public virtual DbSet<Leg> Legs { get; set; }
        public virtual DbSet<Logger> Loggers { get; set; }
        public FlightDbContext(DbContextOptions<FlightDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                modelBuilder.Entity<Leg>().HasData(
               new Leg { Id = 1, Number = 1, WaitTime = 3, CurrentLeg = LegType.One, Next = LegType.Two },
               new Leg { Id = 2, Number = 2, WaitTime = 3, CurrentLeg = LegType.Two, Next = LegType.Thr },
               new Leg { Id = 3, Number = 3, WaitTime = 3, CurrentLeg = LegType.Thr, Next = LegType.Fou },
               new Leg { Id = 4, Number = 4, WaitTime = 3, CurrentLeg = LegType.Fou, Next = LegType.Fiv | LegType.Dep },
               new Leg { Id = 5, Number = 5, WaitTime = 3, CurrentLeg = LegType.Fiv, Next = LegType.Six | LegType.Sev },
               new Leg { Id = 6, Number = 6, WaitTime = 3, CurrentLeg = LegType.Six, Next = LegType.Eig },
               new Leg { Id = 7, Number = 7, WaitTime = 3, CurrentLeg = LegType.Sev, Next = LegType.Eig },
               new Leg { Id = 8, Number = 8, WaitTime = 3, CurrentLeg = LegType.Eig, Next = LegType.Fou }
                );
        }
    }
}
