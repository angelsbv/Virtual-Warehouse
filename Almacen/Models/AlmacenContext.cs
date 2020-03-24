using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Almacen.Models
{
    public class AlmacenContext:DbContext
    {
        public AlmacenContext(DbContextOptions<AlmacenContext> options):base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Producto> Productos { get; set; }
        
        public DbSet<Empleado> Empleados { get; set; }

        public DbSet<VentaProductos> VentaProductos { get; set; }
    }
}
