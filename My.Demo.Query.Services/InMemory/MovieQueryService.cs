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
        private readonly IPrincipalQueryService queryService;

        public MovieQueryService(IPrincipalQueryService queryService)
        {
            this.queryService = queryService;
        }

        public Task<IEnumerable<Movie>> GetAll()
        {
            return Task.FromResult(InMemoryData.Movies.AsEnumerable());
        }

        public Task<Movie> GetById(int id, bool loadGraph = false)
        {
            var movie = InMemoryData.Movies.SingleOrDefault(m => m.Id == id);
            if (loadGraph)
            {
                movie.Principals = queryService.GetPrincipalsByMovie(id).Result;
                
            }
            return Task.FromResult(movie);
        }

        public Task<Movie> GetByName(string nameFragment, bool loadGraph = false)
        {
            throw new NotImplementedException();
        }
    }
}
