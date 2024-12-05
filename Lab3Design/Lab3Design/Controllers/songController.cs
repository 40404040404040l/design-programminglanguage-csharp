using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab3Design.Configurations;
using Lab3Design.Models.SongCatalogs;
using Lab3Design.Models.Songs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab3Design.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly SongRepository _repository = new ();

        [HttpGet]
        public async Task<ActionResult<List<Song>>> GetSongs()
        {
            var songs = await _repository.GetSongsAsync();
            return Ok(songs);
        }
        
        [HttpGet("search")]
        public async Task<ActionResult<List<Song>>> GetSongsByCriteria(string criteria)
        {
            if (string.IsNullOrEmpty(criteria))
            {
                return BadRequest("Criteria is required.");
            }
            var songs = await _repository.GetSongsByCriteriaAsync(criteria);
            return Ok(songs);
        }
        
        [HttpPost]
        public async Task<ActionResult<Song>> AddSong([FromBody] SongDto songDto)
        {
            if (string.IsNullOrWhiteSpace(songDto.Name) || string.IsNullOrWhiteSpace(songDto.Author))
            {
                return BadRequest("Name and Author are required.");
            }
        
            await _repository.AddSongAsync(songDto.Name, songDto.Author);
            return Ok(songDto);
        }
        
        [HttpDelete]
        public async Task<ActionResult> DeleteSong([FromBody] SongDto songDto)
        {
            if (string.IsNullOrWhiteSpace(songDto.Name) || string.IsNullOrWhiteSpace(songDto.Author))
            {
                return BadRequest("Name and Author are required.");
            }
            await _repository.DeleteSongAsync(songDto.Name, songDto.Author);
            return NoContent();
        }
    }
}