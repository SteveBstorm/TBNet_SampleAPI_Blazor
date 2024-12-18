using System.ComponentModel.DataAnnotations;

namespace SampleAPI_Blazor.Models
{
    public class MovieDTO
    {
        [Required]
        public string Title { get; set; }
        [MinLength(50)]
        public string Synopsis { get; set; }
        [Range(1970, int.MaxValue)]
        public int ReleaseYear { get; set; }
        [Required]
        public string Realisator { get; set; }
    }
}
