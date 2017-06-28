using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestCoreWebAPI.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestCoreWebAPI.Controllers
{
    //Placing a route attribute on the controller makes all actions in the controller use attribute routing.
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
		//The constructor uses Dependency Injection to inject the database context(TodoContext) into the controller.The database context is used in each of the CRUD methods in the controller.
		private readonly TodoContext _context;
        public TodoController(TodoContext context)
        {
            _context = context;
            if (_context.TodoItems.Count()==0)
            {
				//The constructor adds an item to the in-memory database if one doesn't exist.
				_context.TodoItems.Add(new TodoItem { Name = "Item1" });
                _context.SaveChanges();
            }
        }

		//These methods implement the two GET methods:
        //GET /api/todo
        //GET /api/todo/{id}
        [HttpGet]
        public IEnumerable<TodoItem> GetAll()
        {
            return _context.TodoItems.ToList();
        }
        [HttpGet ("{id}", Name = "GetTodo")]
        public IActionResult GetById(long id)
        {
            var item = _context.TodoItems.FirstOrDefault(t => t.Id == id);
            if (item==null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }
    }
}
