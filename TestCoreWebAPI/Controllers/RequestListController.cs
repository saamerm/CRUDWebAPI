using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestCoreWebAPI.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class RequestListController : Controller
    {

        private readonly RequestListContext _context;
        public RequestListController(RequestListContext context)
        {
            _context = context;
            if (_context.RequestListItems.Count() == 0)
            {
                //The constructor adds an item to the in-memory database if one doesn't exist.
                _context.RequestListItems.Add(new RequestListItem
                {
                    ProjectCode=14001685,
                    Name = "Honeywell Moundsville OM&M - 30924",
                    IsComplete=false,
                    LabLocation="Knoxville",
                    BillTo="Honeywell",
                    ReportTo="Honeywell International Inc",
                    AEName="NAD - East",
                    JDECode="88250",
                    PercentOfProject="100",
                    LoginsAssociated="2",
                    dollarValue="615",
                    RequestDate="1499336576",
                    NewAEName="Azad, Maryam",
                    PercOfPrjRequested="100",
                    AEComments="This was worked on by me"
                });
                _context.SaveChanges();
            }
        }
        #region CRUD_OPERATIONS
        //These methods implement Create/Post methods:
        [HttpPost]
        public IActionResult Create([FromBody] RequestListItem item)
        {
            //The[FromBody] attribute tells MVC to get the value of the to-do item from the body of the HTTP request.
            if (item == null)
            {
                return BadRequest();
            }
            _context.RequestListItems.Add(item);
            _context.SaveChanges();
            return CreatedAtRoute("GetRequestList", new { id = item.Id }, item);
        }

        //These methods implement the two GET methods:
        //GET /api/RequestList
        //GET /api/RequestList/{id}
        [HttpGet]
        public IEnumerable<RequestListItem> GetAll()
        {
            //The GetAll method returns an IEnumerable. MVC automatically serializes the object to JSON and writes the JSON into the body of the response message. The response code for this method is 200, assuming there are no unhandled exceptions. (Unhandled exceptions are translated into 5xx errors.)
            return _context.RequestListItems.ToList();
        }
        [HttpGet("{id}", Name = "GetRequestList")]
        public IActionResult GetById(long id)
        {
            //The GetById method returns the more general IActionResult type, which represents a wide range of return types.GetById has two different return types:
            //If no item matches the requested ID, the method returns a 404 error.This is done by returning NotFound.
            //Otherwise, the method returns 200 with a JSON response body.This is done by returning an ObjectResult
            var item = _context.RequestListItems.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        //UPDATE or PUT, HTTPPAtch is for being able to update without providing all the information
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] RequestListItem item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }
            var RequestList = _context.RequestListItems.FirstOrDefault((t => t.Id == id));
            if (RequestList == null)
            {
                return NotFound();
            }
            RequestList.IsComplete = item.IsComplete;
            //RequestList.projectName = item.projectName;
            RequestList.LabLocation = item.LabLocation;
            RequestList.BillTo = item.BillTo;
            RequestList.ReportTo = item.ReportTo;
            RequestList.AEName = item.AEName;
            RequestList.JDECode = item.JDECode;
            RequestList.PercentOfProject = item.PercentOfProject;
            RequestList.LoginsAssociated = item.LoginsAssociated;
            RequestList.NewAEName = item.NewAEName;
            RequestList.dollarValue = item.dollarValue;
            RequestList.Name = item.Name;
            _context.RequestListItems.Update(RequestList);
            _context.SaveChanges();
            return new NoContentResult();
        }

        //DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var RequestList = _context.RequestListItems.First(t => t.Id == id);
            if (RequestList == null)
            {
                return NotFound();
            }
            _context.RequestListItems.Remove(RequestList);
            _context.SaveChanges();
            return new NoContentResult();
        }

        #endregion CRUD_OPERATIONS
    }
}
