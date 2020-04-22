using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using My.Demo.Data;
using My.Demo.Query.Services;
using My.Demo.Command.Services;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace My.Demo.Web.Pages.Movies
{
    public class AddEditMovieModel : PageModel
    {
        private readonly IMovieQueryService queryService;
        private readonly IMovieCommandService commandService;
        private readonly IHtmlHelper htmlHelper;
        private readonly List<SelectListItem> genres;
        private readonly List<SelectListItem> languages;

        public AddEditMovieModel(IMovieQueryService queryService,
            IMovieCommandService commandService,
            IHtmlHelper htmlHelper)
        {
            this.queryService = queryService;
            this.commandService = commandService;
            this.htmlHelper = htmlHelper;

            Genres = htmlHelper.GetEnumSelectList<Genre>();
            Languages = htmlHelper.GetEnumSelectList<Language>();
        }

        public IEnumerable<SelectListItem> Genres { get; set; }
        public IEnumerable<SelectListItem> Languages { get; set; }


        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
        public Movie Movie { get; set; }

        public string PageTitle { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
            {
                PageTitle = "Edit Movie";
                Movie = queryService.GetById(id.Value).Result;
            }
            else
            {
                PageTitle = "Add Movie";
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
            if (Movie.Id > 0)
            {
                Movie = commandService.Update(Movie).Result;
            }
            else
            {
                Movie = commandService.Create(Movie).Result;
            }
            if (Movie == null)
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