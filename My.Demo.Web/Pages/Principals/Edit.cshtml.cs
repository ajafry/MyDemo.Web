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
    public class EditModel : PageModel
    {
        private readonly IPrincipalQueryService queryService;
        private readonly IPrincipalCommandService commandService;

        public EditModel(IPrincipalQueryService queryService, 
            IPrincipalCommandService commandService)
        {
            this.queryService = queryService;
            this.commandService = commandService;
        }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
        public Principal Principal { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
            {
                Principal = queryService.GetById(id.Value).Result;
            }
            else
            {
                Principal = new Principal();
            }
            if (Principal == null)
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
            Principal returnedValue = null;
            if (Principal.Id > 0)
            {
                returnedValue = commandService.Update(Principal).Result;
            }
            else
            {
                returnedValue = commandService.Create(Principal).Result;
            }
            if (returnedValue == null)
            {
                return RedirectToPage("../NotFound");
            }
            else
            {
                return RedirectToPage("List");
            }
        }
    }
}