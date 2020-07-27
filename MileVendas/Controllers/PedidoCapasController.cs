using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using MileVendas.Context;
using MileVendas.Models;

namespace MileVendas.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PedidoCapasController : ApiController
    {
        private MVContext db = new MVContext();

        // GET: api/PedidoCapas
        public IQueryable<PedidoCapa> GetPedidoCapas()
        {
            return db.PedidoCapas;
        }

        // GET: api/PedidoCapas/5
        [ResponseType(typeof(PedidoCapa))]
        public IHttpActionResult GetPedidoCapa(int id)
        {
            PedidoCapa pedidoCapa = db.PedidoCapas.Find(id);
            if (pedidoCapa == null)
            {
                return NotFound();
            }

            return Ok(pedidoCapa);
        }

        // PUT: api/PedidoCapas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPedidoCapa(int id, PedidoCapa pedidoCapa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pedidoCapa.Id)
            {
                return BadRequest();
            }

            db.Entry(pedidoCapa).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidoCapaExists(id))
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

        // POST: api/PedidoCapas
        [ResponseType(typeof(PedidoCapa))]
        public IHttpActionResult PostPedidoCapa(PedidoCapa pedidoCapa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PedidoCapas.Add(pedidoCapa);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pedidoCapa.Id }, pedidoCapa);
        }

        // DELETE: api/PedidoCapas/5
        [ResponseType(typeof(PedidoCapa))]
        public IHttpActionResult DeletePedidoCapa(int id)
        {
            PedidoCapa pedidoCapa = db.PedidoCapas.Find(id);
            if (pedidoCapa == null)
            {
                return NotFound();
            }

            db.PedidoCapas.Remove(pedidoCapa);
            db.SaveChanges();

            return Ok(pedidoCapa);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PedidoCapaExists(int id)
        {
            return db.PedidoCapas.Count(e => e.Id == id) > 0;
        }
    }
}