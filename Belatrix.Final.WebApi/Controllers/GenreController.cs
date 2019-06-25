using Belatrix.Final.WebApi.Models;
using Belatrix.Final.WebApi.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Belatrix.Final.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenreController : ControllerBase
    {
        private readonly IRepository<Genre> _repository;
        public GenreController(IRepository<Genre> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Genre>>> GetGenres()
        {
            var list = await _repository.Read();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public ActionResult<Genre> GetGenre(int id)
        {
            var entity = _repository.GetById(id);
            if (entity == null) return NotFound();
            return Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult<Genre>> PostGenre([FromBody]Genre request)
        {
            await _repository.Create(request);
            return Ok(request.Id);
        }

        [HttpPut]
        public async Task<ActionResult<bool>> PutGenre([FromBody]Genre request)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null) return NotFound();
            var response = await _repository.Update(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteGenre(int id)
        {
            var entity = _repository.GetById(id);
            if (entity == null) return NotFound();
            var response = await _repository.Delete(entity);
            return Ok(response);
        }
    }
}
