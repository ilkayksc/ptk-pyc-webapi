using Microsoft.AspNetCore.Authorization;
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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        private readonly UserManager<ApplicationUser> userManager;

        public CategoryController(ICategoryService categoryService, UserManager<ApplicationUser> userManager)
        {
            this.categoryService = categoryService;
            this.userManager = userManager;
        }

        private Task<ApplicationUser> GetCurrentUserAsync()
        {
            return userManager.GetUserAsync(HttpContext.User);
        }

        [HttpGet]
        [Authorize]
        public async Task<ApplicationResult<List<CategoryDto>>> Get()
        {
            var user = await GetCurrentUserAsync();
            return await categoryService.GetAll(user);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<ApplicationResult<CategoryDto>>> Get(int id)
        {
            var user = await GetCurrentUserAsync();
            var result = await categoryService.Get(id,user);
            if (result.Succeeded)
                return result;
            return NotFound(result);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ApplicationResult>> Post([FromBody] CreateCategoryDto input)
        {
            var user = await GetCurrentUserAsync();
            var result = await categoryService.Create(input,user);
            if (result.Succeeded)
                return result;

            return NotFound(result);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ApplicationResult> Put([FromBody] UpdateCategoryDto request)
        {
            var user = await GetCurrentUserAsync();
            var result = await categoryService.Update(request, user);
            return result;
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ApplicationResult> Delete(int id)
        {
            var user = await GetCurrentUserAsync();
            var result = await categoryService.Delete(id, user);
            return result;
        }

    }
}
