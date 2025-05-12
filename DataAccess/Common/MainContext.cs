using DataAccess.Interface;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Common
{
    public class MainContext : DbContext, IMainContext
    {        
        public DbSet<Owner> Owner { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Property> Property { get; set; }
        public DbSet<PropertyImage> PropertyImage { get; set; }
        public DbSet<PropertyTrace> PropertyTrace { get; set; }        


        public MainContext(DbContextOptions<MainContext> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
