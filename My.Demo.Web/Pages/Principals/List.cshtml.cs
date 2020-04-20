using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using My.Demo.Data;
using My.Demo.Query.Services;

namespace My.Demo.Web.Pages.Principals
{
    public class ListModel : PageModel
    {
        private readonly IPrincipalQueryService queryService;

        public ListModel(IPrincipalQueryService queryService)
        {
            this.queryService = queryService;
        }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public IEnumerable<Principal> Principals { get; set; }

        public void OnGet()
        {
            Principals = queryService.GetAll().Result;
        }
    }
}