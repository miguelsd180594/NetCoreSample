using Belatrix.Final.WebApi.Models;
using Belatrix.Final.WebApi.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Belatrix.Final.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlaylistTrackController : ControllerBase
    {
        private readonly IRepository<PlaylistTrack> _repository;
        public PlaylistTrackController(IRepository<PlaylistTrack> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlaylistTrack>>> GetPlaylistTracks()
        {
            var list = await _repository.Read();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public ActionResult<PlaylistTrack> GetPlaylistTrack(int id)
        {
            var entity = _repository.GetById(id);
            if (entity == null) return NotFound();
            return Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult<PlaylistTrack>> PostPlaylistTrack([FromBody]PlaylistTrack request)
        {
            await _repository.Create(request);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeletePlaylistTrack(int id)
        {
            var entity = _repository.GetById(id);
            if (entity == null) return NotFound();
            var response = await _repository.Delete(entity);
            return Ok(response);
        }
    }
}
