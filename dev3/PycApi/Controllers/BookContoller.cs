﻿using Microsoft.AspNetCore.Mvc;
using PycApi.Context;
using PycApi.Model;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PycApi.Controllers
{
    [ApiController]
    [Route("api/nhb/[controller]")]
    public class BookContoller : ControllerBase
    {
        private readonly IMapperSession session;
        public BookContoller(IMapperSession session)
        {
            this.session = session;
        }

        [HttpGet]
        public List<Book> Get()
        {
            List<Book> result = session.Books.ToList();
            return result;
        }


        [HttpGet("{id}")]
        public Book Get(int id)
        {
            Book result = session.Books.Where(x => x.Id == id).FirstOrDefault();
            return result;
        }

        [HttpPost]
        public void Post([FromBody] Book book)
        {
            try
            {
                session.BeginTransaction();
                session.Save(book);
                session.Commit();
            }
            catch (Exception ex)
            {
                session.Rollback();
                Log.Error(ex, "Book Insert Error");
            }
            finally
            {
                session.CloseTransaction();
            }
        }

        [HttpPut]
        public ActionResult<Book> Put([FromBody] Book request)
        {
            Book book = session.Books.Where(x => x.Id == request.Id).FirstOrDefault();
            if (book == null)
            {
                return NotFound();
            }

            try
            {
                session.BeginTransaction();

                book.Author = request.Author;
                book.Title = request.Title;
                book.Genre = request.Genre;
                book.PageCount = request.PageCount;

                session.Update(book);

                session.Commit();
            }
            catch (Exception ex)
            {
                session.Rollback();
                Log.Error(ex, "Book Insert Error");
            }
            finally
            {
                session.CloseTransaction();
            }


            return Ok();
        }


        [HttpDelete("{id}")]
        public ActionResult<Book> Delete(int id)
        {
            Book book = session.Books.Where(x => x.Id == id).FirstOrDefault();
            if (book == null)
            {
                return NotFound();
            }

            try
            {
                session.BeginTransaction();
                session.Delete(book);
                session.Commit();
            }
            catch (Exception ex)
            {
                session.Rollback();
                Log.Error(ex, "Book Insert Error");
            }
            finally
            {
                session.CloseTransaction();
            }

            return Ok();
        }


    }
}
