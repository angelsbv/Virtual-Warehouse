using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Almacen.Models
{
    public class Producto
    {
        [Key]
        public int IDProducto { get; set; }

        [Column(TypeName = "varchar(55)")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Nombre { get; set; }

        [Column(TypeName = "varchar(350)")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Descripcion { get; set; }

        [Column(TypeName = "int")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public int Unidad { get; set; }

        [Column(TypeName = "int")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public int Precio { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime FechaRegistro { get; set; }
    }
}
