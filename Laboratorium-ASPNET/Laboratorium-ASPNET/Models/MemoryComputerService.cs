using System.Collections.Generic;
using System.Linq;

namespace Laboratorium_ASPNET.Models;

    public class MemoryComputerService : IComputerService
    {
        private readonly List<Computer> _computers = new();

        public List<Computer> FindAll()
        {
            return _computers;
        }

        public Computer? FindById(int id)
        {
            return _computers.FirstOrDefault(c => c.Id == id);
        }

        public void Add(Computer computer)
        {
            computer.Id = _computers.Count > 0 ? _computers.Max(c => c.Id) + 1 : 1;
            _computers.Add(computer);
        }

        public void Update(Computer computer)
        {
            var existing = FindById(computer.Id);
            if (existing != null)
            {
                existing.Name = computer.Name;
                existing.Processor = computer.Processor;
                existing.Memory = computer.Memory;
                existing.Graphics = computer.Graphics;
                existing.Maker = computer.Maker;
                existing.ProductionDate = computer.ProductionDate;
                existing.Description = computer.Description;
            }
        }

        public void Delete(int id)
        {
            var computer = FindById(id);
            if (computer != null)
            {
                _computers.Remove(computer);
            }
        }
    }
