using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TalabatG02.Core.Entities.Order_Aggregiation;

namespace TalabatG02.Repository.Data.Configurations
{
    public class DeliveryMethodConfigration : IEntityTypeConfiguration<DeliveryMethod>
    {
        public void Configure(EntityTypeBuilder<DeliveryMethod> builder)
        {
            builder.Property(dm => dm.Cost)
                   .HasColumnType("decimal(18,2)");
        }
    }
}
