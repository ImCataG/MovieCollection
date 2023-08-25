using MovieCollection.DTOs;
using MovieCollection.Models;
using MovieCollection.Repositories.GenericRepository;

namespace MovieCollection.Repositories.MovieRepository
{
    public interface IMovieRepository : IGenericRepository<Movie>
    {
        Task<IEnumerable<MovieDTO>> GetMovies();
        Task<IEnumerable<MovieWithDetailsDTO>> GetMoviesWithDetails();
        Task<IEnumerable<MovieDTO>> GetMoviesByYear(int year);
        Task<Movie> GetMovieById(Guid id);
        Task AddMovie(MovieDTO movieDTO);
        Task<Movie> DeleteMovieById(Guid id);
        Task<Movie> UpdateMovie(Guid id, MovieDTO movieDTO);
        public bool MovieExists(Guid id);
        IEnumerable<GenreAvgDTO> GroupByGenreAvg();

    }
}
