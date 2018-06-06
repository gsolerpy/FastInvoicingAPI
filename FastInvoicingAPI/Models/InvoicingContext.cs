using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FastInvoicingAPI.Models
{
    public class InvoicingContext : DbContext
    {
        public InvoicingContext() :  base("name=FXEContext")
        {

        }

        public DbSet<Factura> Facturas { get; set; }
        public DbSet<FacturaDetalle> FacturaDetalles { get; set; }
    }
}