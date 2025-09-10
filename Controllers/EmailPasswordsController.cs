using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizWebAPI;

namespace QuizWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailPasswordsController : ControllerBase
    {
        private readonly db_a848c4_quizContext _context;

        public EmailPasswordsController(db_a848c4_quizContext context)
        {
            _context = context;
        }

        // GET: api/EmailPasswords
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmailPassword>>> GetEmailPassword()
        {
            return await _context.EmailPassword.ToListAsync();
        }

        // GET: api/EmailPasswords/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmailPassword>> GetEmailPassword(int id)
        {
            var emailPassword = await _context.EmailPassword.FindAsync(id);

            if (emailPassword == null)
            {
                return NotFound();
            }

            return emailPassword;
        }

        // GET: api/EmailPasswords/EmailTest
        [HttpGet("email")]
        public async Task<ActionResult<EmailPassword>> GetEmailPassword(string email)
        {

            var emailPassword = await _context.EmailPassword.FirstOrDefaultAsync(ep => ep.Email == email);

            if (emailPassword == null)
            {
                return null;
            }

            return emailPassword;
        }

        // PUT: api/EmailPasswords/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmailPassword(int id, EmailPassword emailPassword)
        {
            if (id != emailPassword.Id)
            {
                return BadRequest();
            }

            _context.Entry(emailPassword).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmailPasswordExists(id))
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

        // POST: api/EmailPasswords
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EmailPassword>> PostEmailPassword(EmailPassword emailPassword)
        {
            _context.EmailPassword.Add(emailPassword);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmailPassword", new { id = emailPassword.Id }, emailPassword);
        }

        // DELETE: api/EmailPasswords/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmailPassword>> DeleteEmailPassword(int id)
        {
            var emailPassword = await _context.EmailPassword.FindAsync(id);
            if (emailPassword == null)
            {
                return NotFound();
            }

            _context.EmailPassword.Remove(emailPassword);
            await _context.SaveChangesAsync();

            return emailPassword;
        }

        private bool EmailPasswordExists(int id)
        {
            return _context.EmailPassword.Any(e => e.Id == id);
        }
    }
}
