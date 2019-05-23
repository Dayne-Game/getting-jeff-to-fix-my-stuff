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
    public class WishlistController : ControllerBase {
        private readonly MoviesContext _context;
        public WishlistController (MoviesContext context) {
            _context = context;
        }
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StandardWishlist>>> GetWishlist () {
            return await _context.StandardWishlist.ToListAsync ();
        }

        // GET api/values/5
        [HttpGet ("{id}")]
        public async Task<ActionResult<StandardWishlist>> GetWishlist (int id) {
            StandardWishlist item = await _context.StandardWishlist.FindAsync (id);

            if (item == null) {
                return NotFound ();
            }

            return item;
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<StandardWishlist>> PostWishlist (StandardWishlist item) {
            _context.StandardWishlist.Add (item);
            await _context.SaveChangesAsync ();

            return CreatedAtAction (
                nameof (GetWishlist),
                item);
        }

        // DELETE api/values/5
        [HttpDelete ("{id}")]
        public async Task<IActionResult> DeleteWishlistItem (int id) {
            StandardWishlist model = await _context.StandardWishlist.FindAsync (id);

            if (model == null) {
                return NotFound ();
            }

            _context.StandardWishlist.Remove (model);
            await _context.SaveChangesAsync ();

            return Content ("Movie has been removed from Wishlist");
        }
    }
}