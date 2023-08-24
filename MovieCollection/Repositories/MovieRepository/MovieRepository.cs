using Microsoft.EntityFrameworkCore;
using MovieCollection.Data;
using MovieCollection.DTOs;
using MovieCollection.Models;
using MovieCollection.Repositories.GenericRepository;
using System.Diagnostics.Eventing.Reader;

namespace MovieCollection.Repositories.MovieRepository
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieCollectionContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<MovieDTO>> getMovies()
        {
            var movies = from movie in _context.Movies
                         join movieDetails in _context.MovieDetails on movie.Id equals movieDetails.MovieId
                         select new MovieWithDetailsDTO
                         {
                             Guid = movieDetails.MovieId,
                             Title = movie.Title,
                             Description = movie.Description,
                             GenreId = movie.GenreId,
                             ReleaseDate = movie.ReleaseDate,
                             AgeRating = movieDetails.AgeRating,
                             Rating = movieDetails.Rating
                         };

            return (IEnumerable<MovieDTO>)await movies.ToListAsync();
        }

        public async Task<Movie> GetMovieAsync(Guid id)
        {
            return await FindByIdAsync(id);
        }
        public async Task<Movie> GetMovieById(Guid id)
        {
            return await FindByIdAsync(id);
        }

        public IEnumerable<GenreAvgDTO> GroupByGenreAvg()
        {
            return from movie in _context.Movies
                      group movie by movie.Genre into GenreGrouped
                      select new GenreAvgDTO
                      {
                          GenreName = GenreGrouped.Key.GenreName,
                          Avg = (int) GenreGrouped.Average(m => m.ScreenTime)
                      };
        }

        public async Task AddMovie(MovieDTO movieDTO)
        {
            var genre = _context.Genres.Single(x => x.Id == movieDTO.GenreId);
            var mv = new Movie
            {
                Title = movieDTO.Title,
                Description = movieDTO.Description,
                Genre = genre,
                ReleaseDate = movieDTO.ReleaseDate,
                ScreenTime = movieDTO.ScreenTime,
            };
            await CreateAsync(mv);
            await SaveAsync();
        }

        public async Task<Movie> DeleteMovieById(Guid id)
        {
            var movie = await FindByIdAsync(id);
            if (movie != null)
            {
                Delete(movie);
                await _context.SaveChangesAsync();
            }
            return movie;
        }

        public async Task<Movie> UpdateMovie(Guid id, MovieDTO movieDTO)
        {
            var movie = FindById(id);
            var genre = _context.Genres.Single(x => x.Id == movieDTO.GenreId);

            if (movie != null)
            {
                movie.Title = movieDTO.Title;
                movie.Description = movieDTO.Description;
                movie.ScreenTime = movieDTO.ScreenTime;
                movie.Genre = genre;
                movie.ReleaseDate = movieDTO.ReleaseDate;
                Update(movie);
                await SaveAsync();
            }
            return movie;
        }


        public bool MovieExists(Guid id)
        {
            return _context.Movies.Any(x => x.Id == id);
        }


    }
}
