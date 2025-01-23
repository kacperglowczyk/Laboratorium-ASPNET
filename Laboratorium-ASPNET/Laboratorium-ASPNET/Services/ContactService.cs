using System.Collections.Generic;
using System.Linq;
using Data.Interfaces;
using Laboratorium_ASPNET.Interfaces;
using Laboratorium_ASPNET.Models;

namespace Laboratorium_ASPNET.Services;

    public class ContactService : IContactService
    {
        private readonly IContactService _dataContactService;

        public ContactService(IContactService dataContactService)
        {
            _dataContactService = dataContactService;
        }

        public IEnumerable<Contact> FindAll()
        {
            return _dataContactService.FindAll().Select(e => new Contact
            {
                Id = e.Id,
                Name = e.Name ?? "No Name",
                Email = e.Email ?? "No Email",
                Phone = e.Phone ?? "No Phone",
                Birth = e.Birth,
                OrganizationId = e.OrganizationId,
                OrganizationName = e.Organization?.Title ?? "No Organization"
            });
        }

        public Contact FindById(int id)
        {
            var entity = _dataContactService.FindById(id);
            if (entity == null) return null;

            return new Contact
            {
                Id = entity.Id,
                Name = entity.Name,
                Email = entity.Email,
                Phone = entity.Phone,
                Birth = entity.Birth,
                OrganizationId = entity.OrganizationId,
                OrganizationName = entity.Organization?.Title
            };
        }

        public void Add(Contact contact)
        {
            var entity = new ContactEntity
            {
                Name = contact.Name,
                Email = contact.Email,
                Phone = contact.Phone,
                Birth = contact.Birth,
                OrganizationId = contact.OrganizationId
            };
            _dataContactService.Add(entity);
        }

        public void Update(Contact contact)
        {
            var entity = new ContactEntity
            {
                Id = contact.Id,
                Name = contact.Name,
                Email = contact.Email,
                Phone = contact.Phone,
                Birth = contact.Birth,
                OrganizationId = contact.OrganizationId
            };
            _dataContactService.Update(entity);
        }

        public void Delete(int id)
        {
            _dataContactService.Delete(id);
        }

        public IEnumerable<Organization> FindAllOrganizations()
        {
            return _dataContactService.FindAllOrganizations().Select(o => new Organization
            {
                Id = o.Id,
                Title = o.Title
            });
        }
    }

