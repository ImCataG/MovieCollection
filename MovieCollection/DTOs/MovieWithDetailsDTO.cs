using MovieCollection.Enums;
using MovieCollection.Models;

namespace MovieCollection.DTOs
{
    public class MovieWithDetailsDTO
    {
        public Guid? Guid { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public int ScreenTime { get; set; }
        public Guid GenreId { get; set; }
        public DateTime ReleaseDate { get; set; }
        public AgeRating AgeRating { get; set; }
        public float Rating { get; set; }
    }
}
