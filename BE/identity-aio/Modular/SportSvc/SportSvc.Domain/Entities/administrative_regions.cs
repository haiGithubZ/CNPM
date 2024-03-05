using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSvc.Domain.Entities
{
    public class administrative_regions
    {
        [Key]
        public int id {  get; set; }
        public string? name { get; set; }
        public string? name_en { get; set; }
        public string? code_name { get; set;}
        public string? code_name_en { get; set; }
    }
}
