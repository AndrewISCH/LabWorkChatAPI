using System.ComponentModel.DataAnnotations;

namespace ChatAPIWebApp.Models
{
    public class Message
    {
        public int Id { get; set; }
        public int DialogueId { get; set; }
        public virtual Dialogue Dialogue { get; set; }

        [Required]
        public string Content { get; set; }
        public int SenderId { get; set; }
        public virtual User Sender { get; set; }

        public DateOnly CreationDate { get; set; }
    }
}
