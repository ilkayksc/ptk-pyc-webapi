using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PycApi.Base;

namespace PycApi
{
    [ApiController]
    [Route("api/nhb/[controller]")]
    public class AuthTestController : ControllerBase
    {
        public AuthTestController()
        {

        }

        [HttpGet("NoToken")]
        public string NoToken()
        {
            return "NoToken";
        }

        [Authorize]
        [HttpGet("WithAuthorize")]
        public string WithAuthorize()
        {
            return "WithAuthorize";
        }

        [Authorize(Roles = Role.Admin)]
        [HttpGet("Admin")]
        public string Admin()
        {
            return "Admin";
        }

        [Authorize(Roles = Role.Viewer)]
        [HttpGet("Viewer")]
        public string Viewer()
        {
            return "Viewer";
        }

        [Authorize(Roles = Role.EditorQTNS)]
        [HttpGet("EditorQTNS")]
        public string EditorQTNS()
        {
            return "EditorQTNS";
        }

        [Authorize(Roles = $"{Role.EditorQTNS},{Role.EditorQTDA}")]
        [HttpGet("EditorQTNSandEditorQTDA")]
        public string EditorQTNSandEditorQTDA()
        {
            return "EditorQTNSandEditorQTDA";
        }

        [Authorize(Roles = $"{Role.Admin},{Role.Viewer}")]
        [HttpGet("AdminViewer")]
        public string AdminViewer()
        {
            return "AdminViewer";
        }
    }
}
