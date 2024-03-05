using SportSvc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSvc.Application.DTO
{
    public class AddressDTO
    {
        public string? Id { get; set; }
        public string? UserId { get; set; }
        public string? City { get; set; }
        public string? District { get; set; }
        public string? Ward { get; set; }
        public int? Status { get; set; } //0: Mặc định, 1: Tùy chọn
    }
    public class CityDTO
    {
        public string? code { get; set; }
        public string? full_name { get; set; }
    }
    public class DistrictDTO
    {
        public string? code { get; set; }
        public string? full_name { get; set; }
    }

    public class WardDTO
    {
        public string? code { get; set; }
        public string? full_name { get; set; }
    }

    public class ViewShoppingCartDTO
    {
        public string Id { get; set; }
        public List<ShoppingCartItem>? listShoppingCartItem { get; set; }
        public int Quantity { get; set; }
        public double IntoMonney { get; set; }
        public string? VoucherCode { get; set; }
    }
    public class Information
    {
        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; } 
        public string? City { get; set; }
        public string? District { get; set; }
        public string? Ward { get; set;}
    }
}
