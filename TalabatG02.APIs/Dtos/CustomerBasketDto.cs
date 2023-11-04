using System.ComponentModel.DataAnnotations;

namespace TalabatG02.APIs.Dtos
{
    public class CustomerBasketDto
    {
        [Required]
        public string Id { get; set; }
        public List<BasketItemsDto> Items { get; set; }
    }
}
