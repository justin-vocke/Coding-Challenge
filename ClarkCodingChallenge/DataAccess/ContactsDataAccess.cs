using ClarkCodingChallenge.DataAccess.Interface;
using ClarkCodingChallenge.Models;
using System.Collections.Generic;
using System.Linq;

namespace ClarkCodingChallenge.DataAccess
{
    public class ContactsDataAccess : IRepository<Contact>
    {
        //TODO: Place data access code here
        private readonly List<Contact> _values = new List<Contact>();
        public void Add(Contact entity)
        {
            _values.Add(entity);
        }


        public IEnumerable<Contact> GetAll(string lastName = "", bool sortByAscending = true)
        {
            IEnumerable<Contact> returnValues;
            if (!string.IsNullOrEmpty(lastName))
            {
                returnValues = _values.Where(item => item.LastName == lastName);
            }
            else
            {
                returnValues = _values;
            }
            if (sortByAscending)
            {
                returnValues = returnValues.OrderBy(item => item.LastName)
                    .ThenBy(item => item.FirstName).ToList();
            }
            else
            {
                returnValues = returnValues.OrderByDescending(item => item.LastName)
                    .ThenByDescending(item => item.FirstName).ToList();
            }
            return returnValues;
        }
    }
}
