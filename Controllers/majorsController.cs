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
    public class majorsController : ControllerBase
    {
        private readonly academic_settingsContext _context;

        public majorsController(academic_settingsContext context)
        {
            _context = context;
        }

        // GET: api/majors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<major>>> Getmajor()
        {
          if (_context.major == null)
          {
              return NotFound();
          }
            return await _context.major.ToListAsync();
        }

        // GET: api/majors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<major>> Getmajor(string id)
        {
          if (_context.major == null)
          {
              return NotFound();
          }
            var major = await _context.major.FindAsync(id);

            if (major == null)
            {
                return NotFound();
            }

            return major;
        }

        // PUT: api/majors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putmajor(string id, major major)
        {
            if (id != major.MajorID)
            {
                return BadRequest();
            }

            _context.Entry(major).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!majorExists(id))
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

        // POST: api/majors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<major>> Postmajor(major major)
        {
          if (_context.major == null)
          {
              return Problem("Entity set 'academic_settingsContext.major'  is null.");
          }
            _context.major.Add(major);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (majorExists(major.MajorID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("Getmajor", new { id = major.MajorID }, major);
        }

        // DELETE: api/majors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletemajor(string id)
        {
            if (_context.major == null)
            {
                return NotFound();
            }
            var major = await _context.major.FindAsync(id);
            if (major == null)
            {
                return NotFound();
            }

            _context.major.Remove(major);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool majorExists(string id)
        {
            return (_context.major?.Any(e => e.MajorID == id)).GetValueOrDefault();
        }
    }
}
