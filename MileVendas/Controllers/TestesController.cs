using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MileVendas.Context;
using MileVendas.Models;

namespace MileVendas.Controllers
{
    public class TestesController : ApiController
    {
        private MVContext db = new MVContext();

        // GET: api/Testes
        public IQueryable<Teste> GetTestes()
        {
            return db.Testes;
        }

        // GET: api/Testes/5
        [ResponseType(typeof(Teste))]
        public IHttpActionResult GetTeste(int id)
        {
            Teste teste = db.Testes.Find(id);
            if (teste == null)
            {
                return NotFound();
            }

            return Ok(teste);
        }

        // PUT: api/Testes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTeste(int id, Teste teste)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != teste.Id)
            {
                return BadRequest();
            }

            db.Entry(teste).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TesteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Testes
        [ResponseType(typeof(Teste))]
        public IHttpActionResult PostTeste(Teste teste)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Testes.Add(teste);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = teste.Id }, teste);
        }

        // DELETE: api/Testes/5
        [ResponseType(typeof(Teste))]
        public IHttpActionResult DeleteTeste(int id)
        {
            Teste teste = db.Testes.Find(id);
            if (teste == null)
            {
                return NotFound();
            }

            db.Testes.Remove(teste);
            db.SaveChanges();

            return Ok(teste);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TesteExists(int id)
        {
            return db.Testes.Count(e => e.Id == id) > 0;
        }
    }
}