using System;
using Microsoft.EntityFrameworkCore;
namespace TestCoreWebAPI.Models
{
    public class RequestDetailsContext:DbContext
    {
        public RequestDetailsContext(DbContextOptions<RequestDetailsContext> options):base(options)
        {
        }
        public DbSet<RequestDetailsItem> RequestDetailsItems { get; set; }
    }
}
