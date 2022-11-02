using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ELearnerApi.Models;

namespace ELearnerApi.Controllers
{
    [Route("api/vocabularies")]
    [ApiController]
    public class VocabulariesController : ControllerBase
    {
        private readonly ElearnnerDBContext _context;

        public VocabulariesController(ElearnnerDBContext context)
        {
            _context = context;
        }

        // GET: api/Vocabularies
        [HttpGet("{userid}")]
        public async Task<ActionResult<IEnumerable<Vocabulary>>> GetVocabularies(int userid)
        {
            var vocabularies = from v in await _context.Vocabularies.ToListAsync()
                               where userid == v.UserId
                               select v;
            return vocabularies.ToList();
        }

        //// GET: api/Vocabularies/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Vocabulary>> GetVocabulary(int id)
        //{
        //    var vocabulary = await _context.Vocabularies.FindAsync(id);

        //    if (vocabulary == null)
        //    {
        //        return NotFound();
        //    }

        //    return vocabulary;
        //}

        // PUT: api/Vocabularies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVocabulary(int id, Vocabulary vocabulary)
        {
            Vocabulary voc = _context.Vocabularies.SingleOrDefault(a => a.Id == id);
            if (voc is null)
            {
                return BadRequest();
            }

            voc.English = vocabulary.English;
            voc.Vietnamese = vocabulary.Vietnamese;

            _context.Entry(voc).State = EntityState.Modified;
            //_context.Update(vocabulary);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VocabularyExists(id))
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

        // POST: api/Vocabularies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vocabulary>> PostVocabulary(Vocabulary vocabulary)
        {
            _context.Vocabularies.Add(vocabulary);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Vocabularies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVocabulary(int id)
        {
            var vocabulary = await _context.Vocabularies.FindAsync(id);
            if (vocabulary == null)
            {
                return NotFound();
            }

            _context.Vocabularies.Remove(vocabulary);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VocabularyExists(int id)
        {
            return _context.Vocabularies.Any(e => e.Id == id);
        }
    }
}
