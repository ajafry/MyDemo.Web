using Microsoft.Extensions.Logging;
using My.Demo.Data;
using My.Demo.Data.Postgres;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace My.Demo.Command.Services.DB
{
    public class MovieCommandService : IMovieCommandService
    {
        private readonly MovieDbContext db;
        private readonly ILogger<MovieCommandService> logger;

        public MovieCommandService(MovieDbContext db, ILogger<MovieCommandService> logger)
        {
            this.db = db;
            this.logger = logger;
        }

        public async Task<Movie> Create(Movie model)
        {
            db.Movies.Add(model);
            await db.SaveChangesAsync();
            return model;
        }

        public async Task<Movie> Delete(int id)
        {
            Movie movie = await db.Movies.FindAsync(id);
            if (movie != null)
            {
                try
                {
                    logger.LogInformation($"[{nameof(Delete)}] - Deleting Movie #{id}, {movie.Title}");
                    db.Movies.Remove(movie);
                    await db.SaveChangesAsync();
                    return movie;
                }
                catch (PostgresException pe)
                {
                    logger.LogError($"[!!!{nameof(Delete)}!!!] {pe.Message}");
                }
            }
            return null;
        }

        public async Task<Movie> Update(Movie model)
        {
            if (model == null)
            {
                return null;
            }
            var movie = await db.Movies.FindAsync(model.Id);
            if (movie == null)
            {
                return null;
            }
            else
            {
                logger.LogInformation($"[{nameof(Update)}] - Updating Movie #{movie.Id}, {movie.Title}");
                db.Movies.Update(model);
                await db.SaveChangesAsync();
            }
            return movie;
        }
    }
}
