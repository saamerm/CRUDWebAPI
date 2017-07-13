using System;
namespace TestCoreWebAPI.Models
{
	public class AssignmentDetailsItem
	{
		public long Id { get; set; }            //ProjectNo
		public long ProjectCode { get; set; }
		public string Name { get; set; }        //ProjectDesc
		public bool IsComplete { get; set; }    //Approved
		public string ProjectDesc { get; set; }  //
		public string LabLocation { get; set; }  //LabLocation
        //public string ProjectDesc { get; set; }  //
	    //public long ProjectNo { get; set; }  //
		public string BillTo { get; set; }  //
		public string ReportTo { get; set; }  //
		public string AEName { get; set; }  //
		public string JDECode { get; set; }  //
		public string PercentOfProject { get; set; }  //
		public string LoginsAssociated { get; set; }  //
		public string ListOfAEs { get; set; }  //
		public string DollarValue { get; set; }
		public int Status { get; set; }
	}
}
