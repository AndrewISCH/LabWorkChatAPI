namespace ChatAPIWebApp.Models
{
    public class Contact
    {
        public int Id { get; set; }

        public virtual User User1 { get; set; }
        
        public int User1Id { get; set; }

        public virtual User User2 { get; set; }

        public int User2Id { get; set; }

        
        public DateOnly CreationDate { get; set; }
    }
}
