using Oie.DataAccess.DbSets;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oie.DataAccess
{
    public class OieDbContext : DbContext
    {
        public OieDbContext()
            : base("OieDbContext")
        {
            Database.SetInitializer<OieDbContext>(new CreateDatabaseIfNotExists<OieDbContext>());
            Database.Log = (log) => Debug.WriteLine(log);
        }

        public DbSet<FakeDepartment> FakeDepartments { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<AirportPickup> AirportPickups { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
