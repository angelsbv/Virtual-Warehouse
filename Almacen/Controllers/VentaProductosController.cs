using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Almacen.Models;

namespace Almacen.Controllers
{
    public class VentaProductosController : Controller
    {
        private readonly AlmacenContext _context;

        public VentaProductosController(AlmacenContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var almacenContext = _context.VentaProductos.Include(v => v.cliente).Include(v => v.producto);
            return View(await almacenContext.ToListAsync());
        }

        public IActionResult AgregarVenta()
        {
            ViewData["IDCliente"] = new SelectList(_context.Clientes, "IDCliente", "Nombre");
            ViewData["IDProducto"] = new SelectList(_context.Productos, "IDProducto", "Nombre");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AgregarVenta([Bind("IDVenta,IDProducto,IDCliente,FechaVenta")] VentaProductos ventaProductos)
        {
            if (ModelState.IsValid)
            {
                ventaProductos.FechaVenta = DateTime.Now;
                var prod = getProducto(ventaProductos.IDProducto);
                if (prod.Unidad == 0)
                {
                    ModelState.AddModelError("outOf", "Ya no quedan unidades disponibles de este producto.");
                }
                else
                {
                    prod.Unidad -= 1;
                    _context.Add(ventaProductos);
                    _context.Update(prod);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewData["IDCliente"] = new SelectList(_context.Clientes, "IDCliente", "Nombre", ventaProductos.IDCliente);
            ViewData["IDProducto"] = new SelectList(_context.Productos, "IDProducto", "Nombre", ventaProductos.IDProducto);
            return View(ventaProductos);
        }

        public async Task<IActionResult> BorrarVenta(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventaProductos = await _context.VentaProductos
                .Include(v => v.cliente)
                .Include(v => v.producto)
                .FirstOrDefaultAsync(m => m.IDVenta == id);
            if (ventaProductos == null)
            {
                return NotFound();
            }

            return View(ventaProductos);
        }

        [HttpPost, ActionName("BorrarVenta")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BorrarVentaConfirmado(int id)
        {
            var ventaProductos = await _context.VentaProductos.FindAsync(id);
            var prod = getProducto(ventaProductos.IDProducto);
            prod.Unidad += 1;
            _context.Update(prod);
            _context.VentaProductos.Remove(ventaProductos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VentaProductosExists(int id)
        {
            return _context.VentaProductos.Any(e => e.IDVenta == id);
        }

        public Producto getProducto(int? IDProd)
        {
            var data = from p in _context.Productos
                       where IDProd == p.IDProducto
                       select p;

            return data.First();
        }
    }
}
