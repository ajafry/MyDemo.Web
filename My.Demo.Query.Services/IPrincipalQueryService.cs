using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using My.Demo.Data;

namespace My.Demo.Query.Services
{
    public interface IPrincipalQueryService : IQueryService<Principal>
    {
        Task<IEnumerable<MoviePrincipal>> GetPrincipalsByMovie(int movieId);
    }
}
