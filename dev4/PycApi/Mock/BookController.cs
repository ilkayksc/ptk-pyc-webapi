using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PycApi.Data;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace PycApi
{
    [ApiController]
    [Route("nhb/v1/api/[controller]")]
    public class BookController : ControllerBase
    {
        private Book Book;
        private IHibernateRepository<Book> @object;


        public BookController(IHibernateRepository<Book> repository, IMapper mapper)
        {
            this.@object = repository;
        }


        public BookController(IHibernateRepository<Book> @object)
        {
            this.@object = @object;
        }

        [HttpGet]
        public  List<Book> Get()
        {
            var books = @object.GetAll();
            return books;
        }

        [HttpGet("{id}")]
        public Book GetItem(int id)
        {
            var item = @object.GetById(id);

            if (item == null)
                return null;

            return item;
        }

      

    }
}
