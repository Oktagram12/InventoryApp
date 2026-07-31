using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InventoryApp.Data;
using InventoryApp.Models;

namespace InventoryApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductVariantsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductVariantsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetVariants()
        {
            var variants = await _context.ProductVariants.ToListAsync();
            return Ok(variants);
        }

        [HttpPost]
        public async Task<IActionResult> CreateVariant([FromBody] ProductVariant variant)
        {
            _context.ProductVariants.Add(variant);
            await _context.SaveChangesAsync();

            return Created("", variant);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductVariant(int id, ProductVariant variant)
        {
            if (id != variant.Id) return BadRequest("URL'deki ID ile gönderilen varyantın ID'si eşleşmiyor.");

            _context.Entry(variant).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductVariant(int id)
        {
            var variant = await _context.ProductVariants.FindAsync(id);
            if (variant == null) return NotFound("Silinecek varyant bulunamadı.");

            _context.ProductVariants.Remove(variant);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}