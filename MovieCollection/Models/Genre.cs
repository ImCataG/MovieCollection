using MovieCollection.Models.Base;

namespace MovieCollection.Models
{
    public class Genre : BaseEntity
    {
        public string GenreName { get; set; }
        public ICollection<Movie> Movies { get; set;}
    }
}

/*
Action,
Comedy,
Drama,
Fantasy,
Horror,
Mystery,
Romance,
Thriller
*/