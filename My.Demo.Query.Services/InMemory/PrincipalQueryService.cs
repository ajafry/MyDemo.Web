using My.Demo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.Demo.Query.Services.InMemory
{
    public class PrincipalQueryService : IPrincipalQueryService
    {
        public Task<IEnumerable<Principal>> GetAll()
        {
            return Task.FromResult(InMemoryData.Principals.AsEnumerable());
        }

        public Task<Principal> GetById(int id, bool loadGraph = false)
        {
            return Task.FromResult(InMemoryData.Principals.SingleOrDefault(p => p.Id == id));
        }

        public Task<Principal> GetByName(string nameFragment, bool loadGraph = false)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<MoviePrincipal>> GetPrincipalsByMovie(int movieId)
        {
            return await Task.FromResult(InMemoryData.MoviePrincipals.FindAll(mp => mp.Movie.Id == movieId).AsEnumerable());
        }
    }
}
