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
    public class UserConfigurationsController : ControllerBase
    {
        private readonly ChatAPIContext _context;

        public UserConfigurationsController(ChatAPIContext context)
        {
            _context = context;
        }

        // GET: api/UserConfigurations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserConfiguration>>> GetUserConfigurations()
        {
            return await _context.UserConfigurations.ToListAsync();
        }

        // GET: api/UserConfigurations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserConfiguration>> GetUserConfiguration(int id)
        {
            var userConfiguration = await _context.UserConfigurations.FindAsync(id);

            if (userConfiguration == null)
            {
                return NotFound();
            }

            return userConfiguration;
        }

        // PUT: api/UserConfigurations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserConfiguration(int id, UserConfiguration userConfiguration)
        {
            if (id != userConfiguration.Id)
            {
                return BadRequest();
            }

            _context.Entry(userConfiguration).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserConfigurationExists(id))
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

        // POST: api/UserConfigurations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserConfiguration>> PostUserConfiguration(UserConfiguration userConfiguration)
        {
            _context.UserConfigurations.Add(userConfiguration);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserConfiguration", new { id = userConfiguration.Id }, userConfiguration);
        }

        // DELETE: api/UserConfigurations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserConfiguration(int id)
        {
            var userConfiguration = await _context.UserConfigurations.FindAsync(id);
            if (userConfiguration == null)
            {
                return NotFound();
            }

            _context.UserConfigurations.Remove(userConfiguration);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserConfigurationExists(int id)
        {
            return _context.UserConfigurations.Any(e => e.Id == id);
        }
    }
}
