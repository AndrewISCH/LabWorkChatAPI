namespace ChatAPIWebApp.Models
{
    public class Dialogue
    {
        public Dialogue()
        {
            Messages = new List<Message>();
        }

        public int Id { get; set; }
        public int User1Id { get; set; }
        public User User1 { get; set; } 

        public int User2Id { get; set; }
        public User User2 { get; set; }  

        public virtual List<Message> Messages { get; set; }
        public int NumOfMessages { get; set; }
    }
}
