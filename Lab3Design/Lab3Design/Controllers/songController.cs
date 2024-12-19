using Lab3Design.Models.SongCatalogs;
using Microsoft.AspNetCore.Mvc;

namespace Lab3Design.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SongsController : ControllerBase
    {
        private readonly ISongRepository _repository;

        public SongsController(ISongRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetSongs()
        {
            var songs = await _repository.GetSongsAsync();
            if (songs.Count == 0)
            {
                return NotFound("No songs found.");
            }
        
            return Ok(songs);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetSongsByCriteria(string criteria)
        {
            var songs = await _repository.GetSongsByCriteriaAsync(criteria);
        
            if (songs.Count == 0)
            {
                return NotFound($"No songs found for criteria: {criteria}.");
            }
        
            return Ok(songs);
        }
        

        [HttpPost]
        public async Task<IActionResult> AddSong([FromQuery] string name, [FromQuery] string author)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(author))
            {
                return BadRequest("Name and Author are required.");
            }

            var newSong = await _repository.AddSongAsync(name, author);

            return CreatedAtAction(nameof(GetSongs), new { id = newSong.Id }, newSong);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSongContent([FromQuery] string name, [FromQuery] string author)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(author))
            {
                return BadRequest("Both name and author are required to delete a song.");
            }

            var result = await _repository.DeleteSongAsync(name, author);

            if (!result)
            {
                return NotFound("Song not found.");
            }

            return NoContent();
        }
    }
}