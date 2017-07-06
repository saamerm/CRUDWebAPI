using System;
namespace TestCoreWebAPI.Models
{
	public class AssignmentDetailItem
	{
		public string ProjectName { get; set; }  //
		public string LabLocation { get; set; }  //LabLocation
		public long ProjectNo { get; set; }  //
		public string ProjectDesc { get; set; }  //
		public string BillTo { get; set; }  //
		public string ReportTo { get; set; }  //
		public string AEName { get; set; }  //
		public string JDECode { get; set; }  //
		public string PercentOfProject { get; set; }  //
		public string LoginsAssociated { get; set; }  //
        public string ListOfAEs { get; set; }  //
		public string Value { get; set; }
	}
}
