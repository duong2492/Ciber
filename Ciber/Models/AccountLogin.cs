using System.ComponentModel.DataAnnotations;

namespace Ciber.Models
{
    public class AccountLogin
    {
        [Required]
        public string? UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
