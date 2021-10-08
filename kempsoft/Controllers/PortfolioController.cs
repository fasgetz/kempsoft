using kempsoft.Models.DataBase;
using kempsoft.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kempsoft.Controllers
{
    public class PortfolioController : Controller
    {
        private readonly IProjectService projectService;

        public PortfolioController(IProjectService projectService)
        {
            this.projectService = projectService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<ReadyProject> projects = await projectService.getAllProjects();

            return View(projects);
        }
    }
}
