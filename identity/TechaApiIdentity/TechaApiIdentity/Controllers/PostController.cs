using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechaApiIdentity.Application;
using TechaApiIdentity.Base;
using TechaApiIdentity.Data;


namespace TechaApiIdentity
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IPostService postService;

        public PostController(IPostService postService, UserManager<ApplicationUser> userManager)
        {
            this.postService = postService;
            this.userManager = userManager;
        }


        [HttpGet]
        [Authorize]
        public async Task<ApplicationResult<List<PostDto>>> Get()
        {
            var user = await GetCurrentUserAsync();
            return await postService.GetAll(user);
        }


        [HttpGet("{id}")]
        [Authorize]

        public async Task<ActionResult<ApplicationResult<PostDto>>> Get(int id)
        {
            var user = await GetCurrentUserAsync();
            var result = await postService.Get(id, user);
            if (result.Succeeded)
                return result;

            return NotFound(result);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ApplicationResult>> Post([FromBody] CreatePostDto input)
        {
            var user = await GetCurrentUserAsync();
            var result = await postService.Create(input,user);
            if (result.Succeeded)
                return result;
            return NotFound(result);
        }


        [HttpPut("{id}")]
        [Authorize]
        public async Task<ApplicationResult> Put([FromBody] UpdatePostDto request)
        {
            var user = await GetCurrentUserAsync();
            var result = await postService.Update(request,user);
            return result;
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ApplicationResult> Delete(int id)
        {
            var user = await GetCurrentUserAsync();
            var result = await postService.Delete(id, user);
            return result;
        }


        private Task<ApplicationUser> GetCurrentUserAsync()
        {
            return userManager.GetUserAsync(HttpContext.User);
        }
    }
}
