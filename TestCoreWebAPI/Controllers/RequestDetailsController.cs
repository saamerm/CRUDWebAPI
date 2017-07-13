using System;
using TestCoreWebAPI.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
namespace TestCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class RequestDetailsController:Controller
    {
        private readonly RequestDetailsContext _context;
        public RequestDetailsController(RequestDetailsContext context)
        {
            _context = context;
            if (_context.RequestDetailsItems.Count()==0)
            {
                _context.RequestDetailsItems.Add(new RequestDetailsItem 
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
					DollarValue = "615",
					RequestDate = "1499336576",
					NewAEName = "Azad, Maryam",
					PercOfPrjRequested = "100",
					AEComments = "This was worked on by me",
                    Status=3
                });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<RequestDetailsItem> GetAll()
        {
            return _context.RequestDetailsItems.ToList();
        }
        [HttpGet ("{id}", Name="GetRequestDetails")]
        public IActionResult GetById(long id)
        {
            var item = _context.RequestDetailsItems.FirstOrDefault(t => t.Id == id);
            if (item==null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] RequestDetailsItem item)
        {
            if (item==null)
            {
                return BadRequest();
            }
            _context.RequestDetailsItems.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetRequestDetails", new { id = item.Id }, item);
        }
		//--------Copied code begins
		//UPDATE or PUT, HTTPPAtch is for being able to update without providing all the information
		[HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] RequestDetailsItem item)
		{
			if (item == null || item.Id != id)
			{
				return BadRequest();
			}
			var RequestDetails = _context.RequestDetailsItems.FirstOrDefault((t => t.Id == id));
			if (RequestDetails == null)
			{
				return NotFound();
			}
			RequestDetails.IsComplete = item.IsComplete;
			RequestDetails.Name = item.Name;
			RequestDetails.LabLocation = item.LabLocation;
			RequestDetails.BillTo = item.BillTo;
			RequestDetails.ReportTo = item.ReportTo;
			RequestDetails.AEName = item.AEName;
			RequestDetails.JDECode = item.JDECode;
			RequestDetails.PercentOfProject = item.PercentOfProject;
			RequestDetails.LoginsAssociated = item.LoginsAssociated;
			RequestDetails.NewAEName = item.NewAEName;
			RequestDetails.DollarValue = item.DollarValue;
			RequestDetails.ProjectCode = item.ProjectCode;
			RequestDetails.RequestDate = item.RequestDate;
			RequestDetails.PercOfPrjRequested = item.PercOfPrjRequested;
			RequestDetails.AEComments = item.AEComments;
            RequestDetails.Status = item.Status;
			_context.RequestDetailsItems.Update(RequestDetails);
			_context.SaveChanges();
			return new NoContentResult();
		}

		//DELETE
		[HttpDelete("{id}")]
		public IActionResult Delete(long id)
		{
			var RequestDetails = _context.RequestDetailsItems.First(t => t.Id == id);
			if (RequestDetails == null)
			{
				return NotFound();
			}
			_context.RequestDetailsItems.Remove(RequestDetails);
			_context.SaveChanges();
			return new NoContentResult();
		}
		//--------Copied code ends
	}
}
