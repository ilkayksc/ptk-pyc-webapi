using AutoMapper;
using NHibernate;
using PycApi.Base;
using PycApi.Data;
using PycApi.Dto;
using System;

namespace PycApi.Service
{
    public class StoreService : BaseService<StoreDto, Store>, IStoreService
    {

        protected readonly ISession session;
        protected readonly IMapper mapper;
        protected readonly IHibernateRepository<Store> hibernateRepository;

        public StoreService(ISession session, IMapper mapper) : base(session, mapper)
        {
            this.session = session;
            this.mapper = mapper;

            hibernateRepository = new HibernateRepository<Store>(session);
        }



        public BaseResponse<StoreDto> IncrementInventory(int id)
        {
            try
            {
                var tempEntity = hibernateRepository.GetById(id);
                if (tempEntity is null)
                {
                    return new BaseResponse<StoreDto>("Record Not Found");
                }

                tempEntity.Inventory++;

                hibernateRepository.BeginTransaction();
                hibernateRepository.Update(tempEntity);
                hibernateRepository.Commit();
                hibernateRepository.CloseTransaction();

                var resource = mapper.Map<Store, StoreDto>(tempEntity);
                return new BaseResponse<StoreDto>(resource);
            }
            catch (Exception ex)
            {
                hibernateRepository.Rollback();
                hibernateRepository.CloseTransaction();
                return new BaseResponse<StoreDto>(ex.Message);
            }
        }

    }
}
