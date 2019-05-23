using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Database_Models;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase {
        private readonly MoviesContext _context;
        public UsersController (MoviesContext context) {
            _context = context;
        }
        // GET api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StandardUsers>>> GetUsers () {
            return await _context.StandardUsers.ToListAsync ();
        }

        // GET api/users/5
        [HttpGet ("{id}")]
        public async Task<ActionResult<StandardUsers>> GetUsers (int id) {
            StandardUsers item = await _context.StandardUsers.FindAsync (id);

            if (item == null) {
                return NotFound ();
            }

            return item;
        }

        // PUT api/users/5
        [HttpPut ("{id}")]
        public async Task<IActionResult> PutUsersItem (int id, StandardUsers item) {
            if (id != item.Id) {
                return BadRequest ();
            }

            _context.Entry (item).State = EntityState.Modified;
            await _context.SaveChangesAsync ();

            return Content ("User has been updated");
        }
    }
}