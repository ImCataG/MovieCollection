using MovieCollection.Models.Base;

namespace MovieCollection.Models
{
    public class Actor : BaseEntity
    {
        public string Name { get; set; }
        public string Age {  get; set; }
        public ICollection<Role> Roles { get; set; }

    }
}
