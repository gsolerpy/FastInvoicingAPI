using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FastInvoicingAPI.Models
{
    /// <summary>
    /// Tabla Factura
    /// </summary>
    public class Factura
    {
        /// <summary>
        /// Clave primaria de la tabla Factura
        /// </summary>
        [Key]
        public long IdFactura { get; set; }

        /// <summary>
        /// Número de factura
        /// </summary>
        public long NroFactura { get; set; } 

        /// <summary>
        /// Fecha de la factura
        /// </summary>
        public DateTime Fecha { get; set; }

        /// <summary>
        /// Tipo de venta Contado=> CO, 
        /// </summary>
        public string TipoVenta { get; set; }

        /// <summary>
        /// Ruc del cliente
        /// </summary>
        public string Ruc { get; set; }

        /// <summary>
        /// Razon social del cliente
        /// </summary>
        public string Cliente { get; set; }

        /// <summary>
        /// Colección detalle
        /// </summary>
        public ICollection<FacturaDetalle> Detalle { get; set; }
    }
}