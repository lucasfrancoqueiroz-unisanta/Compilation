using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Compilation.Models
{
    public class UserProfile
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Nome")]
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? Occupation { get; set; }
        public string? Education { get; set; }
    }
}
