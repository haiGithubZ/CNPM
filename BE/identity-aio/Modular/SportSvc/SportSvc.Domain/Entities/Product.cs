using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSvc.Domain.Entities
{
    public class Product : BaseEntity<string>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public double? Price { get; set; }
        public string? SportId { get; set; }
        public string? Brand { get; set; }
        public int Quantity { get; set; }
        public int Type { get; set; } //0: Quần, 1: Áo, 2: Giày, 3: Bóng,  4: Kính bơi, 5: Sân bóng
        public List<string>? ListSize { get; set; }
        public List<string>? ListColor { get; set; }
        public string? PhoneNumber { get; set; } //stadium
        public string? Address { get; set; } //stadium
        public int? NumberSold { get; set; } //so san pham da ban
    }
}
