using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pruebav3.Data;
using Pruebav3.Models;

namespace Pruebav3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAnswersController : ControllerBase
    {
        private readonly DataContext _context;

        public UserAnswersController(DataContext context)
        {
            _context = context;
        }

        // GET: api/UserAnswers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserAnswer>>> GetUserAnswer()
        {
            return await _context.UserAnswer.ToListAsync();
        }

        // GET: api/UserAnswers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserAnswer>> GetUserAnswer(Guid id)
        {
            var userAnswer = await _context.UserAnswer.FindAsync(id);

            if (userAnswer == null)
            {
                return NotFound();
            }

            return userAnswer;
        }

        // PUT: api/UserAnswers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserAnswer(Guid id, UserAnswer userAnswer)
        {
            if (id != userAnswer.IdUserAnswer)
            {
                return BadRequest();
            }

            _context.Entry(userAnswer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserAnswerExists(id))
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

        // POST: api/UserAnswers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserAnswer>> PostUserAnswer(UserAnswer userAnswer)
        {
            _context.UserAnswer.Add(userAnswer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserAnswer", new { id = userAnswer.IdUserAnswer }, userAnswer);
        }

        // DELETE: api/UserAnswers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserAnswer(Guid id)
        {
            var userAnswer = await _context.UserAnswer.FindAsync(id);
            if (userAnswer == null)
            {
                return NotFound();
            }

            _context.UserAnswer.Remove(userAnswer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserAnswerExists(Guid id)
        {
            return _context.UserAnswer.Any(e => e.IdUserAnswer == id);
        }
    }
}
