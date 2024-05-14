namespace ChatAPIWebApp.Models
{
    public class ContactRequest
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public User Sender { get; set; }  

        public int ReceiverId { get; set; }
        public User Receiver { get; set; }  

        public DateOnly SendingDate { get; set; }
    }
}
