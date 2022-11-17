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
    public class QuestionAnswersController : ControllerBase
    {
        private readonly DataContext _context;

        public QuestionAnswersController(DataContext context)
        {
            _context = context;
        }

        // GET: api/QuestionAnswers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuestionAnswer>>> GetQuestionAnswer()
        {
            return await _context.QuestionAnswer.ToListAsync();
        }

        // GET: api/QuestionAnswers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<QuestionAnswer>> GetQuestionAnswer(Guid id)
        {
            var questionAnswer = await _context.QuestionAnswer.FindAsync(id);

            if (questionAnswer == null)
            {
                return NotFound();
            }

            return questionAnswer;
        }

        // PUT: api/QuestionAnswers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuestionAnswer(Guid id, QuestionAnswer questionAnswer)
        {
            if (id != questionAnswer.IdQuestionAnswer)
            {
                return BadRequest();
            }

            _context.Entry(questionAnswer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionAnswerExists(id))
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

        // POST: api/QuestionAnswers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<QuestionAnswer>> PostQuestionAnswer(QuestionAnswer questionAnswer)
        {
            _context.QuestionAnswer.Add(questionAnswer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuestionAnswer", new { id = questionAnswer.IdQuestionAnswer }, questionAnswer);
        }

        // DELETE: api/QuestionAnswers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestionAnswer(Guid id)
        {
            var questionAnswer = await _context.QuestionAnswer.FindAsync(id);
            if (questionAnswer == null)
            {
                return NotFound();
            }

            _context.QuestionAnswer.Remove(questionAnswer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuestionAnswerExists(Guid id)
        {
            return _context.QuestionAnswer.Any(e => e.IdQuestionAnswer == id);
        }
    }
}
