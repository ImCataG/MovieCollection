using MovieCollection.Enums;
using MovieCollection.Models.Base;

namespace MovieCollection.Models
{
    public class MovieDetails : BaseEntity
    {
        public Movie Movie { get; set; }
        public Guid MovieId { get; set; }
        public AgeRating AgeRating { get; set; }
        public float Rating { get; set; }
    }
}
