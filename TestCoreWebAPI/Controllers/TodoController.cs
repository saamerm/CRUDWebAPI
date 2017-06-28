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
            if (_context.TodoItems.Count() == 0)
            {
                //The constructor adds an item to the in-memory database if one doesn't exist.
                _context.TodoItems.Add(new TodoItem { Name = "Item1" });
                _context.SaveChanges();
            }
        }
        #region CRUD_OPERATIONS
        //These methods implement Create/Post methods:
        [HttpPost]
        public IActionResult Create([FromBody] TodoItem item)
        {
            //The[FromBody] attribute tells MVC to get the value of the to-do item from the body of the HTTP request.
            if (item == null)
            {
                return BadRequest();
            }
            _context.TodoItems.Add(item);
            _context.SaveChanges();
            return CreatedAtRoute("GetTodo", new { id = item.Id }, item);
        }

        //These methods implement the two GET methods:
        //GET /api/todo
        //GET /api/todo/{id}
        [HttpGet]
        public IEnumerable<TodoItem> GetAll()
        {
            //The GetAll method returns an IEnumerable. MVC automatically serializes the object to JSON and writes the JSON into the body of the response message. The response code for this method is 200, assuming there are no unhandled exceptions. (Unhandled exceptions are translated into 5xx errors.)
            return _context.TodoItems.ToList();
        }
        [HttpGet("{id}", Name = "GetTodo")]
        public IActionResult GetById(long id)
        {
            //The GetById method returns the more general IActionResult type, which represents a wide range of return types.GetById has two different return types:
            //If no item matches the requested ID, the method returns a 404 error.This is done by returning NotFound.
            //Otherwise, the method returns 200 with a JSON response body.This is done by returning an ObjectResult
            var item = _context.TodoItems.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        //UPDATE or PUT, HTTPPAtch is for being able to update without providing all the information
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] TodoItem item)
        {
            if (item==null||item.Id!=id)
            {
                return BadRequest();
            }
            var todo = _context.TodoItems.FirstOrDefault((t => t.Id == id));
            if (todo==null)
            {
                return NotFound();
            }
            todo.isComplete = item.isComplete;
            todo.Name = item.Name;
            _context.TodoItems.Update(todo);
            _context.SaveChanges();
            return new NoContentResult();
        }

        //DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var todo = _context.TodoItems.First(t => t.Id == id);
            if (todo==null)
            {
                return NotFound();
            }
            _context.TodoItems.Remove(todo);
            _context.SaveChanges();
            return new NoContentResult();
        }

        #endregion CRUD_OPERATIONS
    }
}
