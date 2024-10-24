using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TonicApplication.Entities;
using TonicApplication.Repos;

namespace TonicApplication.Controllers.Api
{
    [Route("api/todo")]
    [ApiController]
    public class TodoApi : ControllerBase
    {
        private ITodoRepo _todoRepo;

        public TodoApi(ITodoRepo todoRepo)
        {
            _todoRepo = todoRepo;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _todoRepo.GetAll();
            return Ok(result);
        }

        [HttpPost("insert")]
        public IActionResult InsertTodoItem([FromQuery] string text)
        {
            _todoRepo.Insert(text);
            return Ok();
        }

        [HttpDelete("delete")]
        public IActionResult DeleteTodoItem([FromQuery] int id)
        {
            _todoRepo.Delete(id);
            return Ok();
        }

        [HttpPut("update")]
        public IActionResult UpdateTodoItem([FromBody] TodoItem item)
        {
            _todoRepo.Update(item);
            return Ok();
        }
    }
}
