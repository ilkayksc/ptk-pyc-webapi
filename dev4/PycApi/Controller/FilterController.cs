using Microsoft.AspNetCore.Mvc;
using PycApi.Base;

namespace PycApi.Controller;

[ApiController]
[Route("api/nhb/[controller]")]
public class FilterController : ControllerBase
{

    public FilterController()
    {

    }



    [HttpGet("FilterAttribute")]
    [ResponseHeaderAttribute("Denny","Sellen")]
    public string FilterAttribute()
    {
        return "FilterAttribute";
    }



    [TypeFilter(typeof(ConsoledAuthorizationFilter))]
    [TypeFilter(typeof(ConsoledResourceFilter))]
    [TypeFilter(typeof(ConsoledActionFilter))]
    [TypeFilter(typeof(ConsoledResultFilter))]
    [HttpGet("Filters")]
    public string Filters()
    {
        return "Exception";
    }


}
