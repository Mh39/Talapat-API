using AutoMapper;
using TalabatG02.APIs.Dtos;
using TalabatG02.Core.Entities;

namespace TalabatG02.APIs.Helpers
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(PD => PD.ProductBrand, O => O.MapFrom(P => P.ProductBrand.Name))
                .ForMember(PD => PD.ProductType, O => O.MapFrom(P => P.ProductType.Name))
               .ForMember(PD => PD.PictureUrl, O => O.MapFrom<ProductPictureUrlResolver>());


        }
    }
}
