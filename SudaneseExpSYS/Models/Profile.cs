using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SudaneseExpSYS.Models
{
    public class Profile
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public float NationalId { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Sex { get; set; }
        [Required]
        public DateTime BrithDay { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Phone { get; set; }

        [ForeignKey("Country")]
        public int CId { get; set; }
        public Country? Country { get; set; }

        [ForeignKey("State")]
        public int SId { get; set; }
        public State? state { get; set; }


        [ForeignKey("Filed")]
        public int FId { get; set; }
        public  Filed? Filed{ get; set; }
        public string? Achievement { get; set; }

        public DateTime ExitDay { get; set; }

        [NotMapped]
        public IFormFile? ClientFile { get; set; }
        public byte[]? dbImage { get; set; }

        [NotMapped]
        public string? imageSrc
        {
            get
            {
                if (dbImage != null)
                {
                    string base64String = Convert.ToBase64String(dbImage, 0, dbImage.Length);
                    return "data:image/jpg;base64," + base64String;

                }
                else
                {
                    return string.Empty;
                }
            }
        }

        public DateTime CreatedDay { get; set; } = DateTime.Now;

    }
}
