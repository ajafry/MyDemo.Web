using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace My.Demo.Query.Services
{
    public interface IQueryService<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id, bool loadGraph = false);
        Task<T> GetByName(string nameFragment, bool loadGraph = false);
    }
}
