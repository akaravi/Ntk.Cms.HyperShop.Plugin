using System.Threading.Tasks;
using Developer.WebApi.Base;
using Developer.WebApi.FilterEngine;
using Developer.WebApi.Models;
using Microsoft.AspNetCore.Mvc;


namespace Developer.WebApi.Controllers
{

    public class ShopBankPaymentController : CmsControllerBase
    {

        public ShopBankPaymentController()
        {
        }



        // POST: api/IsSuccess
        [Route("IsSuccess")]
        [HttpPost]
        public async Task<IActionResult> PostIsSuccessAsync([FromBody] HyperShopOrderBankPaymentIsSuccessModel model)
        {
            var retOut=new ErrorExceptionResult<HyperShopOrderModel>();


            var tcs = new TaskCompletionSource<IActionResult>();
            tcs.SetResult(Ok(retOut));
            return await tcs.Task;
        }


    }
}
