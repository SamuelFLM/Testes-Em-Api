using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Persistence
{
    public class ComputerContext : DbContext
    {
        public ComputerContext(DbContextOptions<ComputerContext> options) : base(options) { }

        public DbSet<Computer> Requests { get; set; }
    }
}