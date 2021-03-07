using System.Threading.Tasks;
using Developer.WebApi.Base;
using Developer.WebApi.FilterEngine;
using Developer.WebApi.Models;
using Microsoft.AspNetCore.Mvc;


namespace Developer.WebApi.Controllers
{

    public class ShopProductContentController : CmsControllerBase
    {

        public ShopProductContentController()
        {
        }

        /// <summary>
        /// درافت یک ردیف از اطلاعات محصول
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/ShopProductContent/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(string id)
        {
            var retOut = new ErrorExceptionResult<HyperShopContentModel>();
            retOut.Item = new HyperShopContentModel()
            {
                Category = "1",
                CategoryCode = "1",
                Code = "aaaa",
                Memo = "this is test value",
                Name = "test Product",
                Price = 1000,
                Sale = true,
                Description = "ddd",
                Brand = "Golrang",
                SalePrice = 1000,
                Count = 2,
                Status = true,
                Image = "http://www.iran.ir/image/layout_set_logo"
            };

            var tcs = new TaskCompletionSource<IActionResult>();
            tcs.SetResult(Ok(retOut));
            return await tcs.Task;
        }
        /// <summary>
        /// دریافت لیست محصول
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        // POST: api/ShopProductContent
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] FilterModel model)
        {
            var retOut = new ErrorExceptionResult<HyperShopContentModel>();
            retOut.ListItems.Add(new HyperShopContentModel()
            {
                Category = "1",
                CategoryCode = "1",
                Code = "aaaa",
                Memo = "this is test value",
                Name = "test Product",
                Price = 1000,
                Sale = true,
                Description = "ddd",
                Brand = "Golrang",
                SalePrice = 1000,
                Count = 2,
                Status = true,
                Image = "http://www.iran.ir/image/layout_set_logo"
            });

            var tcs = new TaskCompletionSource<IActionResult>();
            tcs.SetResult(Ok(retOut));
            return await tcs.Task;
        }


    }
}
