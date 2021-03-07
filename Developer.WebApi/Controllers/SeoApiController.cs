using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Developer.WebApi.Base;

namespace Developer.WebApi.Controllers
{
    /// <summary>
    /// جهت جلوگیری از ثبت خطا در ورود ربات های موتور های سرچ
    /// </summary>
    public class SeoApiController : CmsControllerBase
    {

        [Route("/robots.txt")]
        [HttpPost]
        [HttpGet]
        public virtual async Task<IActionResult> SEOrobots()
        {
            var content = new StringBuilder("User-agent: *" + Environment.NewLine);
            content.Append("Disallow: /" + Environment.NewLine);

            return new ContentResult
            {
                ContentType = "text/html",
                StatusCode = (int)HttpStatusCode.OK,
                Content = content.ToString()
            };
        }

        [Route("/sitemap.xml")]
        [HttpPost]
        [HttpGet]
        public virtual async Task<IActionResult> SEOsitemap()
        {
            string contentHtml = @" - - - ";
            return new ContentResult
            {
                ContentType = "text/html",
                StatusCode = (int)HttpStatusCode.OK,
                Content = contentHtml
            };
        }
    }
}
