using System.ComponentModel.DataAnnotations;

namespace SudaneseExpSYS.Models
{
    public class Country
    {
        [Key]
        public int CId { get; set; }

        [Required]
        [StringLength(100)]
        public string? CName { get; set; }
    }
}
