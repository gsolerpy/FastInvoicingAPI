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
using FastInvoicingAPI.Models;

namespace FastInvoicingAPI.Controllers
{
    /// <summary>
    /// Controlador para las operaciones CRUD a la tabla Factura
    /// </summary>
    public class FacturasController : ApiController
    {
        private InvoicingContext db = new InvoicingContext();

        // GET: api/Facturas
        /// <summary>
        /// Método GET para obtener todas las facturas 
        /// </summary>
        /// <returns></returns>
        public IQueryable<Factura> GetFacturas()
        {
            return db.Facturas;
        }

        // GET: api/Facturas/5
        /// <summary>
        /// Método para obtener una factura por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(Factura))]
        public IHttpActionResult GetFactura(long id)
        {
            Factura factura = db.Facturas.Find(id);
            if (factura == null)
            {
                return NotFound();
            }

            return Ok(factura);
        }

        // PUT: api/Facturas/5
        /// <summary>
        /// Método para actualizar un registro en la tabla Factura
        /// </summary>
        /// <param name="id"></param>
        /// <param name="factura"></param>
        /// <returns></returns>
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFactura(long id, Factura factura)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != factura.IdFactura)
            {
                return BadRequest();
            }

            db.Entry(factura).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacturaExists(id))
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

        // POST: api/Facturas
        /// <summary>
        /// Método para insertar un nuevo registro en la tabla Factura
        /// </summary>
        /// <param name="factura"></param>
        /// <returns></returns>
        [ResponseType(typeof(Factura))]
        public IHttpActionResult PostFactura(Factura factura)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Facturas.Add(factura);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = factura.IdFactura }, factura);
        }

        // DELETE: api/Facturas/5
        /// <summary>
        /// Método para eliminar un registro de la tabla Factura
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(Factura))]
        public IHttpActionResult DeleteFactura(long id)
        {
            Factura factura = db.Facturas.Find(id);
            if (factura == null)
            {
                return NotFound();
            }

            db.Facturas.Remove(factura);
            db.SaveChanges();

            return Ok(factura);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FacturaExists(long id)
        {
            return db.Facturas.Count(e => e.IdFactura == id) > 0;
        }
    }
}