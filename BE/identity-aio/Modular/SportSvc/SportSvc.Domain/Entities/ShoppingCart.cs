using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSvc.Domain.Entities
{
    public class ShoppingCart : BaseEntity<String>
    {
        public string? UserId { get; set; }
        public List<string>? VoucherId { get; set; }
        public int? Ship { get; set; } //0: Trong HN, 1: Ngoài HN
        public int? Status { get; set; } //0: Shopping, 1: Delivery, 2: Done
        public string? DeliveryName { get; set; }
    }
}