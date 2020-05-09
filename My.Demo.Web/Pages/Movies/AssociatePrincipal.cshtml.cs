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
    public class AssociatePrincipalModel : PageModel
    {
        private readonly IMovieQueryService queryService;

        public AssociatePrincipalModel(IMovieQueryService queryService)
        {
            this.queryService = queryService;
        }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public Movie Movie{ get; set; }
        
        public IActionResult OnGet(int id)
        {
            Movie = queryService.GetById(id, true).Result;
            if (Movie == null)
            {
                return NotFound();      // Deliberately sending a NotFound for App Insights to catch
            }
            return Page();
        }
    }
}