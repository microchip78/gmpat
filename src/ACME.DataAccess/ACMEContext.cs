using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ACME.Core.Models;
using ACME.DataAccess.Seeds;

namespace ACME.DataAccess
{
    public class ACMEContext : DbContext
    {
        public DbSet<Application> Applications { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Postcode> Postcodes { get; set; }

        public ACMEContext()
        {
        }

        public ACMEContext(DbContextOptions<ACMEContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile(Core.Constants.AppSettingsFileName)
                .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString(Core.Constants.DefaultConnectionStringKeyName));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ACMEContext).GetTypeInfo().Assembly);
            modelBuilder.InitializeData();
        }
    }
}