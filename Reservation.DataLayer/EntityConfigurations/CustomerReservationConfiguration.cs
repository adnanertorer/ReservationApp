using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reservation.DataLayer.Entities;

namespace Reservation.DataLayer.EntityConfigurations
{
    public class CustomerReservationConfiguration : IEntityTypeConfiguration<CustomerReservation>
    {
        public void Configure(EntityTypeBuilder<CustomerReservation> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(p => p.CustomerId).IsRequired();
            builder.Property(p => p.TableId).IsRequired();
            builder.Property(p => p.GuestCount).IsRequired();
            builder.Property(p => p.ReservationDate).IsRequired();
            builder.Property(p => p.CreatedAt).IsRequired();
            builder.HasOne(i => i.Customer).WithMany(i => i.CustomerReservations).
            HasForeignKey(i => i.CustomerId);
            builder.HasOne(i => i.Table).WithMany(i => i.CustomerReservations).
            HasForeignKey(i => i.TableId);
        }
    }
}
