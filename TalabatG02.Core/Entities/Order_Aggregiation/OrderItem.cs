namespace TalabatG02.Core.Entities.Order_Aggregiation
{
    public class OrderItem : BaseEntity
    { //OI=>POI =>Total 1-1 Total
        public OrderItem()
        {

        }
        public OrderItem(ProductOrderItem product, decimal price, int quantity)
        {
            Product = product;
            Price = price;
            Quantity = quantity;
        }

        public ProductOrderItem Product { get; set; }

        public decimal Price { get; set; }
        public int Quantity { get; set; }


    }
}
