using My.Demo.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace My.Demo.Services
{
    public interface IPrincipalQueryService : IQueryService<Principal>
    {
        Task<IEnumerable<Movie>> GetMovies();
    }
}
