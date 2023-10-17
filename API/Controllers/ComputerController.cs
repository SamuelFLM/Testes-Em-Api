using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("v1/computer")]
    public class ComputerController : ControllerBase
    {

        private readonly IComputerRepository _repository;

        public ComputerController(IComputerRepository respository)
        {
            _repository = respository;
        }

        [HttpGet]
        public IActionResult GetComputers()
        {
            var computers = _repository.GetComputers();
            return Ok(computers);
        }

        [HttpGet("{id}")]
        public IActionResult GetComputer(int id)
        {

            var computer = _repository.GetComputer(id);

            if (computer == null)
                return NotFound();

            return Ok(computer);
        }

        [HttpPost]
        public IActionResult Post(AddComputerDTO model)
        {

            Computer computer = new Computer(model.Brand, model.Model, model.Year);

            _repository.AddComputer(computer);

            return CreatedAtAction(nameof(GetComputer), new { id = computer.Id }, computer);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateComputerDTO model)
        {
            var computer = _repository.GetComputer(id);

            if (computer == null)
                return NotFound();

            computer.Update(model.Brand, model.Model, model.Year);

            _repository.UpdateComputer(computer);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var computer = _repository.GetComputer(id);

            if (computer == null)
                return NotFound();

            _repository.DeleteComputer(computer);

            return NoContent();
        }
    }
}