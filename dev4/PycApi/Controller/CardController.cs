using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PycApi.Base;
using PycApi.Dto;
using PycApi.Service;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace PycApi
{
    
    [ApiController]
    [Route("api/nhb/[controller]")]
    public class CardController : ControllerBase
    {
        private readonly ICardService cardService;
        private readonly IMapper mapper;


        public CardController(ICardService cardService, IMapper mapper)
        {
            this.mapper = mapper;
            this.cardService = cardService;
        }



        [Authorize]
        [HttpGet]
        public List<CardDto> GetAll()
        {
            var accounId = (User.Identity as ClaimsIdentity).FindFirst("AccountId").Value;

            var response = cardService.GetAll();
            var result = response.Response.Where(x => x.AccountId == int.Parse(accounId)).ToList();

            return result;
        }

        [Authorize]
        [HttpGet("{id}")]
        public BaseResponse<CardDto> GetById(int id)
        {
            var response = cardService.GetById(id);
            return response;
        }

        [Authorize]
        [HttpDelete("{id}")]
        public BaseResponse<CardDto> Delete(int id)
        {
            var response = cardService.Remove(id);
            return response;
        }

        [Authorize]
        [HttpPost]
        public BaseResponse<CardDto> Create([FromBody] CardDto dto)
        {
            var accounId = (User.Identity as ClaimsIdentity).FindFirst("AccountId").Value;
            dto.AccountId = int.Parse(accounId);
            var response = cardService.Insert(dto);
            return response;
        }

        [Authorize]
        [HttpPut("{id}")]
        public BaseResponse<CardDto> Update(int id, [FromBody] CardDto dto)
        {
            var response = cardService.Update(id, dto);
            return response;
        }



    }
}
