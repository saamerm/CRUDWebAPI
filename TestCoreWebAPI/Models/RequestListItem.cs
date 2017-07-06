using System;
namespace TestCoreWebAPI.Models
{
	public class RequestListItem
	{
		public long Id { get; set; }            //ProjectNo
		public string Name { get; set; }        //ProjectDesc
		public bool IsComplete { get; set; }    //Approved
		//public long ProjectNo { get; set; }  //
		//public string ProjectName { get; set; }  //
	    public string LabLocation { get; set; }  //LabLocation
	    //public string ProjectDesc { get; set; }  //
	    public string BillTo { get; set; }  //
	    public string ReportTo { get; set; }  //
	    public string AEName { get; set; }  //
	    public string JDECode { get; set; }  //
	    public string PercentOfProject { get; set; }  //
	    public string LoginsAssociated { get; set; }  //
	    public string dollarValue { get; set; }  //
	    public string RequestDate { get; set; }  //
	    public string NewAEName { get; set; }  //
	    public string PercOfPrjRequested { get; set; }  //
	    public string AEComments { get; set; }  //

	}
}
