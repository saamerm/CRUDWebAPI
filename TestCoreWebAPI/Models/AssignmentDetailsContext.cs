using System;
using Microsoft.EntityFrameworkCore;

namespace TestCoreWebAPI.Models
{
    public class AssignmentDetailsContext:DbContext
    {
        public AssignmentDetailsContext(DbContextOptions<AssignmentDetailsContext> options):base(options)
        {
        }
        public DbSet<AssignmentDetailsItem> AssignmentDetailsItems { get; set; }
    }
}

