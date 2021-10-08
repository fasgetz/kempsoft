using kempsoft.Models.DataBase;
using kempsoft.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kempsoft.Controllers
{


    public class ProjectController : Controller
    {
        private readonly IProjectService projectService;

        public ProjectController(IProjectService projectService)
        {
            this.projectService = projectService;
        }


        [HttpGet("Project/{id}")]
        public async Task<IActionResult> Index(int id)
        {
            ReadyProject project = await projectService.getProject(id);

            if (project == null)
            {
                return BadRequest("Проект не найден");
            }

            ViewData["Title"] = project.ProjectRoute;

            return View(project);
        }
    }
}
