using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSvc.Domain.Entities
{
    public class Address : BaseEntity<string>
    {
        public string? UserId { get; set; }
        public string? City { get; set; }
        public string? District { get; set; }
        public string? Ward { get; set; }
        public int? Status { get; set; } //0: Mặc định, 1: Tùy chọn
    }
}
