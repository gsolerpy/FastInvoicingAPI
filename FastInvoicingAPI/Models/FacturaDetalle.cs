using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FastInvoicingAPI.Models
{
    public class FacturaDetalle
    {
        [Key]
        public long IdFacturaDetalle { get; set; }
        public int Cantidad { get; set; }
        public string Detalle { get; set; }
        public decimal PrecionUnitario { get; set; }
        public decimal Total { get; set; }

        public Factura Cabecera { get; set; }
    }
}