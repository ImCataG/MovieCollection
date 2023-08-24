using MovieCollection.Models.Base;

namespace MovieCollection.Models
{
    public class Movie : BaseEntity
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public Genre Genre { get; set; }
        public Guid GenreId { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int ScreenTime { get; set; }
        public MovieDetails? MovieDetails { get; set; }
        public ICollection<Role> Roles { get; set; }

    }
}
