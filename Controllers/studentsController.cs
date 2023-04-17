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
    public class studentsController : ControllerBase
    {
        private readonly academic_settingsContext _context;

        public studentsController(academic_settingsContext context)
        {
            _context = context;
        }

        // GET: api/students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<students>>> Getstudents()
        {
          if (_context.students == null)
          {
              return NotFound();
          }
            return await _context.students.ToListAsync();
        }

        // GET: api/students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<students>> Getstudents(string id)
        {
          if (_context.students == null)
          {
              return NotFound();
          }
            var students = await _context.students.FindAsync(id);

            if (students == null)
            {
                return NotFound();
            }

            return students;
        }

        // PUT: api/students/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putstudents(string id, students students)
        {
            if (id != students.StudentID)
            {
                return BadRequest();
            }

            _context.Entry(students).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!studentsExists(id))
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

        // POST: api/students
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<students>> Poststudents(students students)
        {
          if (_context.students == null)
          {
              return Problem("Entity set 'academic_settingsContext.students'  is null.");
          }
            _context.students.Add(students);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (studentsExists(students.StudentID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("Getstudents", new { id = students.StudentID }, students);
        }

        // DELETE: api/students/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletestudents(string id)
        {
            if (_context.students == null)
            {
                return NotFound();
            }
            var students = await _context.students.FindAsync(id);
            if (students == null)
            {
                return NotFound();
            }

            _context.students.Remove(students);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool studentsExists(string id)
        {
            return (_context.students?.Any(e => e.StudentID == id)).GetValueOrDefault();
        }
    }
}
