using Laboratorium_ASPNET.Models;

namespace Laboratorium_ASPNET.Interfaces;

    public interface IContactService
    {
        IEnumerable<Contact> FindAll();
        Contact FindById(int id);
        void Add(Contact contact);
        void Update(Contact contact);
        void Delete(int id);
        IEnumerable<Organization> FindAllOrganizations();
    }
