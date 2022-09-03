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
        private readonly IMapper mapper;


        public AuthorController(IAuthorService authorService, IMapper mapper)
        {
            this.authorService = authorService;
            this.mapper = mapper;
        }


        [HttpGet]
        public BaseResponse<IEnumerable<AuthorDto>> GetAll()
        {
            var response = authorService.GetAll();
            return response;
        }

        [HttpGet("{id}")]
        public BaseResponse<AuthorDto> GetById(int id)
        {
            var response = authorService.GetById(id);
            return response;
        }

        [HttpDelete("{id}")]
        public BaseResponse<AuthorDto> Delete(int id)
        {
            var response = authorService.Remove(id);
            return response;
        }

        [HttpPost]
        public BaseResponse<AuthorDto> Create([FromBody] AuthorDto dto)
        {
            var response = authorService.Insert(dto);
            return response;
        }

        [HttpPut("{id}")]
        public BaseResponse<AuthorDto> Update(int id, [FromBody] AuthorDto dto)
        {
            var response = authorService.Update(id, dto);
            return response;
        }
    }
}
