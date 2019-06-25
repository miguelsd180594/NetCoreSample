using Belatrix.Final.WebApi.Models;
using Belatrix.Final.WebApi.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Belatrix.Final.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlaylistController : ControllerBase
    {
        private readonly IRepository<Playlist> _repository;
        public PlaylistController(IRepository<Playlist> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Playlist>>> GetPlaylists()
        {
            var list = await _repository.Read();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public ActionResult<Playlist> GetPlaylist(int id)
        {
            var entity = _repository.GetById(id);
            if (entity == null) return NotFound();
            return Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult<Playlist>> PostPlaylist([FromBody]Playlist request)
        {
            await _repository.Create(request);
            return Ok(request.Id);
        }

        [HttpPut]
        public async Task<ActionResult<bool>> PutPlaylist([FromBody]Playlist request)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null) return NotFound();
            var response = await _repository.Update(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeletePlaylist(int id)
        {
            var entity = _repository.GetById(id);
            if (entity == null) return NotFound();
            var response = await _repository.Delete(entity);
            return Ok(response);
        }
    }
}
