using TalabatG02.Core.Entities;

namespace TalabatG02.Core.Specifications
{
    public class ProductSpecification : BaseSpecification<Product>
    {
        //Get
        public ProductSpecification(ProductSpecParams productSpec)
               //Where(P=>P.ProductBrandId==brandid && P.ProductTypeId == typeid)
               : base(P =>
               (string.IsNullOrEmpty(productSpec.Search) || P.Name.ToLower().Contains(productSpec.Search)) &&
              (!productSpec.brandid.HasValue || P.ProductBrandId == productSpec.brandid) &&
              (!productSpec.typeid.HasValue || P.ProductTypeId == productSpec.typeid))
        {
            Includes.Add(P => P.ProductBrand);
            Includes.Add(P => P.ProductType);
            if (!string.IsNullOrEmpty(productSpec.sort))
            {
                switch (productSpec.sort)
                {
                    case "PriceAsc":
                        AddOrderBy(P => P.Price);
                        break;
                    case "PriceDesc":
                        AddOrderByDesCending(P => P.Price);
                        break;
                    default:
                        AddOrderBy(P => P.Name);
                        break;
                }
            }
            ApplyPagination(productSpec.pageSize * (productSpec.PageIndex - 1), productSpec.pageSize);
        }
        public ProductSpecification(int id) : base(p => p.Id == id) //GetByID
        {
            Includes.Add(P => P.ProductBrand);
            Includes.Add(P => P.ProductType);
        }
    }
}
