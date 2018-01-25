using System.ComponentModel.DataAnnotations;

namespace LostInTheWoods.Models
{
    public abstract class BaseEntity{}
    public class Trail : BaseEntity
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Trail Name must be at least {1} characters!")]
        public string Name { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Trail Name must be at least {1} characters!")]
        public string Description { get; set; }

        [Required]
        [Range(1, 5000, ErrorMessage = "Please enter a trail length!")]
        public float Length { get; set; }

        [Required]
        [Range(1, 5000)]
        public int ElevationChange { get; set; }

        [Required]
        public float Latitude { get; set; }

        [Required]
        public float Longitude { get; set; }
    }
}