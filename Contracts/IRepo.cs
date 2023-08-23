namespace Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public interface IRepo<T> where T : class
    {
        void Add(T model);

        void AddRange(IEnumerable<T> models);

        IEnumerable<T> Find( Expression<Func<T, bool>> predicate,
                             params Expression<Func<T, object>>[] includedProperties );

        T Get(object id);

        void Remove(object id);

        void Update(T model);
    }
}