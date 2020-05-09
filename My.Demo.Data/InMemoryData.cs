using System;
using System.Collections.Generic;
using System.Linq;
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
                new Movie {Id = 1, Title = "Mission Impossible", Year = 1990, Language = Language.English, Genre = Genre.Action },
                new Movie {Id = 2, Title = "Casino Royale", Year = 2002, Language = Language.English, Genre = Genre.Action },
                new Movie {Id = 3, Title = "Spectre", Year = 2010, Language = Language.English, Genre = Genre.Action },
                new Movie {Id = 4, Title = "Amelie", Year = 2010, Language = Language.French, Genre = Genre.Comedy },
                new Movie {Id = 5, Title = "Kuch Kuch Hota Hai", Year = 1990, Language = Language.Hindi, Genre = Genre.Drama },
                new Movie {Id = 6, Title = "Punjabi Nahin Jaoon Gi", Year = 2010, Language = Language.Urdu, Genre = Genre.Comedy }
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
            var tmpMovie = movies.FirstOrDefault(m => m.Id == 1);
            var tmpPerson = principals.FirstOrDefault(p => p.Id == 50);
            var tmpPerson2 = principals.FirstOrDefault(p => p.Id == 51);
            moviePrincipals = new List<MoviePrincipal>()
            {
                new MoviePrincipal { Id=100, Movie=tmpMovie, Principal=tmpPerson, Role="Actor"  },
                new MoviePrincipal { Id=101, Movie=tmpMovie, Principal=tmpPerson2, Role="Actor" },
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
