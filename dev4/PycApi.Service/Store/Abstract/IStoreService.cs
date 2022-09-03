using PycApi.Base;
using PycApi.Data;
using PycApi.Dto;

namespace PycApi.Service
{
    public interface IStoreService : IBaseService<StoreDto, Store>
    {
        BaseResponse<StoreDto> IncrementInventory(int id);
    }
}
