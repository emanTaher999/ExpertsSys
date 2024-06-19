using System.ComponentModel.DataAnnotations;

namespace SudaneseExpSYS.Models
{
    public class State
    {
        [Key]
        public int SId { get; set; }
        [Required]
        [StringLength(200)]
        public string? SName { get; set; }
    }
}
