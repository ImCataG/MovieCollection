using MovieCollection.Models.Base;

namespace MovieCollection.DTOs
{
    public class GenreWithGuidDTO
    {
        public Guid Id { get; set; }
        public string GenreName { get; set; }
    }
}
