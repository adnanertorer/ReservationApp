using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reservation.DataLayer.Entities;

namespace Reservation.DataLayer.EntityConfigurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(p => p.Name).HasMaxLength(30).IsRequired();
            builder.Property(p => p.Surname).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Email).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Phone).HasMaxLength(20).IsRequired();
            builder.Property(p => p.CreatedAt).IsRequired();
        }
    }
}
