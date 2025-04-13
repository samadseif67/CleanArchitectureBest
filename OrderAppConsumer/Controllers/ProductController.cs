using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderAppConsumer.Service;

namespace OrderAppConsumer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IVerifyrPoductService verifyrPoductService;
        public ProductController(IVerifyrPoductService verifyrPoductService)
        {
            this.verifyrPoductService = verifyrPoductService;
        }

        [HttpGet]
        public ActionResult VerifyProduct(Guid id)
        {
            var result = verifyrPoductService.Verify(new ProductDto() { id = id, Name = "Hello" });
            return Ok(result);

        }


    }
}
