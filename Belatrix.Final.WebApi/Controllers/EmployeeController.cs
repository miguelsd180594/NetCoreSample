using Belatrix.Final.WebApi.Models;
using Belatrix.Final.WebApi.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Belatrix.Final.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IRepository<Employee> _repository;
        public EmployeeController(IRepository<Employee> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            var list = await _repository.Read();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployee(int id)
        {
            var entity = _repository.GetById(id);
            if (entity == null) return NotFound();
            return Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee([FromBody]Employee request)
        {
            await _repository.Create(request);
            return Ok(request.Id);
        }

        [HttpPut]
        public async Task<ActionResult<bool>> PutEmployee([FromBody]Employee request)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null) return NotFound();
            var response = await _repository.Update(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteEmployee(int id)
        {
            var entity = _repository.GetById(id);
            if (entity == null) return NotFound();
            var response = await _repository.Delete(entity);
            return Ok(response);
        }
    }
}
