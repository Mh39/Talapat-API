using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TalabatG02.Core.Entities.Order_Aggregiation;

namespace TalabatG02.Repository.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.OwnsOne(o => o.ShippingAddress, sa => sa.WithOwner());
            builder.Property(o => o.Status)
                .HasConversion(
                os => os.ToString(),
                os => (OrderStatus)Enum.Parse(typeof(OrderStatus), os));
            builder.Property(o => o.SubTotal)
                .HasColumnType("decimal(18,2)");

            builder.HasOne(o => o.deliveryMethod)
            .WithMany()
            .OnDelete(DeleteBehavior.SetNull);


        }
    }
}
