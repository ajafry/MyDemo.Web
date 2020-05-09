using My.Demo.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace My.Demo.Query.Services
{
    public interface IMovieQueryService : IQueryService<Movie> {
        //Task<IEnumerable<MoviePrincipal>> GetPrincipals();
    }
}
