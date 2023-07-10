using Microsoft.EntityFrameworkCore;

namespace AppMVC01.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            //.....

        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //foreach (var entityType in modelBuilder.Model.GetEntityTypes()) //Loai bo tien to chu AspNet
            //{
            //    var tableName = entityType.GetTableName();
            //    if (tableName.StartsWith("AspNet"))
            //    {
            //        entityType.SetTableName(tableName.Substring(6));
            //    }

            //}
        }
        public DbSet<Contact> Contacts { get; set; }
    }
}
