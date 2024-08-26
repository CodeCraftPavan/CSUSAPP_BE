using CSUSAPP.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSUSAPP.DataAccess.DataContext
{
    public class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options) { }

        public DbSet<UsersData> UsersData { get; set; }
        public DbSet<LoginDetails> LoginDetails { get; set; }
        public DbSet<CustomerDetails> CustomerDetails { get; set; }
        public DbSet<SoldService> SoldServices { get; set; }
        public DbSet<Associates> Associates { get; set; }
        public DbSet<Services> Services { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.

                optionsBuilder.UseSqlServer("connectionString:Localhost");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerDetails>()
                .HasMany(c => c.SoldServices)
                .WithOne(s => s.CustomerDetails)
                .HasForeignKey(s => s.CustomerDetailsId);

            modelBuilder.Entity<CustomerDetails>()
                .HasMany(c => c.Associates)
                .WithOne(s => s.CustomerDetails)
                .HasForeignKey(s => s.CustomerDetailsId);
        }
    }
}
