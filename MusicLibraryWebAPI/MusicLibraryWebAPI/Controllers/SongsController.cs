using Microsoft.AspNetCore.Mvc;
using MusicLibraryWebAPI.Data;
using MusicLibraryWebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicLibraryWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        public readonly ApplicationDbContext _context;

        public SongsController(ApplicationDbContext context)
        {
            _context = context;
        }
    
        // GET: api/<SongsController>
            [HttpGet]
        public IActionResult Get()
        {
            var songs = _context.Songs.ToList();
            return Ok(songs);
        }

        // GET api/<SongsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var song = _context.Songs.Where(s => s.Id == id).SingleOrDefault();
            if (song == null)
            {
                return NotFound();
            }
            return Ok(song);
        }

        // POST api/<SongsController>
        [HttpPost]
        public IActionResult Post([FromBody] Song newSong)
        {
            _context.Songs.Add(newSong);
            _context.SaveChanges();
            return StatusCode(201, newSong);
        }

        // PUT api/<SongsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Song updateSong)
        {
            var song = _context.Songs.Where(s => s.Id == id).SingleOrDefault();
            if (song == null)
            {
                return NotFound();
            }
            song.Title = updateSong.Title;
            song.Artist = updateSong.Artist;
            song.Album = updateSong.Album;
            song.ReleaseDate = updateSong.ReleaseDate;
            song.Genre = updateSong.Genre;
            _context.Update(song);
            _context.SaveChanges();
            return Ok(song);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id)
        {
            var song = _context.Songs.Where(s => s.Id == id).SingleOrDefault();
            if (song == null)
            {
                return NotFound();
            }
            song.Likes++;
            _context.Songs.Update(song);
            _context.SaveChanges();
            return Ok(song);
        }

        // DELETE api/<SongsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var song = _context.Songs.Where(s => s.Id == id).SingleOrDefault();
            if (song == null)
            {
                return NotFound();
            }
            _context.Songs.Remove(song);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
