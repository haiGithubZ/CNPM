using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSvc.Domain.Entities
{
    public class Sport : BaseEntity<string>
    {
        public string? Name { get; set; }
    }
}
