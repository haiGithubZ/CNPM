using SportSvc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSvc.Application.DTO
{
    public class StatisticsDTO
    {
        public double? Revenue { get; set; }
        public List<SportDTO>? CountProductOfSport { get; set; }
        public List<Product>? ListProductBestSell { get; set; }
    }

    public class SportDTO
    {
        public string? Name { get; set; }
        public int? CountProduct { get; set; }
    }
}
