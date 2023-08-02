using System.ComponentModel.DataAnnotations;

namespace Eccomerse.Model
{
    public class Registration
    {
        [Key]
        public string? MobileNumber { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Gender { get; set; }
        public long Passwoed { get; set; }
        public long Re_Password { get; set; }
    }
}
