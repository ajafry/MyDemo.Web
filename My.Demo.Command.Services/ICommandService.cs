using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace My.Demo.Command.Services
{
    public interface ICommandService<T> where T : class
    {
        Task<T> Create(T model);
        Task<T> Update(T model);
        Task<T> Delete(int id);
    }
}
