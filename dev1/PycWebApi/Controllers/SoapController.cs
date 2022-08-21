using Microsoft.AspNetCore.Mvc;
using N11CategoryServiceReference;
using System.Threading.Tasks;

namespace PycWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoapController : ControllerBase
    {
        public SoapController()
        {

        }


        [HttpGet]
        public async Task<string> Get()
        {
            CategoryServicePortClient service = new CategoryServicePortClient();
            GetTopLevelCategoriesRequest request = new GetTopLevelCategoriesRequest();
            request.auth = new N11CategoryServiceReference.Authentication();
            request.auth.appKey = "key";
            request.auth.appSecret = "secret";
            GetTopLevelCategoriesResponse1 response = await service.GetTopLevelCategoriesAsync(request);
            if (response.GetTopLevelCategoriesResponse.result.status != "1")
            {
                return "Error";
            }

            return "Patika";
        }

    }
}
