using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using My.Demo.Data;
using System.Threading.Tasks;
using My.Demo.Data.Postgres;
using Microsoft.EntityFrameworkCore;

namespace My.Demo.Query.Services.DB
{
    public class PrincipalQueryService : IPrincipalQueryService
    {
        private readonly IPrincipalQueryService queryService;
        private MovieDbContext db;

        public PrincipalQueryService(MovieDbContext db)
        {
            this.db = db;
        }
        public async Task<IEnumerable<Principal>> GetAll()
        {
            return await Task.FromResult(InMemoryData.Principals.AsEnumerable());
        }

        public async Task<Principal> GetById(int id, bool loadGraph = false)
        {
            var principal = await db.Principals.FindAsync(id);
            return principal;// Task.FromResult(InMemoryData.Principals.SingleOrDefault(p => p.Id == id));
        }

        public async Task<Principal> GetByName(string nameFragment, bool loadGraph = false)
        {
            var principal = await db.Principals.FirstOrDefaultAsync(
                p => p.Name.StartsWith(nameFragment, StringComparison.InvariantCultureIgnoreCase));
            return principal;
        }

        public Task<IEnumerable<MoviePrincipal>> GetPrincipalsByMovie(int movieId)
        {
            var principals = db.MoviePrincipals.Where(mp => mp.MovieId == movieId)
                .Include(m => m.Movie)
                .Include(m => m.Principal);
            return Task.FromResult(principals.AsEnumerable());
        }
    }
}
