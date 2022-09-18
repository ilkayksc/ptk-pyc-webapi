using System.Collections.Generic;
using System.Threading.Tasks;
using TechaApiIdentity.Base;

namespace TechaApiIdentity.Application.Shared
{
    public interface ICRUDService<MainDto,CreateDto,UpdateDto,ApplicationUser>
    {
        Task<ApplicationResult<MainDto>> Get(int id, ApplicationUser applicationUser);
        Task<ApplicationResult<List<MainDto>>> GetAll(ApplicationUser applicationUser);
        Task<ApplicationResult> Create(CreateDto input, ApplicationUser applicationUser);
        Task<ApplicationResult> Update(UpdateDto input, ApplicationUser applicationUser);
        Task<ApplicationResult> Delete(int id, ApplicationUser applicationUser);
    }
}
