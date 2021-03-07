using System.Threading.Tasks;
using Developer.WebApi.Base;
using Developer.WebApi.Models;
using Microsoft.AspNetCore.Mvc;


namespace Developer.WebApi.Controllers
{
 
    public class ShopOrderController : CmsControllerBase
    {

        public ShopOrderController()
        {
        }

        /// <summary>
        /// ثبت سبد خرید جدید
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        // POST: api/ShopOrder
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] HyperShopOrderModel model)
        {
            var retOut = new ErrorExceptionResult<HyperShopOrderModel>();


            var tcs = new TaskCompletionSource<IActionResult>();
            tcs.SetResult(Ok(retOut));
            return await tcs.Task;
        }

       /// <summary>
       /// ویرایش سبد خرید
       /// </summary>
       /// <param name="id"></param>
       /// <param name="value"></param>
       /// <returns></returns>
        // PUT: api/ShopOrder/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] HyperShopOrderModel value)
        {
            var retOut = new ErrorExceptionResult<HyperShopOrderModel>();


            var tcs = new TaskCompletionSource<IActionResult>();
            tcs.SetResult(Ok(retOut));
            return await tcs.Task;
        }


    }
}
