using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using My.Demo.Data;
using System.Threading.Tasks;
using My.Demo.Data.Postgres;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace My.Demo.Query.Services.DB
{
    public class PrincipalQueryService : IPrincipalQueryService
    {
        private readonly IPrincipalQueryService queryService;
        private MovieDbContext db;
        private readonly ILogger<PrincipalQueryService> logger;

        public PrincipalQueryService(MovieDbContext db, ILogger<PrincipalQueryService> logger)
        {
            this.db = db;
            this.logger = logger;
        }
        public async Task<IEnumerable<Principal>> GetAll()
        {
            logger.LogDebug($"{nameof(GetAll)} About to retrieve all Principals");
            return await Task.FromResult(db.Principals.OrderBy(p => p.Name).AsEnumerable());
        }

        public async Task<Principal> GetById(int id, bool loadGraph = false)
        {
            var principal = await db.Principals.FindAsync(id);
            return principal;
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
