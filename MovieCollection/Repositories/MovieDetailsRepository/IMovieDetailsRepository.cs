using MovieCollection.DTOs;
using MovieCollection.Models;

namespace MovieCollection.Repositories.MovieDetailsRepository
{
    public interface IMovieDetailsRepository
    {
        Task<MovieDetails> GetMovieDetailsById(Guid id);
        Task<IEnumerable<MovieDetailsDTO>> GetAllMovieDetails();
        Task AddMovieDetails(MovieDetailsDTO movieDetailsDTO);
        Task<MovieDetails> UpdateMovieDetails(Guid id, MovieDetailsSimpleDTO movieDetailsSimpleDTO);
        Task<MovieDetails> DeleteMovieDetails(Guid id);
        Task<IEnumerable<MovieWithDetailsDTO>> GetMoviesWithDetails();
        Task<MovieDetails> GetMovieDetailsByMovieId(Guid id);
    }
}
