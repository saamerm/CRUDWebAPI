using System;
using Microsoft.EntityFrameworkCore;
namespace TestCoreWebAPI.Models
{
    public class AssignmentListContext:DbContext
    {
		public AssignmentListContext(DbContextOptions<AssignmentListContext> options)
			: base(options)
		{
        }
		public DbSet<AssignmentListItem> AssignmentListItems
	    {
	        get;
	        set;
	    }
    }
}
