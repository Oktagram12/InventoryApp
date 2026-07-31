using Microsoft.EntityFrameworkCore;
using InventoryApp.Models;

namespace InventoryApp.Data
{
    public static class SeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Warehouse>().HasData(
                new Warehouse { Id = 1, Name = "İstanbul Merkez Depo", Location = "İstanbul" },
                new Warehouse { Id = 2, Name = "Trabzon Şube Depo", Location = "Trabzon" },
                new Warehouse { Id = 3, Name = "İzmir Lojistik Merkezi", Location = "İzmir" },
                new Warehouse { Id = 4, Name = "Ankara Bölge Deposu", Location = "Ankara" },
                new Warehouse { Id = 5, Name = "Antalya Dağıtım Deposu", Location = "Antalya" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Oversize Tişört", Price = 299.99m, Description = "Pamuklu Günlük Tişört" },
                new Product { Id = 2, Name = "Koşu Ayakkabısı", Price = 1299.99m, Description = "Hafif Spor Ayakkabı" },
                new Product { Id = 3, Name = "Slim Fit Kot Pantolon", Price = 699.99m, Description = "Esnek Denim Pantolon" },
                new Product { Id = 4, Name = "Kapşonlu Sweatshirt", Price = 549.99m, Description = "Kışlık Polar Sweatshirt" },
                new Product { Id = 5, Name = "Deri Ceket", Price = 2499.99m, Description = "Hakiki Deri Mont" },
                new Product { Id = 6, Name = "Kargo Pantolon", Price = 799.99m, Description = "Çok Cepli Rahat Pantolon" },
                new Product { Id = 7, Name = "Canvas Sırt Çantası", Price = 449.99m, Description = "Günlük Kullanım Çantası" },
                new Product { Id = 8, Name = "Beyzbol Şapkası", Price = 199.99m, Description = "İşlemeli Pamuklu Şapka" },
                new Product { Id = 9, Name = "Sporcu Atleti", Price = 149.99m, Description = "Nefes Alabilir Kumaş" },
                new Product { Id = 10, Name = "Yağmurluk", Price = 899.99m, Description = "Su Geçirmez Rüzgarlık" }
            );

            modelBuilder.Entity<ProductVariant>().HasData(
                new ProductVariant { Id = 1, ProductId = 1, Color = "Siyah", Size = "S", SKU = "TIS-SIY-S" },
                new ProductVariant { Id = 2, ProductId = 1, Color = "Siyah", Size = "M", SKU = "TIS-SIY-M" },
                new ProductVariant { Id = 3, ProductId = 1, Color = "Siyah", Size = "L", SKU = "TIS-SIY-L" },
                new ProductVariant { Id = 4, ProductId = 1, Color = "Beyaz", Size = "S", SKU = "TIS-BEY-S" },
                new ProductVariant { Id = 5, ProductId = 1, Color = "Beyaz", Size = "M", SKU = "TIS-BEY-M" },
                new ProductVariant { Id = 6, ProductId = 1, Color = "Beyaz", Size = "L", SKU = "TIS-BEY-L" },
                new ProductVariant { Id = 7, ProductId = 1, Color = "Gri", Size = "M", SKU = "TIS-GRI-M" },
                new ProductVariant { Id = 8, ProductId = 1, Color = "Gri", Size = "L", SKU = "TIS-GRI-L" },
                new ProductVariant { Id = 9, ProductId = 2, Color = "Mavi", Size = "40", SKU = "AYA-MAV-40" },
                new ProductVariant { Id = 10, ProductId = 2, Color = "Mavi", Size = "42", SKU = "AYA-MAV-42" },
                new ProductVariant { Id = 11, ProductId = 2, Color = "Mavi", Size = "44", SKU = "AYA-MAV-44" },
                new ProductVariant { Id = 12, ProductId = 2, Color = "Siyah", Size = "41", SKU = "AYA-SIY-41" },
                new ProductVariant { Id = 13, ProductId = 2, Color = "Siyah", Size = "42", SKU = "AYA-SIY-42" },
                new ProductVariant { Id = 14, ProductId = 2, Color = "Siyah", Size = "43", SKU = "AYA-SIY-43" },
                new ProductVariant { Id = 15, ProductId = 3, Color = "Mavi", Size = "30/32", SKU = "PAN-MAV-30" },
                new ProductVariant { Id = 16, ProductId = 3, Color = "Mavi", Size = "32/32", SKU = "PAN-MAV-32" },
                new ProductVariant { Id = 17, ProductId = 3, Color = "Siyah", Size = "32/32", SKU = "PAN-SIY-32" },
                new ProductVariant { Id = 18, ProductId = 3, Color = "Siyah", Size = "34/32", SKU = "PAN-SIY-34" },
                new ProductVariant { Id = 19, ProductId = 4, Color = "Kırmızı", Size = "M", SKU = "SWE-KIR-M" },
                new ProductVariant { Id = 20, ProductId = 4, Color = "Kırmızı", Size = "L", SKU = "SWE-KIR-L" },
                new ProductVariant { Id = 21, ProductId = 4, Color = "Lacivert", Size = "M", SKU = "SWE-LAC-M" },
                new ProductVariant { Id = 22, ProductId = 4, Color = "Lacivert", Size = "L", SKU = "SWE-LAC-L" },
                new ProductVariant { Id = 23, ProductId = 5, Color = "Siyah", Size = "L", SKU = "CEK-SIY-L" },
                new ProductVariant { Id = 24, ProductId = 5, Color = "Kahverengi", Size = "XL", SKU = "CEK-KAH-XL" },
                new ProductVariant { Id = 25, ProductId = 6, Color = "Haki", Size = "32", SKU = "KAR-HAK-32" },
                new ProductVariant { Id = 26, ProductId = 6, Color = "Haki", Size = "34", SKU = "KAR-HAK-34" },
                new ProductVariant { Id = 27, ProductId = 7, Color = "Bej", Size = "Standart", SKU = "CAN-BEJ-STD" },
                new ProductVariant { Id = 28, ProductId = 7, Color = "Siyah", Size = "Standart", SKU = "CAN-SIY-STD" },
                new ProductVariant { Id = 29, ProductId = 8, Color = "Siyah", Size = "Ayarlanabilir", SKU = "SAP-SIY-AYR" },
                new ProductVariant { Id = 30, ProductId = 10, Color = "Sarı", Size = "L", SKU = "YAG-SAR-L" }
            );

            modelBuilder.Entity<Inventory>().HasData(
                new Inventory { Id = 1, VariantId = 1, WarehouseId = 1, CurrentStock = 25, CriticalLevel = 5 },
                new Inventory { Id = 2, VariantId = 2, WarehouseId = 1, CurrentStock = 4, CriticalLevel = 10 },
                new Inventory { Id = 3, VariantId = 3, WarehouseId = 1, CurrentStock = 50, CriticalLevel = 10 },
                new Inventory { Id = 4, VariantId = 4, WarehouseId = 1, CurrentStock = 12, CriticalLevel = 5 },
                new Inventory { Id = 5, VariantId = 5, WarehouseId = 2, CurrentStock = 8, CriticalLevel = 5 },
                new Inventory { Id = 6, VariantId = 9, WarehouseId = 2, CurrentStock = 15, CriticalLevel = 3 },
                new Inventory { Id = 7, VariantId = 10, WarehouseId = 2, CurrentStock = 2, CriticalLevel = 5 },
                new Inventory { Id = 8, VariantId = 12, WarehouseId = 3, CurrentStock = 20, CriticalLevel = 4 },
                new Inventory { Id = 9, VariantId = 15, WarehouseId = 3, CurrentStock = 30, CriticalLevel = 10 },
                new Inventory { Id = 10, VariantId = 19, WarehouseId = 4, CurrentStock = 7, CriticalLevel = 5 },
                new Inventory { Id = 11, VariantId = 23, WarehouseId = 4, CurrentStock = 3, CriticalLevel = 2 },
                new Inventory { Id = 12, VariantId = 27, WarehouseId = 5, CurrentStock = 18, CriticalLevel = 5 },
                new Inventory { Id = 13, VariantId = 30, WarehouseId = 5, CurrentStock = 9, CriticalLevel = 4 }
            );
        }
    }
}