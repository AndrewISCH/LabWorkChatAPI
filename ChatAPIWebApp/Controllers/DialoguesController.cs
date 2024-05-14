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
    public class DialoguesController : ControllerBase
    {
        private readonly ChatAPIContext _context;

        public DialoguesController(ChatAPIContext context)
        {
            _context = context;
        }

        // GET: api/Dialogues
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dialogue>>> GetDialogues()
        {
            return await _context.Dialogues.ToListAsync();
        }

        // GET: api/Dialogues/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dialogue>> GetDialogue(int id)
        {
            var dialogue = await _context.Dialogues.FindAsync(id);

            if (dialogue == null)
            {
                return NotFound();
            }

            return dialogue;
        }

        // PUT: api/Dialogues/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDialogue(int id, Dialogue dialogue)
        {
            if (id != dialogue.Id)
            {
                return BadRequest();
            }

            _context.Entry(dialogue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DialogueExists(id))
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

        // POST: api/Dialogues
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Dialogue>> PostDialogue(Dialogue dialogue)
        {
            _context.Dialogues.Add(dialogue);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDialogue", new { id = dialogue.Id }, dialogue);
        }

        // DELETE: api/Dialogues/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDialogue(int id)
        {
            var dialogue = await _context.Dialogues.FindAsync(id);
            if (dialogue == null)
            {
                return NotFound();
            }

            _context.Dialogues.Remove(dialogue);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DialogueExists(int id)
        {
            return _context.Dialogues.Any(e => e.Id == id);
        }
    }
}
