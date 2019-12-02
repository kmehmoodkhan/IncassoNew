using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IncassoNew.api.Models;

namespace IncassoNew.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AbpUsersController : ControllerBase
    {
        private readonly IncassoDBContext _context;

        public AbpUsersController(IncassoDBContext context)
        {
            _context = context;
        }

        // GET: api/AbpUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AbpUsers>>> GetAbpUsers()
        {
            return await _context.AbpUsers.ToListAsync();
        }

        // GET: api/AbpUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AbpUsers>> GetAbpUsers(long id)
        {
            var abpUsers = await _context.AbpUsers.FindAsync(id);

            if (abpUsers == null)
            {
                return NotFound();
            }

            return abpUsers;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AbpUsers>> GetAbpUsers(string userName, string userPassword)
        {
            var abpUsers = await _context.AbpUsers.Where(t => t.UserName == userName && t.Password == userPassword && t.IsActive == true).FirstAsync();

            if (abpUsers == null)
            {
                return NotFound();
            }

            return abpUsers;
        }

        // PUT: api/AbpUsers/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAbpUsers(long id, AbpUsers abpUsers)
        {
            if (id != abpUsers.Id)
            {
                return BadRequest();
            }

            _context.Entry(abpUsers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AbpUsersExists(id))
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

        // POST: api/AbpUsers
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<AbpUsers>> PostAbpUsers(AbpUsers abpUsers)
        {
            _context.AbpUsers.Add(abpUsers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAbpUsers", new { id = abpUsers.Id }, abpUsers);
        }

        // DELETE: api/AbpUsers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AbpUsers>> DeleteAbpUsers(long id)
        {
            var abpUsers = await _context.AbpUsers.FindAsync(id);
            if (abpUsers == null)
            {
                return NotFound();
            }

            _context.AbpUsers.Remove(abpUsers);
            await _context.SaveChangesAsync();

            return abpUsers;
        }

        private bool AbpUsersExists(long id)
        {
            return _context.AbpUsers.Any(e => e.Id == id);
        }
    }
}
