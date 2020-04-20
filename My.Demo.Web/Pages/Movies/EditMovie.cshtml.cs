using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using My.Demo.Data;
using My.Demo.Query.Services;
using My.Demo.Command.Services;

namespace My.Demo.Web.Pages.Movies
{
    public class EditMovieModel : PageModel
    {
        private readonly IMovieQueryService queryService;
        private readonly IMovieCommandService commandService;

        public EditMovieModel(IMovieQueryService queryService,
            IMovieCommandService commandService)
        {
            this.queryService = queryService;
            this.commandService = commandService;
        }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
        public Movie Movie { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
            {
                Movie = queryService.GetById(id.Value).Result;
            }
            else
            {
                Movie = new Movie();
            }
            if (Movie == null)
            {
                return RedirectToPage("../NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Movie returnedValue = null;
            if (Movie.Id > 0)
            {
                returnedValue = commandService.Update(Movie).Result;
            }
            else
            {
                returnedValue = commandService.Create(Movie).Result;
            }
            if (returnedValue == null)
            {
                return RedirectToPage("../NotFound");
            }
            else
            {
                return RedirectToPage("ListMovies");
            }
        }
    }
}