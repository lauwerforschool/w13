using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Group_4_DB.Data;
using Group_4_DB.Models;

namespace Group_4_DB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class instructorsController : ControllerBase
    {
        private readonly academic_settingsContext _context;

        public instructorsController(academic_settingsContext context)
        {
            _context = context;
        }

        // GET: api/instructors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<instructors>>> Getinstructors()
        {
          if (_context.instructors == null)
          {
              return NotFound();
          }
            return await _context.instructors.ToListAsync();
        }

        // GET: api/instructors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<instructors>> Getinstructors(string id)
        {
          if (_context.instructors == null)
          {
              return NotFound();
          }
            var instructors = await _context.instructors.FindAsync(id);

            if (instructors == null)
            {
                return NotFound();
            }

            return instructors;
        }

        // PUT: api/instructors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putinstructors(string id, instructors instructors)
        {
            if (id != instructors.InstructorsID)
            {
                return BadRequest();
            }

            _context.Entry(instructors).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!instructorsExists(id))
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

        // POST: api/instructors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<instructors>> Postinstructors(instructors instructors)
        {
          if (_context.instructors == null)
          {
              return Problem("Entity set 'academic_settingsContext.instructors'  is null.");
          }
            _context.instructors.Add(instructors);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (instructorsExists(instructors.InstructorsID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("Getinstructors", new { id = instructors.InstructorsID }, instructors);
        }

        // DELETE: api/instructors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteinstructors(string id)
        {
            if (_context.instructors == null)
            {
                return NotFound();
            }
            var instructors = await _context.instructors.FindAsync(id);
            if (instructors == null)
            {
                return NotFound();
            }

            _context.instructors.Remove(instructors);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool instructorsExists(string id)
        {
            return (_context.instructors?.Any(e => e.InstructorsID == id)).GetValueOrDefault();
        }
    }
}
