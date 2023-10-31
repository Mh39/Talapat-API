using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TalabatG02.APIs.Errors;
using TalabatG02.Repository.Data;

namespace TalabatG02.APIs.Controllers
{
   
    public class BuggyController : ApiBaseController
    {
        private readonly StoreContext context;

        public BuggyController(StoreContext context)
        {
            this.context = context;
        }
        [HttpGet("notfound")]// https://localhost:7260/api/Buggy/notfound

        public ActionResult GetNotFoundRequest() 
        {
            var Product = context.products.Find(100);
            if (Product is  null)
            {
                return NotFound(new ApiErrorResponse(404));
            }
            return Ok(Product);
        }
        [HttpGet("servererror")]// https://localhost:7260/api/Buggy/servererror

        public ActionResult GetServerError()
        {
            var Product = context.products.Find(100);
            var ProducttoReturn = Product.ToString();//Will Throw Exception
            return Ok(ProducttoReturn);
        }
        [HttpGet("badRequest")]// https://localhost:7260/api/Buggy/badRequest

        public ActionResult GetBadRequestError()
        {
            
            return BadRequest(new ApiErrorResponse(400));
        }
        [HttpGet("badRequest/{id}")]// https://localhost:7260/api/Buggy/badRequest/Five

        public ActionResult GetBadRequest(int id)
        {

            return Ok();
        }
    }
}
