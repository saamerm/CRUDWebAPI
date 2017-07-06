using System;
using Microsoft.EntityFrameworkCore;
namespace TestCoreWebAPI.Models
{
	public class RequestListContext : DbContext
	{
		public RequestListContext(DbContextOptions<RequestListContext> options)
			: base(options)
		{
		}
		public DbSet<RequestListItem> RequestListItems
		{
			get;
			set;
		}
	}
}
