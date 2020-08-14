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
    public class Platforms : ControllerBase
    {
        private readonly HelpfulCommandsApiContext _context;

        public Platforms(HelpfulCommandsApiContext context)
        {
            _context = context;
        }

        // GET: api/PlatformModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Platform>>> GetPlatforms()
        {
            var platforms = _context.Platforms.Include(p => p.Categories);
            return await platforms.ToListAsync();
        }

        // GET: api/PlatformModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Platform>> GetPlatformModel(int id)
        {
            var PlatformModel = await _context.Platforms.Include(p => p.Categories).Where(p => p.Id == id).ToListAsync();
            if (PlatformModel == null)
            {
                return NotFound();
            }

            return PlatformModel[0];
        }

        // PUT: api/PlatformModels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlatformModel(int id, Platform PlatformModel)
        {
            if (id != PlatformModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(PlatformModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlatformModelExists(id))
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

        // POST: api/PlatformModels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Platform>> PostPlatformModel(Platform PlatformModel)
        {
            _context.Platforms.Add(PlatformModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlatformModel", new { id = PlatformModel.Id }, PlatformModel);
        }

        // DELETE: api/PlatformModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Platform>> DeletePlatformModel(int id)
        {
            var PlatformModel = await _context.Platforms.FindAsync(id);
            if (PlatformModel == null)
            {
                return NotFound();
            }

            _context.Platforms.Remove(PlatformModel);
            await _context.SaveChangesAsync();

            return PlatformModel;
        }

        private bool PlatformModelExists(int id)
        {
            return _context.Platforms.Any(e => e.Id == id);
        }
    }
}
