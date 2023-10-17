using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;

namespace API.Persistence.Repositories
{
    public interface IComputerRepository
    {
        List<Computer> GetComputers();
        Computer? GetComputer(int id);
        void AddComputer(Computer computer);
        void UpdateComputer(Computer computer);
        void DeleteComputer(Computer computer);
    }
}