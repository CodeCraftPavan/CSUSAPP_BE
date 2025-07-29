// <copyright file="AppDataContext.cs" company="Canarys Automations Ltd">
// Copyright (c) Canarys Automations Ltd. All rights reserved.
// </copyright>

using CSUSAPP.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace CSUSAPP.DataAccess.DataContext
{
    /// <summary>
    /// Represents the application data context for Entity Framework Core.
    /// </summary>
    public class AppDataContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppDataContext"/> class with the specified options.
        /// </summary>
        /// <param name="options">options.</param>
        public AppDataContext(DbContextOptions<AppDataContext> options)
            : base(options)
        {
        }

        public DbSet<UsersData> UsersData { get; set; }
        public DbSet<LoginDetails> LoginDetails { get; set; }
        public DbSet<CustomerDetails> CustomerDetails { get; set; }
        public DbSet<SoldService> SoldServices { get; set; }
        public DbSet<Associates> Associates { get; set; }
        public DbSet<Services> Services { get; set; }

        /// <summary>
        /// Configures the database context options for the application.
        /// </summary>
        /// <param name="optionsBuilder">optionsBuilder.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.

                optionsBuilder.UseSqlServer("connectionString:Localhost");
            }
        }

        /// <summary>
        /// Configures the model for the application data context.
        /// </summary>
        /// <param name="modelBuilder">modelBuilder.</param>
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
