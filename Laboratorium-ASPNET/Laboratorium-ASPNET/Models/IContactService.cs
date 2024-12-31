namespace Laboratorium_ASPNET.Models;

public interface IContactService
{
    List<Contact> FindAll(); // Returns a list of contacts
    Contact FindById(int id); // Finds a contact by ID
    int Add(Contact contact); // Adds a contact and returns the ID
    void Update(Contact contact); // Updates a contact
    void Delete(int id); // Deletes a contact by ID
}