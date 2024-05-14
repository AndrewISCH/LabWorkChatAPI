using System.ComponentModel.DataAnnotations;

namespace ChatAPIWebApp.Models
{
    public class User
    {
        public User()
        {
            Contacts = new List<Contact>();
            SentRequests = new List<ContactRequest>();
            ReceivedRequests = new List<ContactRequest>();
            Dialogues = new List<Dialogue>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Ім'я")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Адрес електронної пошти")]
        public string UserEmail { get; set; }

        public string Description { get; set; }
        public int UserConfigId { get; set; }
        public virtual UserConfiguration UserConfiguration { get; set; }
        public virtual List<Dialogue> Dialogues { get; set; }
        public List<Contact> Contacts { get; set; }
        public virtual List<ContactRequest> SentRequests { get; set; }
        public virtual List<ContactRequest> ReceivedRequests { get; set; }
        public DateOnly CreationDate { get; set; }
    }
}
