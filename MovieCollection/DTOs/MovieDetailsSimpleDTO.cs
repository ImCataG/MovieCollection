using MovieCollection.Enums;

namespace MovieCollection.DTOs
{
    public class MovieDetailsSimpleDTO
    {
        public Guid MovieId { get; set; }
        public string AgeRating { get; set; }
        public float Rating { get; set; }
    }
}
