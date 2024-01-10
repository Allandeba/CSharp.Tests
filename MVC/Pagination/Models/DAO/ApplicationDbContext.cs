using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pagination.Models;

namespace Pagination.Models.DAO
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ApplicationDbContext(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlite(_configuration.GetConnectionString("default"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuarios>().HasKey(x => x.Id);
            modelBuilder.Entity<Usuarios>().Property(x => x.Id).ValueGeneratedOnAdd();

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Usuarios> Usuarios { get; set; }
    }
}
