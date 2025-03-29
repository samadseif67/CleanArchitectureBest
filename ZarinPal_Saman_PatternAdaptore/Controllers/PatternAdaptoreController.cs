using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZarinPal_Saman_PatternAdaptore.Services;

namespace ZarinPal_Saman_PatternAdaptore.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PatternAdaptoreController : ControllerBase
    {

        //this project working dotnet 8

        public ActionResult ZarinPalPayment([FromKeyedServices("ZarinpalKey")] IPaymentAdapter paymentAdapter )
        {
            return Ok(paymentAdapter.Pay());
        }

        public ActionResult SamanBankPayment([FromKeyedServices("SamanBankKey")] IPaymentAdapter paymentAdapter)
        {
            return Ok(paymentAdapter.Pay());
        }


    }
}
