using Microsoft.AspNetCore.Mvc;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PycApi.Controllers
{
    [ApiController]
    [Route("api/nhb/[controller]")]
    public class AuthorController : ControllerBase
    {

        private readonly ISession session;
        public AuthorController(ISession session)
        {
            this.session = session;
        }


        [HttpGet]
        public List<Author> Get()
        {
            var response = session.Query<Author>().ToList();
            return response;
        }

        [HttpGet("{id}")]
        public Author Get(string id)
        {
            var response = session.Query<Author>().Where(x => x.Id == id).FirstOrDefault();
            return response;
        }

        [HttpPost]
        public Author Post([FromBody] Author request)
        {
           
            using(var transaction = session.BeginTransaction())
            {
                var author = new Author();
                author.Id = Guid.NewGuid().ToString();
                author.FirstName = request.FirstName;
                author.LastName = request.LastName;


                session.Save(author);
                transaction.Commit();
                
                return author;
            }

        }

    }
}
