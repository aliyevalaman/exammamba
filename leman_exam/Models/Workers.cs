using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace leman_exam.Models
{
    public class Workers
    {
        public int Id { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string FullName {  get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string Position {  get; set; }
        public string? ImgUrl {  get; set; }

        [NotMapped]
        public IFormFile ImgFile {  get; set; }

    }
}
