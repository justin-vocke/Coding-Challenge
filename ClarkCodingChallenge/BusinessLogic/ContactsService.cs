using ClarkCodingChallenge.DataAccess;
using ClarkCodingChallenge.DataAccess.Interface;
using ClarkCodingChallenge.Models;
using System.Collections.Generic;

namespace ClarkCodingChallenge.BusinessLogic
{
    public class ContactsService : IContactService
    {
        //TODO: Place business logic for contact here
        private readonly IRepository<Contact> _contactRepository;
        public ContactsService(IRepository<Contact> contactRepository)
        {
           _contactRepository = contactRepository;
        }
        public void AddContact(Contact contact)
        {
            _contactRepository.Add(contact);
        }

        public IEnumerable<Contact> GetContacts(string lastName = "", bool sortByAscending = true)
        {
           return _contactRepository.GetAll(lastName, sortByAscending);
        }
    }
}
