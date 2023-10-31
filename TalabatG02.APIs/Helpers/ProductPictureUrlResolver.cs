using AutoMapper;
using TalabatG02.APIs.Dtos;
using TalabatG02.Core.Entities;

namespace TalabatG02.APIs.Helpers
{
    public class ProductPictureUrlResolver : IValueResolver<Product,ProductToReturnDto,string>
    {
        private readonly IConfiguration configuration;

        public ProductPictureUrlResolver(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public string Resolve(Product source, ProductToReturnDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
            
               return $"{configuration["ApiBaseUrl"]}{source.PictureUrl}";
              //  return $"{"https://localhost:7260/"}{source.PictureUrl}";

                return string.Empty ;
            
        }
    }
}
