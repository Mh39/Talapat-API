using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TalabatG02.Core.Entities.Order_Aggregiation;

namespace TalabatG02.Repository.Data.Configurations
{
    public class OrderItemConfigration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.OwnsOne(oi => oi.Product, Product => Product.WithOwner());
            builder.Property(oi => oi.Price)
                   .HasColumnType("decimal(18,2)");
        }
    }
}
