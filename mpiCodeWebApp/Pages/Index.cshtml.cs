using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using mpiCodeWebApp.Data;

namespace mpiCodeWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IMpiCodeRepository _repo;
        public MPI_Code code { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IMpiCodeRepository repo)
        {
            _logger = logger;

            _repo = repo;
        }

        public void OnGet()
        {
            code = _repo.GetCode();
        }
    }
}
