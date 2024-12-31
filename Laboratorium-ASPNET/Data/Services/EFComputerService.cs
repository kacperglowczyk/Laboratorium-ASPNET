namespace Data.Services;
using Data.Entities;
using Data.Interfaces;
using System.Collections.Generic;
using System.Linq;

public class EFComputerService : IComputerService
{
    private readonly AppDbContext _context;

    public EFComputerService(AppDbContext context)
    {
        _context = context;
    }

    public int Add(ComputerEntity computer)
    {
        var entity = _context.Computers.Add(computer);
        _context.SaveChanges();
        return entity.Entity.Id;
    }

    public void Delete(int id)
    {
        var entity = _context.Computers.Find(id);
        if (entity != null)
        {
            _context.Computers.Remove(entity);
            _context.SaveChanges();
        }
    }

    public List<ComputerEntity> FindAll()
    {
        return _context.Computers.ToList();
    }

    public ComputerEntity? FindById(int id)
    {
        return _context.Computers.Find(id);
    }

    public void Update(ComputerEntity computer)
    {
        _context.Computers.Update(computer);
        _context.SaveChanges();
    }
}
