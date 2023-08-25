using Microsoft.EntityFrameworkCore;
using MovieCollection.Data;
using MovieCollection.DTOs;
using MovieCollection.Models;
using MovieCollection.Repositories.GenericRepository;

namespace MovieCollection.Repositories.GenreRepository
{
    public class GenreRepository : GenericRepository<Genre>, IGenreRepository
    {
        public GenreRepository(MovieCollectionContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<GenreWithGuidDTO>> GetGenres()
        {
            var g = from genres in _context.Genres
                         select new GenreWithGuidDTO
                         {
                             Id = genres.Id,
                             GenreName = genres.GenreName
                         };

            return await g.ToListAsync();
        }

        public async Task<GenreWithGuidDTO> GetGenreAsync(Guid id)
        {
            var genre = await _context.Genres
                .Where(g => g.Id == id)
                .Select(g => new GenreWithGuidDTO
                {
                    Id = g.Id,
                    GenreName = g.GenreName
                })
                .FirstOrDefaultAsync();

            return genre;
        }

        public async Task CreateGenreAsync(string s)
        {
            var genre = new Genre
            {
                GenreName= s
            };

            _context.Genres.Add(genre);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateGenreAsync(Guid id, string s)
        {
            var genre = await _context.Genres.FindAsync(id);

            if (genre != null)
            {
                genre.GenreName = s;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteGenreAsync(Guid id)
        {
            var genre = await _context.Genres.FindAsync(id);

            if (genre != null)
            {
                _context.Genres.Remove(genre);
                await _context.SaveChangesAsync();
            }
        }
    }
}
