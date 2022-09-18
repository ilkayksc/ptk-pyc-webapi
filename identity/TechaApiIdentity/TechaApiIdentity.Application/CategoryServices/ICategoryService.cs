using TechaApiIdentity.Application.Shared;
using TechaApiIdentity.Data;

namespace TechaApiIdentity.Application
{
    public interface ICategoryService :ICRUDService<CategoryDto,CreateCategoryDto,UpdateCategoryDto, ApplicationUser>
    {
       
    }
}
