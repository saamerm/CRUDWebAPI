using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestCoreWebAPI.Models;
namespace TestCoreWebAPI.Controllers
{
	[Route("api/[controller]")]
    public class AssignmentDetailsController:Controller
    {
        private readonly AssignmentDetailsContext _context;		
        public AssignmentDetailsController(AssignmentDetailsContext context)
        {
            _context = context;

            if (_context.AssignmentDetailsItems.Count()==0)
            {
                _context.AssignmentDetailsItems.Add(new AssignmentDetailsItem 
                { 
					ProjectCode = 14001685,
					Name = "Honeywell Moundsville OM&M - 30924",
                    ProjectDesc = "Description",
					IsComplete = false,
					LabLocation = "Knoxville",
					BillTo = "Honeywell",
					ReportTo = "Honeywell International Inc",
					AEName = "NAD - East",
					JDECode = "88250",
					PercentOfProject = "100",
					LoginsAssociated = "2",
                    ListOfAEs="N/A",
					DollarValue = "615",
					Status = 3
                });
                _context.SaveChanges();
            }
        }
		
        [HttpGet]
        public IEnumerable<AssignmentDetailsItem> GetAll()
		{
			return _context.AssignmentDetailsItems.ToList();
		}

		[HttpGet("{id}", Name = "GetAssignmentDetails")]
		public IActionResult GetById(long id)
		{
			var item = _context.AssignmentDetailsItems.FirstOrDefault(t => t.Id == id);
			if (item == null)
			{
				return NotFound();
			}
			return new ObjectResult(item);
		}
		[HttpPost]
		public IActionResult Create([FromBody] AssignmentDetailsItem item)
		{
			if (item == null)
			{
				return BadRequest();
			}

			_context.AssignmentDetailsItems.Add(item);
			_context.SaveChanges();

			return CreatedAtRoute("GetAssignmentDetails", new { id = item.Id }, item);
		}

		[HttpPut("{id}")]
		public IActionResult Update(long id, [FromBody] AssignmentDetailsItem item)
		{
			if (item == null || item.Id != id)
			{
				return BadRequest();
			}

			var AssignmentDetails = _context.AssignmentDetailsItems.FirstOrDefault(t => t.Id == id);
			if (AssignmentDetails == null)
			{
				return NotFound();
			}

            AssignmentDetails.Name = item.Name;
			AssignmentDetails.IsComplete = item.IsComplete;
			AssignmentDetails.ProjectCode = item.ProjectCode;
            AssignmentDetails.ProjectDesc = item.ProjectDesc;
			AssignmentDetails.LabLocation = item.LabLocation;
			AssignmentDetails.BillTo = item.BillTo;
			AssignmentDetails.ReportTo = item.ReportTo;
			AssignmentDetails.AEName = item.AEName;
			AssignmentDetails.JDECode = item.JDECode;
			AssignmentDetails.PercentOfProject = item.PercentOfProject;
			AssignmentDetails.LoginsAssociated = item.LoginsAssociated;
            AssignmentDetails.ListOfAEs = item.ListOfAEs;
			AssignmentDetails.DollarValue = item.DollarValue;
			AssignmentDetails.Status = item.Status;
			_context.AssignmentDetailsItems.Update(AssignmentDetails);
			_context.SaveChanges();
			return new NoContentResult();
		}
		[HttpDelete("{id}")]
		public IActionResult Delete(long id)
		{
            var AssignmentDetails = _context.AssignmentDetailsItems.First(t => t.Id == id);
			if (AssignmentDetails == null)
			{
				return NotFound();
			}

			_context.AssignmentDetailsItems.Remove(AssignmentDetails);
			_context.SaveChanges();
			return new NoContentResult();
		}

    }
}
