using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reservation.DataLayer.Entities;

namespace Reservation.DataLayer.EntityConfigurations
{
    public class TableConfiguration : IEntityTypeConfiguration<Table>
    {
        public void Configure(EntityTypeBuilder<Table> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(p => p.TableName).HasMaxLength(20).IsRequired();
            builder.Property(p => p.Capacity).IsRequired();
            builder.Property(p => p.CreatedAt).IsRequired();
        }
    }
}
