namespace Data.Services;
using Data.Entities;
using Data.Interfaces;
using System.Collections.Generic;
using System.Linq;


    public class EFContactService : IContactService
    {
        private readonly AppDbContext _context;

        public EFContactService(AppDbContext context)
        {
            _context = context;
        }

        public int Add(ContactEntity entity)
        {
            var addedEntity = _context.Contacts.Add(entity);
            _context.SaveChanges();
            return addedEntity.Entity.Id;
        }

        public void Delete(int id)
        {
            var entity = _context.Contacts.Find(id);
            if (entity != null)
            {
                _context.Contacts.Remove(entity);
                _context.SaveChanges();
            }
        }

        public List<ContactEntity> FindAll() => _context.Contacts.ToList();

        public ContactEntity FindById(int id) => _context.Contacts.Find(id);

        public void Update(ContactEntity entity)
        {
            _context.Contacts.Update(entity);
            _context.SaveChanges();
        }
    }
