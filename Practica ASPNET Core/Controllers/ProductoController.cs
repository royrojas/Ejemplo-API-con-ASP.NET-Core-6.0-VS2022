using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practica_ASPNET_Core.Context;
using Practica_ASPNET_Core.Models;

namespace Practica_ASPNET_Core.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly MyDbContext _context;

        public ProductsController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetProducto")]
        public ActionResult<IEnumerable<Producto>> GetAll()
        {
            return _context.Productos.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Producto> GetById(int id)
        {
            var product = _context.Productos.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return product;
        }

        [HttpPost]
        public ActionResult<Producto> Create(Producto producto)
        {
            _context.Productos.Add(producto);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = producto.Id }, producto);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, Producto product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Producto> Delete(int id)
        {
            var product = _context.Productos.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Productos.Remove(product);
            _context.SaveChanges();
            return product;
        }
    }
}
