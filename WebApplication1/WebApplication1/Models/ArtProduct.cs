using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace WebApplication1.Models
{
    public class ArtProduct
    {
        [Key]
        public Guid ArtId { get; set; }
        public string? ArtName { get; set; }
        public string? ArtDesc { get; set; }
        public float? ArtPrice { get; set; }
        public bool? isAvailable { get; set; } //sold or available
        public string? ArtDimensions { get; set; }
        public int? ArtScore { get; set; }

        [NotMapped]
        public IFormFile? imgFile { get; set; }
        public byte[]? imgBytes { get; set; }

    }
}
