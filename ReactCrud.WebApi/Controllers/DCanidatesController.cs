using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReactCrud.WebApi.Models;

namespace ReactCrud.WebApi.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class DCanidatesController : ControllerBase
   {
      private readonly DonationDbContext _context;

      public DCanidatesController(DonationDbContext context)
      {
         _context = context;
      }

      // GET: api/DCanidates
      [HttpGet]
      public async Task<ActionResult<IEnumerable<DCanidate>>> GetDCanidates()
      {
         return await _context.DCanidates.ToListAsync();
      }

      // GET: api/DCanidates/5
      [HttpGet("{id}")]
      public async Task<ActionResult<DCanidate>> GetDCanidate(int id)
      {
         var dCanidate = await _context.DCanidates.FindAsync(id);

         if (dCanidate == null)
         {
            return NotFound();
         }

         return dCanidate;
      }

      // PUT: api/DCanidates/5
      // To protect from overposting attacks, enable the specific properties you want to bind to, for
      // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
      [HttpPut("{id}")]
      public async Task<IActionResult> PutDCanidate(int id, DCanidate dCanidate)
      {
         dCanidate.Id = id;

         _context.Entry(dCanidate).State = EntityState.Modified;

         try
         {
            await _context.SaveChangesAsync();
         }
         catch (DbUpdateConcurrencyException)
         {
            if (!DCanidateExists(id))
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

      // POST: api/DCanidates
      // To protect from overposting attacks, enable the specific properties you want to bind to, for
      // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
      [HttpPost]
      public async Task<ActionResult<DCanidate>> PostDCanidate(DCanidate dCanidate)
      {
         _context.DCanidates.Add(dCanidate);
         await _context.SaveChangesAsync();

         return CreatedAtAction("GetDCanidate", new { id = dCanidate.Id }, dCanidate);
      }

      // DELETE: api/DCanidates/5
      [HttpDelete("{id}")]
      public async Task<ActionResult<DCanidate>> DeleteDCanidate(int id)
      {
         var dCanidate = await _context.DCanidates.FindAsync(id);
         if (dCanidate == null)
         {
            return NotFound();
         }

         _context.DCanidates.Remove(dCanidate);
         await _context.SaveChangesAsync();

         return dCanidate;
      }

      private bool DCanidateExists(int id)
      {
         return _context.DCanidates.Any(e => e.Id == id);
      }
   }
}
