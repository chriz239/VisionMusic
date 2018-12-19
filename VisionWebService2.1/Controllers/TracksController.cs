using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VisionMusicLibrary.Models;
using VisionWebService.Database;

namespace VisionWebService.Controllers
{
    [Produces("application/json")]
    [Route("api/Tracks")]
    public class TracksController : Controller
    {
        private readonly VisionServerContext _context;

        public TracksController(VisionServerContext context)
        {
            _context = context;
        }

        // GET: api/Tracks
        [HttpGet]
        public IEnumerable<Track> GetTracks()
        {
            return _context.Tracks;
        }

        // GET: api/Tracks/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTrack([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var track = await _context.Tracks.SingleOrDefaultAsync(m => m.TrackID == id);

            if (track == null)
            {
                return NotFound();
            }

            return Ok(track);
        }

        // PUT: api/Tracks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrack([FromRoute] int id, [FromBody] Track track)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != track.TrackID)
            {
                return BadRequest();
            }

            _context.Entry(track).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrackExists(id))
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

        // POST: api/Tracks
        [HttpPost]
        public async Task<IActionResult> PostTrack([FromBody] Track track)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Tracks.Add(track);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrack", new { id = track.TrackID }, track);
        }

        // DELETE: api/Tracks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrack([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var track = await _context.Tracks.SingleOrDefaultAsync(m => m.TrackID == id);
            if (track == null)
            {
                return NotFound();
            }

            _context.Tracks.Remove(track);
            await _context.SaveChangesAsync();

            return Ok(track);
        }

        private bool TrackExists(int id)
        {
            return _context.Tracks.Any(e => e.TrackID == id);
        }

        [Route("Download")]
        [HttpGet("{id}")]
        public async Task<ActionResult> Download([FromRoute] int id)
        {
            var track = _context.Tracks.SingleOrDefault(t => t.TrackID == id);

            if (track == null)
            {
                return NotFound();
            }

            var memory = new MemoryStream();
            using (var stream = new FileStream(track.AbsolutePath, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, "application/octet-stream", Path.GetFileName(track.AbsolutePath));
        }
    }
}