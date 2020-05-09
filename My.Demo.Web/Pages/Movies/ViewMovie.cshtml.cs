using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;
using My.Demo.Data;
using My.Demo.Query.Services;

namespace My.Demo.Web.Pages.Movies
{
    public class ViewMovieModel : PageModel
    {
        private readonly IMovieQueryService queryService;
        private readonly ILogger<DebugLoggerProvider> loggerDebug;

        public ViewMovieModel(IMovieQueryService queryService,
            ILogger<DebugLoggerProvider> loggerDebug)
        {
            this.queryService = queryService;
            this.loggerDebug = loggerDebug;
        }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public Movie Movie { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Movie = await queryService.GetById(id, true);
            if (Movie == null)
            {
                loggerDebug.LogWarning($"[ViewMovie][OnGet] The movie Id {id} was not found");
                //return NotFound();      // Deliberately sending a NotFound for App Insights to catch
                return RedirectToPage("../NotFound");
            }
            return Page();
        }
    }
}