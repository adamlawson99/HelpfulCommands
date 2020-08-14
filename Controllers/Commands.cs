using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HelpfulCommands.Data.Persistence;
using HelpfulCommands.Models;

namespace HelpfulCommands.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Commands : ControllerBase
    {
        private readonly HelpfulCommandsApiContext _context;

        public Commands(HelpfulCommandsApiContext context)
        {
            _context = context;
        }

        // GET: api/Commands
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Command>>> GetCommand()
        {
            return await _context.Command.ToListAsync();
        }

        // GET: api/Commands/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Command>> GetCommand(int id)
        {
            var command = await _context.Command.FindAsync(id);

            if (command == null)
            {
                return NotFound();
            }

            return command;
        }

        // PUT: api/Commands/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommand(int id, Command command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            _context.Entry(command).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommandExists(id))
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

        // POST: api/Commands
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Command>> PostCommand(Command command)
        {
            _context.Command.Add(command);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCommand", new { id = command.Id }, command);
        }

        // DELETE: api/Commands/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Command>> DeleteCommand(int id)
        {
            var command = await _context.Command.FindAsync(id);
            if (command == null)
            {
                return NotFound();
            }

            _context.Command.Remove(command);
            await _context.SaveChangesAsync();

            return command;
        }

        private bool CommandExists(int id)
        {
            return _context.Command.Any(e => e.Id == id);
        }
    }
}
