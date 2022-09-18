using System.Threading.Tasks;
using TechaApiIdentity.Application.Shared;
using TechaApiIdentity.Base;
using TechaApiIdentity.Data;

namespace TechaApiIdentity.Application
{
    public interface IPostService : ICRUDService<PostDto,CreatePostDto,UpdatePostDto,ApplicationUser>
    {
        Task<ApplicationResult<PostDto>> GetByUrl(string categoryUrl, string postUrl);
    }
}
