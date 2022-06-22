using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test2.Models
{
    public class TestDbContext : DbContext
    {
        public TestDbContext()
        {

        }

        public TestDbContext(DbContextOptions options) : base(options)
        {

        }


        public DbSet<Car> Cars { get; set; }
        public DbSet<Inspection> Inspections { get; set; }
        public DbSet<Mechanic> Mechanics { get; set; }
        public DbSet<ServiceTypeDict> ServiceTypeDicts { get; set; }
        public DbSet<ServiseTypeDict_Inspection> ServiseTypeDict_Inspections { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Car>(e =>
            {
                e.HasData(new Car { IdCar = 1, Name = "BMW", ProductionYear = 2020 });
            });

            modelBuilder.Entity<Mechanic>(e =>
            {
                e.HasData(new Mechanic { IdMechanic = 1, FirstName = "Jon", LastName = "Doe" });
            });

            modelBuilder.Entity<ServiceTypeDict>(e =>
            {
                e.HasData(new ServiceTypeDict { IdServiceType = 1, ServiceType = "Full", Price = 100.56F });
            });

            modelBuilder.Entity<Inspection>(e =>
            {
                e.HasData(new Inspection { IdInspection = 1, IdCar = 1, IdMechanic = 1, InspectionDate = new DateTime(2022, 01, 01), Comment = "ababa" });
            });

            modelBuilder.Entity<ServiseTypeDict_Inspection>(e =>
            {
                e.HasKey(x => new { x.IdInspection, x.IdServiceType });
                e.HasData(new ServiseTypeDict_Inspection { IdServiceType = 1, IdInspection = 1, Comments = "xyxyx" });
            });
        }
    }
}
