using My.Demo.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace My.Demo.Query.Services.InMemory
{
    public class MovieQueryService : IMovieQueryService
    {
        public Task<IEnumerable<Movie>> GetAll()
        {
            return Task.FromResult(InMemoryData.Movies.AsEnumerable());
        }

        public Task<Movie> GetById(int id, bool loadGraph = false)
        {
            return Task.FromResult(InMemoryData.Movies.SingleOrDefault(m => m.Id == id));
        }

        public Task<Movie> GetByName(string nameFragment, bool loadGraph = false)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MoviePrincipal>> GetPrincipals()
        {
            throw new NotImplementedException();
        }
    }
}
