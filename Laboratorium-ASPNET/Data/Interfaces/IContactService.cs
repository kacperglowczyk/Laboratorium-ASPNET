namespace Data.Interfaces;
    
public interface IContactService
       {
           IEnumerable<ContactEntity> FindAll();
           ContactEntity FindById(int id);
           void Add(ContactEntity contact);
           void Update(ContactEntity contact);
           void Delete(int id);
           IEnumerable<OrganizationEntity> FindAllOrganizations();
       }
   