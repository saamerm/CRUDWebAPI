using System;
using Microsoft.EntityFrameworkCore;

namespace TestCoreWebAPI.Models
{
	public class ReqDetailContext : DbContext
	{
		public ReqDetailContext(DbContextOptions<ReqDetailContext> options)
			: base(options)
		{
		}

		public DbSet<ReqDetailItem> ReqDetailItems { get; set; }
	}
}