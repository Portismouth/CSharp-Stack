using System;
using System.ComponentModel.DataAnnotations;

namespace TheWall.Models
{
    public class Comment : BaseEntity
    {
        [Required]
        [MinLength(1, ErrorMessage = "Your Comment must have something in it!")]
        [Display(Name = "Comment")]
        public string Content { get; set; }
        public int MessageId { get; set; }
        public int UserId { get; set; }
    }
    public class Message : BaseEntity
    {
        [Required]
        [MinLength(1, ErrorMessage = "Your Message must have something in it!")]
        [Display(Name = "Message")]
        public string Content { get; set; }
        public int UserId { get; set; }
    }
    public class MessagingViewModel : BaseEntity
    {
        public Comment UserComment { get; set; }
        public Message UserMessage { get; set; }
    }
}
