using TalabatG02.Core.Entities;

namespace TalabatG02.Core.Specifications
{
    public class ProductWithFilterationForCountSpacification : BaseSpecification<Product>
    {
        public ProductWithFilterationForCountSpacification(ProductSpecParams productSpec)
              : base(P =>
              (string.IsNullOrEmpty(productSpec.Search) || P.Name.ToLower().Contains(productSpec.Search)) &&
             (!productSpec.brandid.HasValue || P.ProductBrandId == productSpec.brandid) &&
             (!productSpec.typeid.HasValue || P.ProductTypeId == productSpec.typeid))
        {

        }
    }
}
