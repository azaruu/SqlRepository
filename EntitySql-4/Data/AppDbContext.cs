using EntitySql_4.Model;
using Microsoft.EntityFrameworkCore;

namespace EntitySql_4.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options) { }

     public DbSet<Detail> Details { get; set; }
     public   DbSet<Student> Students { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Detail>()
                .HasOne(D => D.Student)
                .WithOne()
                .HasForeignKey<Detail>(s=>s.StudentId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
