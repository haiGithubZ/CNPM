using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSvc.Domain.Entities
{
    public class Voucher : BaseEntity<string>
    {
        public string? Name { get; set; }
        public double? Value { get; set; } //giảm bao nhiêu
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}