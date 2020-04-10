using System;
using System.Collections.Generic;

namespace FootballWebSiteApi.Repository
{
    public interface IDatabaseRepository<T>: IDisposable
    {
        IEnumerable<T> Get();
        T Get(string id);
        T Post(T value);
        T Put(string id, T value);
        void Delete(string id);
    }
}