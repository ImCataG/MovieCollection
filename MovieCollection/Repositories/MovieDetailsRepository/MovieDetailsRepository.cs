using Microsoft.EntityFrameworkCore;
using MovieCollection.Data;
using MovieCollection.DTOs;
using MovieCollection.Enums;
using MovieCollection.Models;
using MovieCollection.Repositories.GenericRepository;

namespace MovieCollection.Repositories.MovieDetailsRepository
{
    public class MovieDetailsRepository : GenericRepository<MovieDetails>, IMovieDetailsRepository
    {

        public MovieDetailsRepository(MovieCollectionContext dbContext) : base(dbContext)
        {
        }

        public async Task<MovieDetails> GetMovieDetailsById(Guid id)
        {
            return await FindByIdAsync(id);
        }

        public async Task<MovieDetails> GetMovieDetailsByMovieId(Guid id)
        {
            return await _context.MovieDetails
                            .FirstOrDefaultAsync(x => x.MovieId == id);
        }

        public async Task<IEnumerable<MovieDetailsDTO>> GetAllMovieDetails()
        {
            return await _context.MovieDetails
                .Select(md => new MovieDetailsDTO
                {
                    Id = md.Id,
                    MovieId = md.MovieId,
                    AgeRating = md.AgeRating,
                    Rating = md.Rating
                })
                .ToListAsync();
        }

        public async Task AddMovieDetails(MovieDetailsDTO movieDetailsDTO)
        {
            var movieDetails = new MovieDetails
            {
                MovieId = movieDetailsDTO.MovieId,
                AgeRating = movieDetailsDTO.AgeRating, 
                Rating = movieDetailsDTO.Rating
            };
            _context.MovieDetails.Add(movieDetails);
            await _context.SaveChangesAsync();
        }

        public async Task<MovieDetails> UpdateMovieDetails(Guid id, MovieDetailsSimpleDTO movieDetailsSimpleDTO)
        {
            var existingMovieDetails = FindById(id);
            if (existingMovieDetails != null)
            {
                existingMovieDetails.MovieId = movieDetailsSimpleDTO.MovieId;
                existingMovieDetails.AgeRating = (AgeRating)Enum.Parse(typeof(AgeRating), movieDetailsSimpleDTO.AgeRating);
                existingMovieDetails.Rating = movieDetailsSimpleDTO.Rating;

                await _context.SaveChangesAsync();
                return existingMovieDetails;
            }
            return existingMovieDetails;
        }

        public async Task<MovieDetails> DeleteMovieDetails(Guid id)
        {
            var existingMovieDetails = FindById(id);
            if (existingMovieDetails != null)
            {
                _context.MovieDetails.Remove(existingMovieDetails);
                await _context.SaveChangesAsync();
                return existingMovieDetails;
            }
            return existingMovieDetails;
        }

        public async Task<IEnumerable<MovieWithDetailsDTO>> GetMoviesWithDetails()
        {
            return await _context.MovieDetails
                .Include(md => md.Movie) // Include the related Movie entity
                .Select(md => new MovieWithDetailsDTO
                {
                    Guid = md.Id,
                    Title = md.Movie.Title,
                    Description = md.Movie.Description,
                    ScreenTime = md.Movie.ScreenTime,
                    GenreId = md.Movie.GenreId,
                    ReleaseDate = md.Movie.ReleaseDate,
                    AgeRating = md.AgeRating,
                    Rating = md.Rating

                })
                .ToListAsync();

        }
    }
}
