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
    public class MoviesController : ControllerBase {
        private readonly MoviesContext _context;
        public MoviesController (MoviesContext context) {
            _context = context;
        }
        // GET api/Movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StandardMovies>>> GetMovies () {
            return await _context.StandardMovies.ToListAsync ();
        }

        // GET api/Movies/5
        [HttpGet ("{id}")]
        public async Task<ActionResult<StandardMovies>> GetMovies (int id) {
            StandardMovies item = await _context.StandardMovies.FindAsync (id);

            if (item == null) {
                return NotFound ();
            }

            return item;
        }
    }
}