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
    public class ChatOfUsersController : ControllerBase
    {
        private readonly db_a848c4_quizContext _context;

        public ChatOfUsersController(db_a848c4_quizContext context)
        {
            _context = context;
        }

        // GET: api/ChatOfUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChatOfUser>>> GetChatOfUser()
        {
            return await _context.ChatOfUser.ToListAsync();
        }

        // GET: api/ChatOfUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChatOfUser>> GetChatOfUser(int id)
        {
            var chatOfUser = await _context.ChatOfUser.FindAsync(id);

            if (chatOfUser == null)
            {
                return NotFound();
            }

            return chatOfUser;
        }

        // PUT: api/ChatOfUsers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChatOfUser(int id, ChatOfUser chatOfUser)
        {
            if (id != chatOfUser.Id)
            {
                return BadRequest();
            }

            _context.Entry(chatOfUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChatOfUserExists(id))
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

        // POST: api/ChatOfUsers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ChatOfUser>> PostChatOfUser(ChatOfUser chatOfUser)
        {
            _context.ChatOfUser.Add(chatOfUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChatOfUser", new { id = chatOfUser.Id }, chatOfUser);
        }

        // DELETE: api/ChatOfUsers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ChatOfUser>> DeleteChatOfUser(int id)
        {
            var chatOfUser = await _context.ChatOfUser.FindAsync(id);
            if (chatOfUser == null)
            {
                return NotFound();
            }

            _context.ChatOfUser.Remove(chatOfUser);
            await _context.SaveChangesAsync();

            return chatOfUser;
        }

        // DELETE: api/ChatOfUsers/5/5
        [HttpDelete("{chatId}/{userId}")]
        public async Task<ActionResult<ChatOfUser>> DeleteChatOfUser(int chatId, int userId)
        {
            var chatOfUser = await _context.ChatOfUser.FirstOrDefaultAsync(cu => cu.ChatId == chatId && cu.UserId == userId);
            if (chatOfUser == null)
            {
                return NotFound();
            }

            _context.ChatOfUser.Remove(chatOfUser);
            await _context.SaveChangesAsync();

            return chatOfUser;
        }

        private bool ChatOfUserExists(int id)
        {
            return _context.ChatOfUser.Any(e => e.Id == id);
        }
    }
}
