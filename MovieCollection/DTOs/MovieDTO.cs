using MovieCollection.Models;

namespace MovieCollection.DTOs
{
    public class MovieDTO
    {
        public Guid? Guid { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public int ScreenTime { get; set; }
        public Guid GenreId { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
