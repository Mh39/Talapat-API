namespace TalabatG02.Core.Entities
{
    public class CustomerBasket
    {
        public CustomerBasket(string id)
        {
            Id = id;
        }

        public string Id { get; set; } //basket1
        public List<BasketItem> Items { get; set; }
    }
}
