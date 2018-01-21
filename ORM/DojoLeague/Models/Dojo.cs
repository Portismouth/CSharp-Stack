using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace DojoLeague.Models
{
    public class Dojo : BaseEntity
    {
        public Dojo() {
            ninjas = new List<Ninja>();
        }

        [Key]
        public long Id { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "The Dojo name must be at least {1} characters!")]
        public string Name { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Please select a location!")]
        public string Location { get; set; }

        public string Description { get; set; }

        public ICollection<Ninja> ninjas { get; set; }
    }
}