using System.Collections.Generic;
using Data.Entities;
using System.Collections.Generic;

namespace Data.Interfaces;

    public interface IContactService
    {
        int Add(ContactEntity contact);
        void Delete(int id);
        List<ContactEntity> FindAll();
        ContactEntity FindById(int id);
        void Update(ContactEntity contact);
    }
