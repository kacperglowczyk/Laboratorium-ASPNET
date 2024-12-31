using System.Collections.Generic;
using System.Linq;

namespace Laboratorium_ASPNET.Models;

public class MemoryContactService : IContactService
{
    private readonly List<Contact> _contacts = new();

    public List<Contact> FindAll()
    {
        return _contacts; // Returns the list of contacts
    }

    public Contact FindById(int id)
    {
        return _contacts.FirstOrDefault(c => c.Id == id); // Finds a contact by ID
    }

    public int Add(Contact contact)
    {
        // Assign a new ID
        contact.Id = _contacts.Any() ? _contacts.Max(c => c.Id) + 1 : 1;
        _contacts.Add(contact); // Add to the list
        return contact.Id; // Return the ID of the added contact
    }

    public void Update(Contact contact)
    {
        var existing = FindById(contact.Id);
        if (existing != null)
        {
            existing.Name = contact.Name;
            existing.Email = contact.Email;
            existing.Phone = contact.Phone;
            existing.Priority = contact.Priority;
            existing.Created = contact.Created;
        }
    }

    public void Delete(int id)
    {
        var contact = FindById(id);
        if (contact != null)
        {
            _contacts.Remove(contact);
        }
    }
}
    