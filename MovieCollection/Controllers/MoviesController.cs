using Microsoft.AspNetCore.Mvc;
using MovieCollection.DTOs;
using MovieCollection.Models;
using MovieCollection.Repositories.MovieRepository;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Microsoft.AspNetCore.JsonPatch.Converters;

namespace MovieCollection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;

        public MoviesController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetMovies()
        {
            IEnumerable<MovieDTO> movies = await _movieRepository.GetMovies();
            return Ok(movies);
        }
        [HttpGet("withdetails")]
        public async Task<IActionResult> GetMoviesWithDetails()
        {
            IEnumerable<MovieWithDetailsDTO> movies = await _movieRepository.GetMoviesWithDetails();
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovie(Guid id)
        {
            Movie movie = await _movieRepository.GetMovieById(id);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }

        [HttpGet("year/{year}")]
        public async Task<IActionResult> GetMoviesByYear(int year)
        {
            IEnumerable<MovieDTO> movies = await _movieRepository.GetMoviesByYear(year);
            return Ok(movies);
        }

        [HttpGet("groupbygenreavg")]
        public IActionResult GroupByGenreAvg()
        {
            IEnumerable<GenreAvgDTO> genreAverages = _movieRepository.GroupByGenreAvg();
            return Ok(genreAverages);
        }

        [HttpPost]
        public async Task<IActionResult> AddMovie(MovieDTO movieDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _movieRepository.AddMovie(movieDTO);
            return CreatedAtAction(nameof(GetMovie), new { id = movieDTO.Guid }, movieDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovie(Guid id, MovieDTO movieDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_movieRepository.MovieExists(id))
            {
                return NotFound();
            }

            Movie updatedMovie = await _movieRepository.UpdateMovie(id, movieDTO);
            return Ok(updatedMovie);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(Guid id)
        {
            Movie movie = await _movieRepository.DeleteMovieById(id);
            if (movie == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }

}

