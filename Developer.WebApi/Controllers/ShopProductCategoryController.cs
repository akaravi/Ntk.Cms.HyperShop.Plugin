using System.Threading.Tasks;
using Developer.WebApi.Base;
using Developer.WebApi.FilterEngine;
using Developer.WebApi.Models;
using Microsoft.AspNetCore.Mvc;



namespace Developer.WebApi.Controllers
{
    public class ShopProductCategoryController : CmsControllerBase
    {

        public ShopProductCategoryController()
        {
        }
        /// <summary>
        /// دریافت یک ردیف از دسته بندی
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/ShopProductCategory/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(string id)
        {
            var retOut = new ErrorExceptionResult<HyperShopCategoryModel>();
            retOut.Item = new HyperShopCategoryModel()
            {

                Code = "1",
                Memo = "this is test value",
                Name = "test Product",
                Image = "http://www.iran.ir/image/layout_set_logo"
            };
            

            var tcs = new TaskCompletionSource<IActionResult>();
            tcs.SetResult(Ok(retOut));
            return await tcs.Task;
        }
        /// <summary>
        /// دریافت لیست دسته بندی
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        // POST: api/ShopProductCategory
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]FilterModel model)
        {
            
            var retOut = new ErrorExceptionResult<HyperShopCategoryModel>();
            retOut.ListItems.Add(new HyperShopCategoryModel()
            {

                Code = "1",
                Memo = "this is test value",
                Name = "test Product",
                Image = "http://www.iran.ir/image/layout_set_logo"
            });

            var tcs = new TaskCompletionSource<IActionResult>();
            tcs.SetResult(Ok(retOut));
            return await tcs.Task;
        }



    }
}