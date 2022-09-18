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
    public class PersonController : BaseController<PersonDto, Person>
    {
        private readonly IPersonService PersonService;
        private readonly IMapper mapper;


        public PersonController(IPersonService PersonService, IMapper mapper) : base(PersonService, mapper)
        {
            this.mapper = mapper;
            this.PersonService = PersonService;
        }


    }
}
