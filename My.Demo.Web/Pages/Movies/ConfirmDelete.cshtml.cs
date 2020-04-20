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
    public class ConfirmDeleteModel : PageModel
    {
        private readonly IMovieQueryService queryService;
        private readonly IMovieCommandService commandService;

        public ConfirmDeleteModel(IMovieQueryService queryService,
            IMovieCommandService commandService)
        {
            this.queryService = queryService;
            this.commandService = commandService;
        }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        public Movie Movie { get; set; }
        
        public IActionResult OnGet(int id)
        {
            Movie = queryService.GetById(id).Result;
            if (Movie == null)
            {
                return RedirectToPage("../NotFound");
            }
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            Movie = commandService.Delete(id).Result;
            if (Movie == null)
            {
                return RedirectToPage("../NotFound");
            }
            return RedirectToPage("ListMovies");
        }
    }
}