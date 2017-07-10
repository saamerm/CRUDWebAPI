using System;
using System.Collections.Generic;

namespace TestCoreWebAPI.Models
{
    public class ReqDetailItem
    {
        public long ProjectCode{ get; set; }
        public long Id { get; set; }            //ProjectNo
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
        public string dollarValue { get; set; }  //
        //public IList<LoginsAssociated> loginsAssociated { get; set; }
        //public IList<ListOfAE> listOfAEs { get; set; }
        //public class LoginsAssociated
        //{
        //    public int loginNumber { get; set; }
        //}

        //public class ListOfAE
        //{
        //    public string aeName { get; set; }
        //}
    }
}
