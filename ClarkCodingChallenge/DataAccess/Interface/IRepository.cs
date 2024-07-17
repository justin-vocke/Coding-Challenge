using System.Collections;
using System.Collections.Generic;

namespace ClarkCodingChallenge.DataAccess.Interface
{
    public interface IRepository<T>
    {
        void Add(T entity);
        IEnumerable<T> GetAll(string lastName = "", bool sortByAscending = true);
    }
}
