using MovieCollection.Models.Base;
using System.Text.Json.Serialization;

namespace MovieCollection.Models
{
    public class Role : BaseEntity
    {
        public Guid ActorId { get; set; }
        public Guid MovieId { get; set; }
        [JsonIgnore]
        public Actor Actor { get; set; }
        [JsonIgnore]
        public Movie Movie { get; set; }
        public string ActorName { get; set; }
        public string CharacterName { get; set; }

        
    }
}
