using Microsoft.AspNetCore.Mvc;
using MovieCollection.DTOs;
using MovieCollection.Repositories.GenreRepository;

namespace MovieCollection.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenreController : ControllerBase
    {
        private readonly IGenreRepository _genreRepository;

        public GenreController(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetGenres()
        {
            IEnumerable<GenreWithGuidDTO> genres = await _genreRepository.GetGenres();
            return Ok(genres);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGenre(Guid id)
        {
            GenreWithGuidDTO genre = await _genreRepository.GetGenreAsync(id);
            if (genre == null)
            {
                return NotFound();
            }
            return Ok(genre);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGenre(string genreName)
        {
            if (string.IsNullOrWhiteSpace(genreName))
            {
                return BadRequest("Genre name cannot be empty.");
            }

            await _genreRepository.CreateGenreAsync(genreName);
            return Ok("Genre created successfully.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGenre(Guid id, string genreName)
        {
            if (string.IsNullOrWhiteSpace(genreName))
            {
                return BadRequest("Genre name cannot be empty.");
            }

            if (await _genreRepository.GetGenreAsync(id) == null)
            {
                return NotFound();
            }

            await _genreRepository.UpdateGenreAsync(id, genreName);
            return Ok("Genre updated successfully.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenre(Guid id)
        {
            if (await _genreRepository.GetGenreAsync(id) == null)
            {
                return NotFound();
            }

            await _genreRepository.DeleteGenreAsync(id);
            return Ok("Genre deleted successfully.");
        }
    }
}
