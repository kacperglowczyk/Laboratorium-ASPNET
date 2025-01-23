using Laboratorium_ASPNET.Models;

namespace Laboratorium_ASPNET.Interfaces;

    public interface IComputerService
    {
        List<Computer> FindAll();
        Computer? FindById(int id);
        void Add(Computer computer);
        void Update(Computer computer);
        void Delete(int id);
    }
