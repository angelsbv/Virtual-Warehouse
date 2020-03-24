using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Almacen.Models
{
    public class Cliente
    {
        [Key]
        public int IDCliente { get; set; }
        
        [Column(TypeName = "nvarchar(55)")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [Column(TypeName = "nvarchar(55)")]
        public string Apellido { get; set; }

        [Column(TypeName = "char(1)")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public char Sexo { get; set; }

        [Column(TypeName = "nvarchar(350)")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Direccion { get; set; }

        [Column(TypeName = "nvarchar(350)")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Email { get; set; }

        [Column(TypeName = "Date")]
        [Required(ErrorMessage = "Este campo es requerido")]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [Column(TypeName = "DateTime")]
        public DateTime FechaRegistro { get; set; }
    }
}
