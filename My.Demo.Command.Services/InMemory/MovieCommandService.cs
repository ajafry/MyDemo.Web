using My.Demo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace My.Demo.Command.Services.InMemory
{
    public class MovieCommandService : IMovieCommandService
    {
        public Task<Movie> Create(Movie model)
        {
            model.Id = InMemoryData.Movies.Max(m => m.Id) + 1;
            InMemoryData.Movies.Add(model);
            return Task.FromResult(model);
        }

        public Task<Movie> Delete(int id)
        {
            var movie = InMemoryData.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return null;
            }
            else
            {
                InMemoryData.Movies.Remove(movie);
                return Task.FromResult(movie);
            }
        }

        public Task<Movie> Update(Movie model)
        {
            if (model == null)
            {
                return null;
            }
            var movie = InMemoryData.Movies.SingleOrDefault(m => m.Id == model.Id);
            if (movie == null)
            {
                return null;
            }
            else
            {
                movie.Title = model.Title;
                movie.Year = model.Year;
                return Task.FromResult(movie);
            }
        }
    }
}
