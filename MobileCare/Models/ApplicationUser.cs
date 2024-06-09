using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace MobileCare.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        [Required]
        public required string FullName { get; set; }
    }
}
