using SampleAPI_Blazor.Models;

namespace SampleAPI_Blazor.Services
{
    public class MovieService
    {
        private List<Movie> movies;

        public MovieService()
        {
            movies = new List<Movie>();
            movies.Add(new Movie
            {
                Id = 1,
                Title = "Star Wars : New Hope",
                ReleaseYear = 1977,
                Realisator = "George Lucas",
                Synopsis = "Un pirate et un wookie court après la princesse pour ..."
            });
        }

        public List<Movie> GetAll() { return movies; }

        public void Add(MovieDTO movie) {  
            int newId = movies.Max(x => x.Id) + 1;
            movies.Add(
                new Movie
                {
                    Id = newId,
                    Title = movie.Title,
                    ReleaseYear = movie.ReleaseYear,
                    Realisator = movie.Realisator,
                    Synopsis = movie.Synopsis
                }); 
        }

        public Movie GetById(int id)
        {
            return movies.FirstOrDefault(x => x.Id == id);
        }

        public void Delete(int id)
        {
            movies.Remove(GetById(id));
        }
    }
}
