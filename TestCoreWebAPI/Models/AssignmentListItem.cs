﻿using System;
namespace TestCoreWebAPI.Models
{
	public class AssignmentListItem
	{
		public long ProjectCode { get; set; }
		public long Id { get; set; }            //ProjectNo
		public string Name { get; set; }        //ProjectDesc
		public bool IsComplete { get; set; }    //Approved
        public string ProjectDesc { get; set; }  //
		public string LabLocation { get; set; }  //LabLocation
		//public long ProjectNo { get; set; }  //
		//public string ProjectDesc { get; set; }  //
		public string BillTo { get; set; }  //
		public string ReportTo { get; set; }  //
		public string AEName { get; set; }  //
		public string JDECode { get; set; }  //
		public string PercentOfProject { get; set; }  //
		public string LoginsAssociated { get; set; }  //
		public string DollarValue { get; set; }  //
		public int Status { get; set; }  //

	}
}
