using TalabatG02.Core.Entities;
using TalabatG02.Core.Entities.Order_Aggregiation;
using TalabatG02.Core.Repositories;
using TalabatG02.Core.Services;

namespace TalabatG02.Servicre
{
    public class orderService : IorderService
    {
        private readonly IBasketRepository basketRepository;
        private readonly IGenericRepository<Product> productRepo;
        private readonly IGenericRepository<DeliveryMethod> dMRepository;
        private readonly IGenericRepository<Order> orderRepository;

        public orderService(IBasketRepository basketRepository, IGenericRepository<Product> productRepo, IGenericRepository<DeliveryMethod> DMRepository, IGenericRepository<Order> orderRepository)
        {
            this.basketRepository = basketRepository;
            this.productRepo = productRepo;
            dMRepository = DMRepository;
            this.orderRepository = orderRepository;
        }
        public async Task<Order> GetOrderAsync(string BayerEmail, string BasketId, int delivaryMethodId, Address ShippingAddress)
        {
            //1.Get Basket From Basket Repo
            var basket = await basketRepository.GetBasketAsync(BasketId);
            // 2.Get Selected Items at Basket From Product Repo
            var orderItems = new List<OrderItem>();
            if (basket?.Items?.Count > 0)
            {
                foreach (var item in basket.Items)
                {
                    var Product = await productRepo.GetBYIdlAsync(item.Id);
                    var ProductItemOrdered = new ProductOrderItem(Product.Id, Product.Name, Product.PictureUrl);
                    var OrderItem = new OrderItem(ProductItemOrdered, Product.Price, item.Quantity);
                    orderItems.Add(OrderItem);
                }
            }
            //  3.Calculate SubTotal
            var subTotal = orderItems.Sum(item => item.Price * item.Quantity);

            // 4.Get Delivery Method From DeliveryMethod Repo
            var deliveryMethod = await dMRepository.GetBYIdlAsync(delivaryMethodId);
            //5.Create Order
            var order = new Order(BayerEmail, ShippingAddress, deliveryMethod, orderItems, subTotal);
            //6.Add Order Locally
            await orderRepository.Add(order);

            //7.Save Order To Database[ToDo]

        }

        public Task<Order> GetOrdersByIdForUserAsync(int orderId, string BuyerEmail)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string BuyerEmail)
        {
            throw new NotImplementedException();
        }
    }
}
