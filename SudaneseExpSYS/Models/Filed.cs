using System.ComponentModel.DataAnnotations;

namespace SudaneseExpSYS.Models
{
    public class Filed
    {
        [Key]
        public int FId { get; set; }
        [Required]
        [StringLength(100)]
        public string? FName { get; set; }
    }
}
