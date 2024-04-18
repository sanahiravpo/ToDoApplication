using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoApplication.Interfaces;
using ToDoApplication.Models;

namespace ToDoApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly ITodo _todos;
        public ToDoController(ITodo todos)
        {
            _todos = todos;
        }
        [HttpGet]
        public IActionResult GetAllTasks()
        {

            return Ok(_todos.GetAllTasks());
        }
        [HttpGet("{id}")]
        public IActionResult GetTaskById(int id)
        {
            var item= _todos.GetTaskById(id);
            if (item != null)
            {
                return Ok(_todos.GetTaskById(id));
            }
            else
            {
                return BadRequest("item Not Found");
            }

        }
        [HttpPost]
        public IActionResult AddTask([FromBody] ToDo toDo)
        {
            _todos.AddTask(toDo);
            return Ok();
            
           
        }
        [HttpDelete]
        public IActionResult DeleteTask(int id)
        {
            _todos.DeleteTask(id);
            
                return Ok("item deleted  successfully");
           
        }
        [HttpPut]
        public IActionResult UpdateTask(ToDo toDo, int id)
        {
              _todos.UpdateTask(toDo, id);
            return Ok("item updated");

        }
    }
}
