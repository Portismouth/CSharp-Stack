using System.ComponentModel.DataAnnotations;

namespace DojoLeague.Models
{
    public class Ninja : BaseEntity
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "The Dojo name must be at least {1} characters!")]
        public string Name { get; set; }

        [Required]
        public int Level { get; set; }

        public string Description { get; set; }

        public Dojo dojo { get; set; }

        public int DojoId { get; set; }
        public string DojoName { get; set;}
    }
}