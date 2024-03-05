using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Jhipster.Crosscutting.Constants;
using Newtonsoft.Json;

namespace Jhipster.Dto
{
    public class UserDto
    {
        public string? Id { get; set; }

        [Required]
        [RegularExpression(Constants.LoginRegex)]
        [MinLength(1)]
        [MaxLength(50)]
        public string Login { get; set; }

        public string? ReferralCode { get; set; }

        [MaxLength(50)] public string? FirstName { get; set; }
        [MaxLength(50)] public string? LastName { get; set; }

        [EmailAddress]
        [MinLength(5)]
        [MaxLength(50)]
        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        [MaxLength(256)] public string? ImageUrl { get; set; }

        public bool? Activated { get; set; }
        public string? ActivationKey { get; set; }
        private string _langKey;

        [MinLength(2)]
        [MaxLength(6)]
        public string? LangKey
        {
            get { return _langKey; }
            set { _langKey = value; if (string.IsNullOrEmpty(_langKey)) _langKey = Constants.DefaultLangKey; }
        }
        public string? City { get; set; }
        public string? District { get; set; }
        public string? Ward { get; set; }
        public int? Gender { get; set; } //0: Male, 1: Female, 2: Different
        public DateTime? DateOfBirth { get; set; }
        public string CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string LastModifiedBy { get; set; }

        public DateTime? LastModifiedDate { get; set; }

        [JsonProperty(PropertyName = "authorities")]
        [JsonPropertyName("authorities")]
        public ISet<string>? Roles { get; set; }
    }
    public class UserDtoAdmin
    {
        public int TotalCount { get; set; }
        public List<UserDto> userDtos { get; set; }
    }
    public class Response
    {
        public bool Success { get; set; }
    }
}
