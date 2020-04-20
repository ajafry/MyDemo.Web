using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using My.Demo.Data;
using My.Demo.Query.Services;
using My.Demo.Command.Services;

namespace My.Demo.Web.Pages.Principals
{
    public class ConfirmDeleteModel : PageModel
    {
        private readonly IPrincipalQueryService queryService;
        private readonly IPrincipalCommandService commandService;

        public ConfirmDeleteModel(IPrincipalQueryService queryService,
            IPrincipalCommandService commandService)
        {
            this.queryService = queryService;
            this.commandService = commandService;
        }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public Principal Principal { get; set; }

        public IActionResult OnGet(int id)
        {
            Principal = queryService.GetById(id).Result;
            if (Principal == null)
            {
                return RedirectToPage("../NotFound");
            }
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            Principal = commandService.Delete(id).Result;
            if (Principal == null)
            {
                return RedirectToPage("../NotFound");
            }
            return RedirectToPage("List");
        }
    }
}