using ACME.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ACME.DataAccess.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasKey(o => o.CountryId);

            builder.Property(t => t.CountryId)
                .IsRequired()
                .UseSqlServerIdentityColumn();

            builder.Property(t => t.CountryName)
                .IsRequired();

            builder.Property(t => t.CountryCode)
                .IsRequired();

            builder.ToTable("Country");
        }
    }
}