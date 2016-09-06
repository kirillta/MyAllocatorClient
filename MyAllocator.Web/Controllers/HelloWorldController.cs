using System.Threading.Tasks;
using System.Web.Http;
using MyAllocator.Client;
using MyAllocator.Client.Models;

namespace MyAllocator.Web.Controllers
{
    public class HelloWorldController : ApiController
    {
        public HelloWorldController()
        {
            _client = new MyAllocatorClient();
        }


        public async Task<IHttpActionResult> Get()
        {
            var helloWorld = new HelloWorld
            {
                Hello = "World"
            };
            var result = await _client.GetHelloWorldResult(helloWorld);    

            return Json(result);
        }


        private readonly MyAllocatorClient _client;
    }
}
