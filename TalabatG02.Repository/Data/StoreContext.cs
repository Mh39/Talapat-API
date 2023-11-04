using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TalabatG02.Core.Entities;
using TalabatG02.Core.Entities.Order_Aggregiation;

namespace TalabatG02.Repository.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }

        public DbSet<Product> products { get; set; }
        public DbSet<ProductBrand> productBrands { get; set; }
        public DbSet<ProductType> productTypes { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderItem> ordersItems { get; set; }
        public DbSet<DeliveryMethod> DeliveryMethods { get; set; }



    }
}
