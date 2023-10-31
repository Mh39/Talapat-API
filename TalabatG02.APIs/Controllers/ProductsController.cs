using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TalabatG02.APIs.Dtos;
using TalabatG02.APIs.Errors;
using TalabatG02.APIs.Helpers;
using TalabatG02.Core.Entities;
using TalabatG02.Core.Repositories;
using TalabatG02.Core.Specifications;

namespace TalabatG02.APIs.Controllers
{
    public class ProductsController : ApiBaseController
    {
        private readonly IGenericRepository<Product> productRepo;
        private readonly IGenericRepository<ProductBrand> brandRepo;
        private readonly IGenericRepository<ProductType> typeRepo;
        private readonly IMapper mapper;
        public ProductsController(IGenericRepository<Product> ProductRepo,
               IGenericRepository<ProductBrand> brandRepo,
               IGenericRepository<ProductType> typeRepo,
               IMapper mapper)
        {
            productRepo = ProductRepo;
            this.brandRepo = brandRepo;
            this.typeRepo = typeRepo;
            this.mapper = mapper;
        }
        // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //  [Authorize]
        [HttpGet]
        public async Task<ActionResult<Pagination<ProductToReturnDto>>> GetProducts([FromQuery] ProductSpecParams productSpec)
        {
            var spec = new ProductSpecification(productSpec);
            var products = await productRepo.GetAllWithSpecAsync(spec);
            var data = mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products);
            var CountSpec = new ProductWithFilterationForCountSpacification(productSpec);
            var Count = await productRepo.GetCountWithSpecAsync(CountSpec);
            return Ok(new Pagination<ProductToReturnDto>(productSpec.PageIndex, productSpec.pageSize, Count, data));

        }

        [ProducesResponseType(typeof(ProductToReturnDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {

            var spec = new ProductSpecification(id);

            var product = await productRepo.GetByIdWithSpecAsync(spec);
            if (product is null)
            {
                return NotFound(new ApiErrorResponse(404));
            }
            var MappedProduct = mapper.Map<Product, ProductToReturnDto>(product);

            return Ok(MappedProduct);

        }
        [HttpGet("brands")]//api/Products/brands
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetAllBrands()
        {
            var Brands = await brandRepo.GetAllAsync();
            return Ok(Brands);
        }
        [HttpGet("types")]//api/Products/types
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetAllTypes()
        {
            var types = await typeRepo.GetAllAsync();
            return Ok(types);
        }



    }
}
