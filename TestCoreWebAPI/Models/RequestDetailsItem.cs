using System;
namespace TestCoreWebAPI.Models
{
	public class RequestDetailsItem
	{
		public long Id { get; set; }            //ProjectNo
		public long ProjectCode { get; set; }
        public string Name { get; set; }        //ProjectDesc
		public bool IsComplete { get; set; }    //Approved
		public string LoginsAssociated { get; set; }  //
		public string BillTo { get; set; }  //
		public string LabLocation { get; set; }  //
		public string ReportTo { get; set; }  //
		public string AEName { get; set; }  //
		public string JDECode { get; set; }  //
		public string PercentOfProject { get; set; }  //
		public string RequestDate { get; set; }  //
		public string NewAEName { get; set; }  //
		public string PercOfPrjRequested { get; set; }  //
		public string AEComments { get; set; }  //
		public string DollarValue { get; set; }  //
		public int Status { get; set; }  //
	}
}