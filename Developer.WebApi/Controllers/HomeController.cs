using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;
using Developer.WebApi.Base;

namespace Developer.WebApi.Controllers
{
    public class HomeController : CmsControllerBase
    {
        [HttpPost]
        [HttpGet]
        [Route("/")]
        public IActionResult Home()
        {
            return new ContentResult
            {
                ContentType = "text/html",
                StatusCode = (int)HttpStatusCode.OK,
                Content = "Api Developer Is Run (now : " + DateTime.Now + ")"
            };
        }
        [HttpPost]
        [HttpGet]
        [Route("/date")]
        public async Task<IActionResult> HomeDateAsync()
        {
            var retOut = new { DateTime = DateTime.UtcNow };
            var tcs = new TaskCompletionSource<IActionResult>();
            tcs.SetResult(Ok(retOut));
            return await tcs.Task;
        }

    }
}
