using Jhipster.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSvc.Domain.Entities
{
    public class Country : BaseEntity<string>
    {
        public string? Country_name { get; set; }
    }
}
