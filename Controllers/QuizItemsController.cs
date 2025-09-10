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
    public class QuizItemsController : ControllerBase
    {
        private readonly db_a848c4_quizContext _context;

        public QuizItemsController(db_a848c4_quizContext context)
        {
            _context = context;
        }

        // GET: api/QuizItems
        [HttpGet]
        public ActionResult<IEnumerable<QuizItemResponse>> GetQuizItem()
        {
            return _context.QuizItem.Where(q => q.IsPublished == true).ToList().ConvertAll(qi => new QuizItemResponse(qi, true));
        }

        // GET: api/QuizItems/5
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<QuizItemResponse>> GetQuizItem(int id)
        {
            //var quizItem = await _context.QuizItem.FindAsync(id);

            //if (quizItem == null)
            //{
            //    return NotFound();
            //}

            //return quizItem;

            return _context.QuizItem.Where(q => q.CreatorUserId == id).ToList().ConvertAll(qi => new QuizItemResponse(qi, true));
        }

        // PUT: api/QuizItems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuizItem(int id, QuizItem quizItem)
        {
            if (id != quizItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(quizItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuizItemExists(id))
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

        // POST: api/QuizItems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<QuizItem>> PostQuizItem(QuizItem quizItem)
        {
            _context.QuizItem.Add(quizItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuizItem", new { id = quizItem.Id }, quizItem);
        }

        // DELETE: api/QuizItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<QuizItem>> DeleteQuizItem(int id)
        {
            var quizItem = await _context.QuizItem.FindAsync(id);
            if (quizItem == null)
            {
                return NotFound();
            }

            _context.QuizItem.Remove(quizItem);
            await _context.SaveChangesAsync();

            return quizItem;
        }

        private bool QuizItemExists(int id)
        {
            return _context.QuizItem.Any(e => e.Id == id);
        }
    }
}
