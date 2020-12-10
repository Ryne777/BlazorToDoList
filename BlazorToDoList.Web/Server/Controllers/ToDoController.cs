using BlazorToDoList.Bl.Interfaces;
using BlazorToDoList.Bl.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlazorToDoList.Web.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private IToDoService _service;
        public ToDoController(IToDoService service)
        {
            _service = service;
        }
        // GET: api/<ToDoController>
        [HttpGet]
        public async Task<IEnumerable<IndexToDoViewModel>> GetToDoList()
        {
            return await _service.GetAll();
        }

        // GET api/<ToDoController>/5
        [HttpGet("{id}")]
        public async Task<IndexToDoViewModel> GetById(string id)
        {
            return await _service.GetOneToDoById(id);
        }

        // POST api/<ToDoController>
        [HttpPost]
        public async Task CreateToDo([FromBody] CreateToDoViewModel value)
        {
            await _service.CreateToDo(value);
        }

        // PUT api/<ToDoController>/5
        [HttpPut("{id}")]
        public async Task Update(string id, [FromBody] UpdateToDoViewModel value)
        {
            await _service.UpdateToDo(id, value);
        }

        // DELETE api/<ToDoController>/5
        [HttpDelete("{id}")]
        public async Task DeleteToDo(string id)
        {
            await _service.DeleteToDo(id);
        }
    }
}
