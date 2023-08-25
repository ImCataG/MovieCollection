using MovieCollection.Enums;

namespace MovieCollection.DTOs
{
    public class MovieDetailsDTO
    {
        public Guid? Id { get; set; }
        public Guid MovieId { get; set; }
        public AgeRating AgeRating { get; set; }
        public float Rating { get; set; }
    }
}
