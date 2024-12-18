using System.ComponentModel.DataAnnotations;

namespace SampleAPI_Blazor.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Synopsis { get; set; }

        public int ReleaseYear { get; set; }

        public string Realisator { get; set; }
    }
}
