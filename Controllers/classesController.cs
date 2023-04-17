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
    public class classesController : ControllerBase
    {
        private readonly academic_settingsContext _context;

        public classesController(academic_settingsContext context)
        {
            _context = context;
        }

        // GET: api/classes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<classes>>> Getclasses()
        {
          if (_context.classes == null)
          {
              return NotFound();
          }
            return await _context.classes.ToListAsync();
        }

        // GET: api/classes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<classes>> Getclasses(string id)
        {
          if (_context.classes == null)
          {
              return NotFound();
          }
            var classes = await _context.classes.FindAsync(id);

            if (classes == null)
            {
                return NotFound();
            }

            return classes;
        }

        // PUT: api/classes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putclasses(string id, classes classes)
        {
            if (id != classes.ClassID)
            {
                return BadRequest();
            }

            _context.Entry(classes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!classesExists(id))
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

        // POST: api/classes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<classes>> Postclasses(classes classes)
        {
          if (_context.classes == null)
          {
              return Problem("Entity set 'academic_settingsContext.classes'  is null.");
          }
            _context.classes.Add(classes);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (classesExists(classes.ClassID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("Getclasses", new { id = classes.ClassID }, classes);
        }

        // DELETE: api/classes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteclasses(string id)
        {
            if (_context.classes == null)
            {
                return NotFound();
            }
            var classes = await _context.classes.FindAsync(id);
            if (classes == null)
            {
                return NotFound();
            }

            _context.classes.Remove(classes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool classesExists(string id)
        {
            return (_context.classes?.Any(e => e.ClassID == id)).GetValueOrDefault();
        }
    }
}
