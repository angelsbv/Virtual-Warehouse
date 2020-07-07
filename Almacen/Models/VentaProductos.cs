using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Almacen.Models
{
    public class VentaProductos
    {
        [Key]
        public int IDVenta { get; set; }
        
        public Producto producto { get; set; }
        [ForeignKey("producto")]
        [Column(TypeName="int")]
        public int IDProducto { get; set; }

        
        public Cliente cliente { get; set; }
        [Column(TypeName = "int")]
        [ForeignKey("cliente")]
        public int IDCliente { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime FechaVenta { get; set; }
    }
}
