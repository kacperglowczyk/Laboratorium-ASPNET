using Data.Entities;
using Data.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Data.Services;

public class EFContactService : IContactService
{
    private readonly AppDbContext _context;

    public EFContactService(AppDbContext context)
    {
        _context = context;
    }

    public int Add(ContactEntity contact)
    {
        _context.Contacts.Add(contact);
        _context.SaveChanges();
        return contact.Id;
    }

    public void Delete(int id)
    {
        var contact = _context.Contacts.Find(id);
        if (contact != null)
        {
            _context.Contacts.Remove(contact);
            _context.SaveChanges();
        }
    }

    public void Update(ContactEntity contact)
    {
        _context.Contacts.Update(contact);
        _context.SaveChanges();
    }

    public List<ContactEntity> FindAll()
    {
        return _context.Contacts.Include(c => c.Organization).ToList();
    }

    public ContactEntity? FindById(int id)
    {
        return _context.Contacts.Include(c => c.Organization).FirstOrDefault(c => c.Id == id);
    }

    // Nowa metoda
    public List<OrganizationEntity> FindAllOrganizations()
    {
        return _context.Organizations.ToList();
    }
}