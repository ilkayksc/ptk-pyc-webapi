using AutoMapper;
using NHibernate;
using PycApi.Base;
using PycApi.Data;
using PycApi.Dto;
using Serilog;
using System;

namespace PycApi.Service
{
    public class PersonService : BaseService<PersonDto, Person>, IPersonService
    {

        protected readonly ISession session;
        protected readonly IMapper mapper;
        protected readonly IHibernateRepository<Person> hibernateRepositoryPerson;
        protected readonly IHibernateRepository<PersonInfo> hibernateRepositoryPersonInfo;

        public PersonService(ISession session, IMapper mapper) : base(session, mapper)
        {
            this.session = session;
            this.mapper = mapper;

            hibernateRepositoryPerson = new HibernateRepository<Person>(session);
            hibernateRepositoryPersonInfo = new HibernateRepository<PersonInfo>(session);
        }


        public override BaseResponse<PersonDto> Insert(PersonDto insertResource)
        {
            try
            {
                var person = mapper.Map<PersonDto, Person>(insertResource);
                var personInfo = person.PersonInfo;

                person.PersonInfo = null;
                hibernateRepositoryPerson.BeginTransaction();
                hibernateRepositoryPerson.Save(person);
                hibernateRepositoryPerson.Commit();
                hibernateRepositoryPerson.CloseTransaction();


                personInfo.Person = person;
                hibernateRepositoryPersonInfo.BeginTransaction();
                hibernateRepositoryPersonInfo.Save(personInfo);
                hibernateRepositoryPersonInfo.Commit();
                hibernateRepositoryPersonInfo.CloseTransaction();

                return new BaseResponse<PersonDto>(mapper.Map<Person, PersonDto>(person));
            }
            catch (Exception ex)
            {
                Log.Error("PersonService.Insert", ex);
                hibernateRepositoryPerson.Rollback();
                hibernateRepositoryPerson.CloseTransaction();
                return new BaseResponse<PersonDto>(ex.Message);
            }

        }



    }
}
