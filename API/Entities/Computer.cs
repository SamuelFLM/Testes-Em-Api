using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Computer
    {
        public Computer(int id, string? brand, string? model, int year)
        {
            Id = id;
            Brand = brand;
            Model = model;
            Year = year;
        }
        public Computer(string? brand, string? model, int year)
        {
            Brand = brand;
            Model = model;
            Year = year;
        }

        public int Id { get; private set; }
        public string? Brand { get; private set; }
        public string? Model { get; private set; }
        public int Year { get; private set; }


        public void Update(string? brand, string? model, int year)
        {
            Brand = brand;
            Model = model;
            Year = year;
        }

    }
}