using Microsoft.EntityFrameworkCore;
using bulutbilisim.Model;

namespace bulutbilisim.DB
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User_Tb> User { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Fluent API kullanarak tablo adını belirt
            modelBuilder.Entity<User_Tb>().ToTable("User_Tb", schema: "dbo");

            //modelBuilder.Entity<Users>().HasNoKey();
            //modelBuilder.Entity<Items>().HasNoKey();
        }
    }
}
