using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using My.Demo.Data;
using My.Demo.Query.Services;

namespace My.Demo.Web.Pages.Movies
{
    public class ListMoviesModel : PageModel
    {
        private readonly IMovieQueryService movieQueryService;

        public ListMoviesModel(IMovieQueryService movieQueryService)
        {
            this.movieQueryService = movieQueryService;
        }

        public IEnumerable<Movie> Movies { get; set; }

        public void OnGet()
        {
            Movies = movieQueryService.GetAll().Result;
        }
    }
}