using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSvc.Domain.Entities
{
    public class Promotion : BaseEntity<string>
    {
        public string? PromotionId { get; set; }
        public string? ProductId { get; set; }
        public string? PromotionName { get; set; }
        public double? Discount { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}