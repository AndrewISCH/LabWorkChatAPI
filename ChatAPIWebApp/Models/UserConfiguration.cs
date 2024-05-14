namespace ChatAPIWebApp.Models
{
    public class UserConfiguration
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public bool IsHiddenActivity { get; set; } = false;
        public bool IsPrivate { get; set; } = false;
    }
}
