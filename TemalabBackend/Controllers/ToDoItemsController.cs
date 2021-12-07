using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TemalabBackend.DAL.EF;
using TemalabBackend.BL;

namespace TemalabBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoItemsController : ControllerBase
    {
        private readonly IToDoManager tm;

        public ToDoItemsController(IToDoManager tm)
        {
            this.tm = tm;
        }

        // GET: api/ToDoItems
        [HttpGet]
        public async Task<IEnumerable<ToDoItem>> GetToDoItem()
        {
            return await tm.ListToDos();
        }

        // GET: api/ToDoItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoItem>> GetToDoItem(int id)
        {
            var toDoItem = await tm.GetToDoOrNull(id);

            if (toDoItem == null)
            {
                return NotFound();
            }

            return toDoItem;
        }

        // PUT: api/ToDoItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutToDoItem(int id, ToDoItem toDoItem)
        {
            if (id != toDoItem.ID)
            {
                return BadRequest();
            }

            var found = await tm.ModifyToDo(toDoItem);
            if (!found)
            {
                return NotFound();
            }

            return NoContent();
            
        }

        // POST: api/ToDoItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ToDoItem>> PostToDoItem(ToDoItem toDoItem)
        {
            await  tm.AddToDo(toDoItem);

            return CreatedAtAction("GetToDoItem", new { id = toDoItem.ID }, toDoItem);
        }

        // DELETE: api/ToDoItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToDoItem(int id)
        {
            var toDoItem = await tm.GetToDoOrNull(id);
            if (toDoItem == null)
            {
                return NotFound();
            }

            bool success =await tm.DeleteToDo(id);
            if (!success)
            {
                return Conflict();
            }

            return NoContent();
        }

       
    }
}
