using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Persistence.Repositories
{
    public class ComputerRepository : IComputerRepository
    {
        private readonly ComputerContext _context;

        public ComputerRepository(ComputerContext context)
        {
            _context = context;
        }

        public void AddComputer(Computer computer)
        {
            _context.Requests.Add(computer);
            _context.SaveChanges();
        }

        public void DeleteComputer(Computer computer)
        {
            _context.Requests.Remove(computer);
            _context.SaveChanges();
        }

        public Computer? GetComputer(int id)
        {
            return _context.Requests.AsNoTracking().SingleOrDefault(x => x.Id == id);
        }

        public List<Computer> GetComputers()
        {
            return _context.Requests.AsNoTracking().ToList();
        }

        public void UpdateComputer(Computer computer)
        {
            _context.Requests.Update(computer);
            _context.SaveChanges();
        }
    }
}