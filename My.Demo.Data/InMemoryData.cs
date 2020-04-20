using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace My.Demo.Data
{
    public static class InMemoryData
    {
        private static List<Movie> movies;
        private static List<Principal> principals;
        private static List<MoviePrincipal> moviePrincipals;

        static InMemoryData()
        {
            movies = new List<Movie>()
            {
                new Movie {Id = 1, Title = "Mission Impossible", Year = 1990},
                new Movie {Id = 2, Title = "Casino Royale", Year = 2002},
                new Movie {Id = 3, Title = "Spectre", Year = 2010 }
            };

            principals = new List<Principal>()
            {
                new Principal { Id = 50, Name = "Tom Cruise" },
                new Principal { Id = 51, Name = "Henry Cavill" },
                new Principal { Id = 52, Name = "Daniel Craig" },
                new Principal { Id = 53, Name = "Roger Moore" },
                new Principal { Id = 54, Name = "Sean Connery" },
                new Principal { Id = 55, Name = "Anne Hathaway" },
                new Principal { Id = 56, Name = "Meryll Streep" },
                new Principal { Id = 57, Name = "Robert De Niro" },
                new Principal { Id = 58, Name = "Al Pacino" }
            };

            moviePrincipals = new List<MoviePrincipal>()
            {
                new MoviePrincipal { Id=100, MovieId=1, PersonId=50, Role="Actor"  },
                new MoviePrincipal { Id=101, MovieId=1, PersonId=51, Role="Actor" },
                new MoviePrincipal { Id=102, MovieId=2, PersonId=52, Role="Actor" },
                new MoviePrincipal { Id=103, MovieId=3, PersonId=52, Role="Actor" }
            };
        }

        public static List<Movie> Movies {
            get { return movies; }
            set { movies = value; }
        }

        public static List<Principal> Principals
        {
            get { return principals; }
            set => principals = value;
        }

        public static List<MoviePrincipal> MoviePrincipals
        {
            get { return moviePrincipals; }
            set => moviePrincipals = value;
        }
    }
}
