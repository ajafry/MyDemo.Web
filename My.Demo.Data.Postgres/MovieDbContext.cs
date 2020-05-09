using My.Demo.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace My.Demo.Data.Postgres
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options)
            : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Principal> Principals { get; set; }
        public DbSet<MoviePrincipal> MoviePrincipals { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    string connectionString = "Server=my-movie-db.postgres.database.azure.com; Database=MovieDB2; Port=5432; User Id=\"ali@my-movie-db\"; Password=\"W3!come202O\";Ssl Mode = Require;";
        //    optionsBuilder.UseNpgsql(connectionString);
        //}
    }
}
