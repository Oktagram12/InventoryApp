using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InventoryApp.Data;
using InventoryApp.Models;
using InventoryApp.Services;

namespace InventoryApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoriesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IEmailService _emailService;

        public InventoriesController(AppDbContext context, IEmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        [HttpGet]
        public async Task<IActionResult> GetInventories()
        {
            var inventories = await _context.Inventories
                .Include(i => i.Warehouse)        
                .Include(i => i.ProductVariant)   
                .ToListAsync();

            return Ok(inventories);
        }

        [HttpPost]
        public async Task<IActionResult> AddInventory([FromBody] Inventory inventory)
        {
            _context.Inventories.Add(inventory);
            await _context.SaveChangesAsync();
            return Created("", inventory);
        }

        [HttpPost("update-stock")]
        public async Task<IActionResult> UpdateStock(int variantId, int warehouseId, int newStock)
        {
            var inv = await _context.Inventories
                .Include(i => i.Warehouse) 
                .FirstOrDefaultAsync(i => i.VariantId == variantId && i.WarehouseId == warehouseId);

            if (inv == null)
            {
                return NotFound("Depoda ürün bulunamadı.");
            }

            if (newStock < 0)
            {
                return BadRequest("Stok adedi sıfırdan küçük olamaz.");
            }

            inv.CurrentStock = newStock;
            await _context.SaveChangesAsync();

            if (inv.CurrentStock <= inv.CriticalLevel)
            {
                string subject = $"🚨 Kritik Stok Uyarısı: {inv.Warehouse?.Name}";
                string bod = $@"
                    <html>
                    <body>
                        <h3>DİKKAT STOK AZALDI</h3>
                        <p>{inv.Warehouse?.Name} deposundaki ürün kritik seviyeye düştü.</p>
                        <p><strong>Güncel Stok:</strong> {inv.CurrentStock}</p>
                        <p><strong>Kritik Limit:</strong> {inv.CriticalLevel}</p>
                    </body>
                    </html>";

                await _emailService.SendEmailAsync("atakanakyz6181@gmail.com", subject, bod);
                Console.WriteLine("Mail atıldı, stok kritik seviyede!");
            }

            return Ok(inv);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInventory(int id, Inventory inventory)
        {
            if (id != inventory.Id) return BadRequest("URL'deki ID ile gönderilen envanterin ID'si eşleşmiyor.");

            _context.Entry(inventory).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            if (inventory.CurrentStock <= inventory.CriticalLevel)
            {
                if (inventory.Warehouse == null)
                {
                    await _context.Entry(inventory).Reference(i => i.Warehouse).LoadAsync();
                }

                string subject = $"🚨 Kritik Stok Uyarısı: {inventory.Warehouse?.Name}";
                string message = $@"
                    <html>
                    <body>
                        <h3>DİKKAT STOK AZALDI</h3>
                        <p>{inventory.Warehouse?.Name} deposundaki envanter (ID: {id}) manuel güncellemeyle kritik seviyeye düştü.</p>
                        <p><strong>Güncel Stok:</strong> {inventory.CurrentStock}</p>
                        <p><strong>Kritik Limit:</strong> {inventory.CriticalLevel}</p>
                    </body>
                    </html>";

                await _emailService.SendEmailAsync("atakanakyz6181@gmail.com", subject, message);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventory(int id)
        {
            var inventory = await _context.Inventories.FindAsync(id);
            if (inventory == null) return NotFound("Silinecek envanter kaydı bulunamadı.");

            _context.Inventories.Remove(inventory);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}