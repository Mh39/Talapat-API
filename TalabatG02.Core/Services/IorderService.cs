using TalabatG02.Core.Entities.Order_Aggregiation;

namespace TalabatG02.Core.Services
{
    public interface IorderService
    {
        Task<Order> GetOrderAsync(string BuyerEmail, string BasketId, int delivaryMethodId, Entities.Order_Aggregiation.Address ShippingAddress);
        Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string BuyerEmail);
        Task<Order> GetOrdersByIdForUserAsync(int orderId, string BuyerEmail);
    }
}
