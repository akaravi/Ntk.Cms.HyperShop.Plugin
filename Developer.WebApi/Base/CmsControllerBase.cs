using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System.Threading.Tasks;

namespace Developer.WebApi.Base
{
    [Route("/api/v1/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class CmsControllerBase : ControllerBase
    {


        [ApiExplorerSettings(IgnoreApi = true)]
        [Route("test/{id?}")]
        [HttpGet]
        public virtual async Task<IActionResult> Test(long id)
        {
            // var usrData = GetToken();

            if (id == 0)
            {
                int a = 0;
                int b = 2;
                int c = b / a;
            }


            //var aaaa = WebApiControllerIocConfig.IocConfig.GetInstance<ICoreMicroServiceConnection>() ;
            //  aaaa.RunCheck("","ssssssssssssssslam");
            string ret = "Class:" + this.GetType() + " >>>> id:" + id;
            var tcs = new TaskCompletionSource<IActionResult>();
            tcs.SetResult(Ok(ret));
            return await tcs.Task;
        }

        internal string HelperHeaderGetValue(HttpRequest CurrentRequest, string NameValue)
        {
            StringValues retOut = "";

            if (CurrentRequest != null && CurrentRequest.Headers != null && CurrentRequest.Headers.ContainsKey(NameValue))
                CurrentRequest.Headers.TryGetValue(NameValue, out retOut);

            return retOut;
        }
      
    }
}
