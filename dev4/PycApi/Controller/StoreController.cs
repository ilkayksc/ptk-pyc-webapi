using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PycApi.Base;
using PycApi.Data;
using PycApi.Dto;
using PycApi.Service;

namespace PycApi.Controller
{
    [ApiController]
    [Route("api/nhb/[controller]")]
    public class StoreController: BaseController<StoreDto,Store>
    {
        private readonly IStoreService storeService;
        private readonly IMapper mapper;


        public StoreController(IStoreService storeService, IMapper mapper): base(storeService,mapper)
        {
            this.mapper = mapper;
            this.storeService = storeService;
        }


        [HttpPost("Increment")]
        public BaseResponse<StoreDto> Increment(int id)
        {
            var response = storeService.IncrementInventory(id);
            return response;
        }


    }
}
