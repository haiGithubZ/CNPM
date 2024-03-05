using System.ComponentModel.DataAnnotations;

namespace Jhipster.Dto
{
    public class ManagedUserDto : UserDto
    {
        public const int PasswordMinLength = 6;

        public const int PasswordMaxLength = 25;

        [Required]
        [MinLength(PasswordMinLength)]
        [MaxLength(PasswordMaxLength)]
        public string Password { get; set; }

        public override string ToString()
        {
            return "ManagedUserDto{} " + base.ToString();
        }
    }
}
