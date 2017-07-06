using System;
using Microsoft.EntityFrameworkCore;
namespace TestCoreWebAPI.Models
{
    public class AssignmentDetailContext:DbContext
    {
		public AssignmentDetailContext(DbContextOptions<AssignmentDetailContext> options)
			: base(options)
		{
        }
		public DbSet<AssignmentDetailItem> AssignmentDetailItems
	    {
	        get;
	        set;
	    }
    }
}
