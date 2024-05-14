using Microsoft.EntityFrameworkCore;

namespace ChatAPIWebApp.Models
{
    public class ChatAPIContext : DbContext
    {

        public virtual DbSet<Contact> Contacts { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Message> Messages { get; set; }

        public virtual DbSet<ContactRequest> ContactRequests { get; set; }



        public virtual DbSet<Dialogue> Dialogues { get; set; }

        public virtual DbSet<UserConfiguration> UserConfigurations { get; set; }

        public ChatAPIContext() { }

        public ChatAPIContext(DbContextOptions<ChatAPIContext> options) : base(options) {

            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<ContactRequest>()
                .HasOne(cr => cr.Sender)
                .WithMany(u => u.SentRequests)
                .HasForeignKey(cr => cr.SenderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ContactRequest>()
                .HasOne(cr => cr.Receiver)
                .WithMany(u => u.ReceivedRequests)
                .HasForeignKey(cr => cr.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict);

           
            modelBuilder.Entity<Dialogue>()
                .HasOne(d => d.User1)
                .WithMany(u => u.Dialogues)
                .HasForeignKey(d => d.User1Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Dialogue>()
                .HasOne(d => d.User2)
                .WithMany()
                .HasForeignKey(d => d.User2Id)
                .OnDelete(DeleteBehavior.Restrict);

            
            modelBuilder.Entity<Message>()
                .HasOne(m => m.Dialogue)
                .WithMany(d => d.Messages)
                .HasForeignKey(m => m.DialogueId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Message>()
                .HasOne(m => m.Sender)
                .WithMany()
                .HasForeignKey(m => m.SenderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Contact>()
            .HasOne(c => c.User1)
            .WithMany()
            .HasForeignKey(c => c.User1Id)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Contact>()
                .HasOne(c => c.User2)
                .WithMany()
                .HasForeignKey(c => c.User2Id)
                .OnDelete(DeleteBehavior.Restrict);


            
            modelBuilder.Entity<UserConfiguration>()
                .HasOne(uc => uc.User)
                .WithOne(u => u.UserConfiguration)
                .HasForeignKey<UserConfiguration>(uc => uc.UserId);
        }

    }
}
