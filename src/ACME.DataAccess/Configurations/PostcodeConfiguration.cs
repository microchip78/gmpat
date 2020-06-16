using ACME.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ACME.DataAccess.Configurations
{
    public class PostcodeConfiguration : IEntityTypeConfiguration<Postcode>
    {
        public void Configure(EntityTypeBuilder<Postcode> builder)
        {
            builder.HasKey(o => o.ID);

            builder.Property(t => t.ID)
                .IsRequired()
                .UseSqlServerIdentityColumn();

            builder.Property(t => t.Pcode)
                .HasMaxLength(50);

            builder.Property(t => t.Locality)
                .HasMaxLength(50);

            builder.Property(t => t.State)
                .HasMaxLength(50);

            builder.Property(t => t.Comments)
                .HasMaxLength(50);

            builder.Property(t => t.DeliveryOffice)
                .HasMaxLength(50);

            builder.Property(t => t.PreSortIndicator)
                .HasMaxLength(50);

            builder.Property(t => t.ParcelZone)
                .HasMaxLength(50);

            builder.Property(t => t.BSPnumber)
                .HasMaxLength(50);

            builder.Property(t => t.BSPname)
                .HasMaxLength(50);

            builder.Property(t => t.Category)
                .HasMaxLength(50);

            builder.ToTable("Postcodes");
        }
    }
}