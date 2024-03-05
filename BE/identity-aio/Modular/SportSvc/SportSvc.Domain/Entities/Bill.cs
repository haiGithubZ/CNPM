using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSvc.Domain.Entities
{
    public class Bill : BaseEntity<string>
    {
        public string? Code { get; set; }
        public string? InformationDelivery { get; set; }
        public string? UserId { get; set; }
        public List<string>? ShoppingCartItemId { get; set; }
        public double? Ship { get; set; }
        public double? ValueVoucher { get; set; }
        public double? TotalMoney { get; set; }
        public int? Status { get; set; }
        public string? DeliveryName { get; set; }
        public string? AddressId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

    }
}
