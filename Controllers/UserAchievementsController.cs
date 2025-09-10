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
    public class UserAchievementsController : ControllerBase
    {
        private readonly db_a848c4_quizContext _context;

        public UserAchievementsController(db_a848c4_quizContext context)
        {
            _context = context;
        }

        // GET: api/UserAchievements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserAchievement>>> GetUserAchievement()
        {
            return await _context.UserAchievement.ToListAsync();
        }

        // GET: api/UserAchievements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserAchievement>> GetUserAchievement(int id)
        {
            var userAchievement = await _context.UserAchievement.FindAsync(id);

            if (userAchievement == null)
            {
                return NotFound();
            }

            return userAchievement;
        }

        // PUT: api/UserAchievements/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserAchievement(int id, UserAchievement userAchievement)
        {
            if (id != userAchievement.Id)
            {
                return BadRequest();
            }

            _context.Entry(userAchievement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserAchievementExists(id))
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

        // POST: api/UserAchievements
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UserAchievement>> PostUserAchievement(UserAchievement userAchievement)
        {
            _context.UserAchievement.Add(userAchievement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserAchievement", new { id = userAchievement.Id }, userAchievement);
        }

        // DELETE: api/UserAchievements/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserAchievement>> DeleteUserAchievement(int id)
        {
            var userAchievement = await _context.UserAchievement.FindAsync(id);
            if (userAchievement == null)
            {
                return NotFound();
            }

            _context.UserAchievement.Remove(userAchievement);
            await _context.SaveChangesAsync();

            return userAchievement;
        }

        private bool UserAchievementExists(int id)
        {
            return _context.UserAchievement.Any(e => e.Id == id);
        }
    }
}
