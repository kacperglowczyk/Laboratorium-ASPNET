using Data.Entities;
using System.Collections.Generic;

namespace Data.Interfaces;

    public interface IComputerService
    {
        int Add(ComputerEntity computer);
        void Delete(int id);
        List<ComputerEntity> FindAll();
        ComputerEntity? FindById(int id);
        void Update(ComputerEntity computer);
    }
