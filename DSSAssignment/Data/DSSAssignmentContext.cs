using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DSSAssignment.Models;

namespace DSSAssignment.Data
{
    public class DSSAssignmentContext : DbContext
    {
        public DSSAssignmentContext (DbContextOptions<DSSAssignmentContext> options)
            : base(options)
        {
        }

        public DbSet<DSSAssignment.Models.Movie>? Movie { get; set; }

    }
}
