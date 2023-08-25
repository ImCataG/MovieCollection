using MovieCollection.DTOs;
using MovieCollection.Models;
using MovieCollection.Repositories.GenericRepository;

namespace MovieCollection.Repositories.GenreRepository
{
    public interface IGenreRepository : IGenericRepository<Genre>
    {
        Task<IEnumerable<GenreWithGuidDTO>> GetGenres();
        Task<GenreWithGuidDTO> GetGenreAsync(Guid id);
        Task CreateGenreAsync(string s);
        Task UpdateGenreAsync(Guid id, string s);
        Task DeleteGenreAsync(Guid id);
    }
}
