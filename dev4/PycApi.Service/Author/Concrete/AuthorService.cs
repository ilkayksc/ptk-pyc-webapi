using AutoMapper;
using NHibernate;
using PycApi.Base;
using PycApi.Data;
using PycApi.Dto;
using System;
using System.Collections.Generic;

namespace PycApi.Service
{
    public class AuthorService : BaseService<AuthorDto, Author>, IAuthorService
    {
        protected readonly ISession session;
        protected readonly IMapper mapper;
        protected readonly IHibernateRepository<Author> hibernateRepository;

        public AuthorService(ISession session, IMapper mapper) : base(session, mapper)
        {
            this.session = session;
            this.mapper = mapper;

            hibernateRepository = new HibernateRepository<Author>(session);
        }

        public override BaseResponse<IEnumerable<AuthorDto>> GetAll()
        {
            return base.GetAll();
        }

        public override BaseResponse<AuthorDto> GetById(int id)
        {
             return base.GetById(id);
        }

        public override BaseResponse<AuthorDto> Insert(AuthorDto insertResource)
        {
            return base.Insert(insertResource);
        }



    }
}
