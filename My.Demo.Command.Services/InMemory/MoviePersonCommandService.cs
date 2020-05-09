using My.Demo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.Demo.Command.Services.InMemory
{
    public class MoviePersonCommandService : IMoviePersonCommandService
    {
        public Task<MoviePrincipal> Create(MoviePrincipal model)
        {
            model.Id = InMemoryData.MoviePrincipals.Max(m => m.Id) + 1;
            InMemoryData.MoviePrincipals.Add(model);
            return Task.FromResult(model);
        }

        public Task<MoviePrincipal> Delete(int id)
        {
            var movie = InMemoryData.MoviePrincipals.SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return null;
            }
            else
            {
                InMemoryData.MoviePrincipals.Remove(movie);
                return Task.FromResult(movie);
            }
        }

        public Task<MoviePrincipal> Update(MoviePrincipal model)
        {
            throw new NotImplementedException();
        }
    }
}
