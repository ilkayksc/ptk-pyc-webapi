using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PycApi.Base;
using PycApi.Dto;
using PycApi.Service;
using System.Collections.Generic;

namespace PycApi.Controllers
{
    [ApiController]
    [Route("api/nhb/[controller]")]

    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService authorService;


        public AuthorController(IAuthorService authorService,IMapper mapper)
        {
            this.authorService = authorService;
        }

       
        [HttpGet("GetAll")]
        public BaseResponse<IEnumerable<AuthorDto>> GetAll()
        {
            var response =  authorService.GetAll();
            return response;
        }

    
    }
}
