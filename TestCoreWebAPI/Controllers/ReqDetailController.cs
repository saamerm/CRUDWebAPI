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
	public class ReqDetailController : Controller
	{

		private readonly ReqDetailContext _context;
		public ReqDetailController(ReqDetailContext context)
		{
			_context = context;
			if (_context.ReqDetailItems.Count() == 0)
			{
				//The constructor adds an item to the in-memory database if one doesn't exist.
				_context.ReqDetailItems.Add(new ReqDetailItem 
                { 
					ProjectCode = 14001685,
					Name = "Honeywell Moundsville OM&M - 30924",
					IsComplete = false,
					LabLocation = "Knoxville",
					BillTo = "Honeywell",
					ReportTo = "Honeywell International Inc",
					AEName = "NAD - East",
					JDECode = "88250",
					PercentOfProject = "100",
					LoginsAssociated = "2",
					dollarValue = "615",
					RequestDate = "1499336576",
					NewAEName = "Azad, Maryam",
					PercOfPrjRequested = "100",
					AEComments = "This was worked on by me"
                });
				_context.SaveChanges();
			}
		}
		#region CRUD_OPERATIONS
		//These methods implement Create/Post methods:
		[HttpPost]
		public IActionResult Create([FromBody] ReqDetailItem item)
		{
			//The[FromBody] attribute tells MVC to get the value of the to-do item from the body of the HTTP request.
			if (item == null)
			{
				return BadRequest();
			}
			_context.ReqDetailItems.Add(item);
			_context.SaveChanges();
			return CreatedAtRoute("GetReqDetail", new { id = item.Id }, item);
		}

		//These methods implement the two GET methods:
		//GET /api/RequestDetail
		//GET /api/RequestDetail/{id}
		[HttpGet]
		public IEnumerable<ReqDetailItem> GetAll()
		{
			//The GetAll method returns an IEnumerable. MVC automatically serializes the object to JSON and writes the JSON into the body of the response message. The response code for this method is 200, assuming there are no unhandled exceptions. (Unhandled exceptions are translated into 5xx errors.)
			return _context.ReqDetailItems.ToList();
		}
		[HttpGet("{id}", Name = "GetReqDetail")]
		public IActionResult GetById(long id)
		{
			//The GetById method returns the more general IActionResult type, which represents a wide range of return types.GetById has two different return types:
			//If no item matches the requested ID, the method returns a 404 error.This is done by returning NotFound.
			//Otherwise, the method returns 200 with a JSON response body.This is done by returning an ObjectResult
			var item = _context.ReqDetailItems.FirstOrDefault(t => t.Id == id);
			if (item == null)
			{
				return NotFound();
			}
			return new ObjectResult(item);
		}

		//UPDATE or PUT, HTTPPAtch is for being able to update without providing all the information
		[HttpPut("{id}")]
		public IActionResult Update(long id, [FromBody] ReqDetailItem item)
		{
			if (item == null || item.Id != id)
			{
				return BadRequest();
			}
			var ReqDetail = _context.ReqDetailItems.FirstOrDefault((t => t.Id == id));
			if (ReqDetail == null)
			{
				return NotFound();
			}
			ReqDetail.IsComplete = item.IsComplete;
			ReqDetail.Name = item.Name;
			ReqDetail.LabLocation = item.LabLocation;
			ReqDetail.BillTo = item.BillTo;
			ReqDetail.ReportTo = item.ReportTo;
			ReqDetail.AEName = item.AEName;
			ReqDetail.JDECode = item.JDECode;
			ReqDetail.PercentOfProject = item.PercentOfProject;
			ReqDetail.LoginsAssociated = item.LoginsAssociated;
			ReqDetail.NewAEName = item.NewAEName;
			ReqDetail.dollarValue = item.dollarValue;
            ReqDetail.ProjectCode = ReqDetail.ProjectCode;
            ReqDetail.RequestDate = ReqDetail.RequestDate;
            ReqDetail.PercOfPrjRequested = ReqDetail.PercOfPrjRequested;
            ReqDetail.AEComments = ReqDetail.AEComments;
			_context.ReqDetailItems.Update(ReqDetail);
			_context.SaveChanges();
			return new NoContentResult();
		}

		//DELETE
		[HttpDelete("{id}")]
		public IActionResult Delete(long id)
		{
			var ReqDetail = _context.ReqDetailItems.First(t => t.Id == id);
			if (ReqDetail == null)
			{
				return NotFound();
			}
			_context.ReqDetailItems.Remove(ReqDetail);
			_context.SaveChanges();
			return new NoContentResult();
		}

		#endregion CRUD_OPERATIONS
	}
}
