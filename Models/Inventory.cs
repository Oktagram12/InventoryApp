using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryApp.Models
{
    public class Inventory
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ProductVariant")]
        public int VariantId { get; set; }
        public ProductVariant? ProductVariant { get; set; }

        [ForeignKey("Warehouse")]
        public int WarehouseId { get; set; }
        public Warehouse? Warehouse { get; set; }

        public int CurrentStock { get; set; } 

        public int CriticalLevel { get; set; } 
    }
}