using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChatAPIWebApp.Models;

namespace ChatAPIWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly ChatAPIContext _context;

        public MessagesController(ChatAPIContext context)
        {
            _context = context;
        }

        // GET: api/Messages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Message>>> GetMessages()
        {
            return await _context.Messages.ToListAsync();
        }

        // GET: api/Messages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Message>> GetMessage(int id)
        {
            var message = await _context.Messages.FindAsync(id);

            if (message == null)
            {
                return NotFound();
            }

            return message;
        }


        // GET: api/Messages/Dialogue/1
        [HttpGet("Dialogue/{dialogueId}")]
        public async Task<ActionResult<IEnumerable<Message>>> GetMessagesFromDialogue(int dialogueId)
        {
            var message = await _context.Messages.Where(m => m.DialogueId == dialogueId).ToListAsync();

            if (message == null)
            {
                return NotFound();
            }

            return message;
        }


        // GET: api/Messages/User/5
        [HttpGet("User/{userId}")]
        public async Task<ActionResult<IEnumerable<Message>>> GetMessagesByUser(int userId)
        {
            var messages = await _context.Messages
                                         .Where(m => m.SenderId == userId)
                                         .ToListAsync();

            if (messages == null || !messages.Any())
            {
                return NotFound();
            }

            return messages;
        }

        // GET: api/Messages/User/5/2
        [HttpGet("User/{userId}/{dialogueId}")]
        public async Task<ActionResult<IEnumerable<Message>>> GetMessagesByUser(int userId, int dialogueId)
        {
            var messages = await _context.Messages
                                         .Where(m => m.SenderId == userId && m.DialogueId == dialogueId)
                                         .ToListAsync();

            if (messages == null || !messages.Any())
            {
                return NotFound();
            }

            return messages;
        }

        // PUT: api/Messages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMessage(int id, Message message)
        {
            if (id != message.Id)
            {
                return BadRequest();
            }

            _context.Entry(message).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MessageExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
       

        // POST: api/Messages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        
        [HttpPost]
        
        public async Task<ActionResult<Message>> PostMessage(int dialogueId, string content, int senderId, DateOnly creationDate)
        {
            
            var dialogue = await _context.Dialogues.FindAsync(dialogueId);
            var sender = await _context.Users.FindAsync(senderId);

            if (dialogue == null || sender == null)
            {
                return BadRequest("Invalid DialogueId or SenderId.");
            }

            
            var message = new Message
            {
                DialogueId = dialogueId,
                Content = content,
                SenderId = senderId,
                CreationDate = creationDate,
                Dialogue = dialogue,
                Sender = sender
            };

            _context.Messages.Add(message);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMessage", new { id = message.Id }, message);
        }


        // DELETE: api/Messages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            var message = await _context.Messages.FindAsync(id);
            if (message == null)
            {
                return NotFound();
            }

            _context.Messages.Remove(message);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MessageExists(int id)
        {
            return _context.Messages.Any(e => e.Id == id);
        }
    }
}
