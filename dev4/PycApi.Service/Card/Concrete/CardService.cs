using AutoMapper;
using NHibernate;
using PycApi.Data;
using PycApi.Dto;

namespace PycApi.Service
{
    public class CardService : BaseService<CardDto, Card>, ICardService
    {
        protected readonly ISession session;
        protected readonly IMapper mapper;
        protected readonly IHibernateRepository<Card> hibernateRepository;

        public CardService(ISession session, IMapper mapper) : base(session, mapper)
        {
            this.session = session;
            this.mapper = mapper;

            hibernateRepository = new HibernateRepository<Card>(session);
        }
           



    }
}
