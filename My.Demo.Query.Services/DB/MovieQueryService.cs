using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using My.Demo.Data;
using My.Demo.Data.Postgres;
using Microsoft.EntityFrameworkCore;

namespace My.Demo.Query.Services.DB
{
    public class MovieQueryService : IMovieQueryService
    {
        private readonly IPrincipalQueryService queryService;
        private MovieDbContext db;

        public MovieQueryService(IPrincipalQueryService queryService, MovieDbContext db)
        {
            this.queryService = queryService;
            this.db = db;
        }

        public Task<IEnumerable<Movie>> GetAll()
        {
            return Task.FromResult(db.Movies.AsEnumerable());
        }

        public async Task<Movie> GetById(int id, bool loadGraph = false)
        {
            Movie movie = null;
            //await Task.Run(() => 
            //{
                movie = db.Movies.FindAsync(id).Result;
                if (loadGraph)
                {
                    movie.Principals = queryService.GetPrincipalsByMovie(id).Result;

                }
            //});

            return await Task.FromResult(movie);
        }

        public async Task<Movie> GetByName(string nameFragment, bool loadGraph = false)
        {
            var movie = await db.Movies.FirstOrDefaultAsync(
                m => m.Title.StartsWith(nameFragment, StringComparison.InvariantCultureIgnoreCase));
            return movie;
        }
    }
}
