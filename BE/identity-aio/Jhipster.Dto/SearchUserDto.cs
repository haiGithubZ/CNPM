using System;
namespace Jhipster.Dto
{
    public class SearchUserDto
    {
        public string? Username { get; set; }
        public string? Fullname { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? IsActived { get; set; }
        public string? Role { get; set; }
        public string? ReferralCode { get; set; }
        public DateTime CreateDate { get; set; }
        //public DateTime? ActiveDate { get; set; }
    }
}

