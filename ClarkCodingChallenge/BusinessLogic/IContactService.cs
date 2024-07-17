using ClarkCodingChallenge.Models;
using System.Collections;
using System.Collections.Generic;

namespace ClarkCodingChallenge.BusinessLogic
{
    public interface IContactService
    {
        void AddContact(Contact contact);

        IEnumerable<Contact> GetContacts(string lastName = "", bool sortByAscending = true);
    }
}
