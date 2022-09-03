using Microsoft.AspNetCore.Mvc;
using PycApi.Base;
using PycApi.Service;


namespace PycApi
{
    [ApiController]
    [Route("api/nhb/[controller]")]
    public class TokenController : ControllerBase
    {
        private readonly ITokenService tokenService;

        public TokenController(ITokenService tokenService)
        {
            this.tokenService = tokenService;
        }


        [HttpPost("Login")]
        public BaseResponse<TokenResponse> Increment([FromBody] TokenRequest request)
        {
            var response = tokenService.GenerateToken(request);
            return response;
        }


    }
}
