using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ACME.Core.Models;

namespace ACME.DataAccess.Configurations
{
    public class ApplicationConfiguration : IEntityTypeConfiguration<Application>
    {
        public void Configure(EntityTypeBuilder<Application> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(t => t.Id)
                .IsRequired()
                .UseSqlServerIdentityColumn();

            builder.Property(t => t.CountryId)
                .IsRequired();

            builder.Property(t => t.PostcodeId)
                .HasMaxLength(50);

            builder.Property(t => t.FullName)
                .HasMaxLength(120)
                .IsRequired();

            builder.Property(t => t.DateTimeCreated)
                .HasDefaultValueSql("getutcdate()")
                .IsRequired();

            builder.ToTable("Application");
        }
    }
}