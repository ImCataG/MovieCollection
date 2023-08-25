using Microsoft.AspNetCore.Mvc;
using MovieCollection.DTOs;
using MovieCollection.Enums;
using MovieCollection.Repositories.MovieDetailsRepository;

namespace MovieCollection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieDetailsController : ControllerBase
    {
        private readonly IMovieDetailsRepository _movieDetailsRepository;

        public MovieDetailsController(IMovieDetailsRepository movieDetailsRepository)
        {
            _movieDetailsRepository = movieDetailsRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDetailsDTO>> GetMovieDetailsById(Guid id)
        {
            var movieDetails = await _movieDetailsRepository.GetMovieDetailsById(id);
            if (movieDetails == null)
            {
                return NotFound();
            }
            return Ok(movieDetails);
        }
        [HttpGet("byMovieId/{id}")]
        public async Task<ActionResult<MovieDetailsDTO>> GetMovieDetailsByMovieId(Guid id)
        {
            var movieDetails = await _movieDetailsRepository.GetMovieDetailsByMovieId(id);
            if (movieDetails == null)
            {
                return NotFound();
            }
            return Ok(movieDetails);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDetailsDTO>>> GetAllMovieDetails()
        {
            var movieDetails = await _movieDetailsRepository.GetAllMovieDetails();
            return Ok(movieDetails);
        }

        [HttpPost]
        public async Task<ActionResult> AddMovieDetails(MovieDetailsSimpleDTO movieDetailsSimpleDTO)
        {
            var movieDetailsDTO = new MovieDetailsDTO
            {
                MovieId = movieDetailsSimpleDTO.MovieId,
                AgeRating = (AgeRating)Enum.Parse(typeof(AgeRating), movieDetailsSimpleDTO.AgeRating),
                Rating = movieDetailsSimpleDTO.Rating
            };
            await _movieDetailsRepository.AddMovieDetails(movieDetailsDTO);

            return CreatedAtAction(nameof(GetMovieDetailsByMovieId), new { id = movieDetailsDTO.MovieId }, movieDetailsDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<MovieDetailsDTO>> UpdateMovieDetails(Guid id, MovieDetailsSimpleDTO movieDetailsSimpleDTO)
        {
            
            var updatedMovieDetails = await _movieDetailsRepository.UpdateMovieDetails(id, movieDetailsSimpleDTO);
            if (updatedMovieDetails == null)
            {
                return NotFound();
            }
            return Ok(updatedMovieDetails);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<MovieDetailsDTO>> DeleteMovieDetails(Guid id)
        {
            var deletedMovieDetails = await _movieDetailsRepository.DeleteMovieDetails(id);
            if (deletedMovieDetails == null)
            {
                return NotFound();
            }
            return Ok(deletedMovieDetails);
        }

        [HttpGet("movieswithdetails")]
        public async Task<ActionResult<IEnumerable<MovieWithDetailsDTO>>> GetMoviesWithDetails()
        {
            var moviesWithDetails = await _movieDetailsRepository.GetMoviesWithDetails();
            return Ok(moviesWithDetails);
        }
    }
}
