using Microsoft.EntityFrameworkCore;

namespace Eccomerse.DBContextApplication
{
    public class DBContextApplication1 : DbContext
    {
        public DBContextApplication1(DbContextOptions options) : base(options) { }



        public DBContextApplication1()
        {

        }

        public virtual DbSet<Model.Registration> Regitration { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<Model.Registration>();
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    // You don't actually ever need to call this
        //}

    }
}
