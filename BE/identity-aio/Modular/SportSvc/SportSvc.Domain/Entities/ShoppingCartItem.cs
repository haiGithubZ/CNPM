using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSvc.Domain.Entities
{
    public class ShoppingCartItem : BaseEntity<string>
    {
        public string? ShoppingCartId { get; set; }
        public string? ProductId { get; set; }
        public int? Quantity { get; set; }
        public double? Price { get; set; }
        public string? Size { get; set; }
        public string? Color { get; set; }
        public string? Image { get; set; }
        public string? ProductName { get; set; }
        public string? SportName { get; set; }
        public double? ProductPrice { get; set; }
    }
}