using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductAppProvider.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet("{id}")]
        public ActionResult verify(Guid id)
        {
            ProductVerifyDto productVerifyDto = new ProductVerifyDto() { id=Guid.NewGuid(),Name= "Hello" };
            return Ok(productVerifyDto);
        }
        public class ProductVerifyDto
        {
            public Guid id { get; set; }
            public string Name { get; set; }
        }


    }
}
