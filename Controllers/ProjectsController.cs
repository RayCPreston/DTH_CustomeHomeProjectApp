using DTH.App.Models;
using DTH.App.Services;
using DTH.App.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DTH.App.Controllers
{
    [Authorize]
    public class ProjectsController : Controller
    {
        private readonly ILogger<ProjectsController> _logger;
        private readonly HomeProjectsRestService _homeProjectsRestService;
        public ProjectsController(ILogger<ProjectsController> logger, HomeProjectsRestService homeProjectsRestService)
        {
            _logger = logger;
            _homeProjectsRestService = homeProjectsRestService;
        }

        [HttpGet]
        public IActionResult Dashboard()
        {
            try
            {
                List<HomeProjectViewModel> projects = _homeProjectsRestService.GetHomeProjects();
                return View(projects);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"ProjectsController.Dashboard.  Message: {ex.Message}");
                return RedirectToAction("Error", "Home", new { ex });
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"ProjectsController.Create.  Message: {ex.Message}");
                return RedirectToAction("Error", "Home", new { ex });
            }
        }

        [HttpPost]
        public IActionResult Create(HomeProjectViewModel project)
        {
            try
            {
                project.CreateHomeProjectId();
                ModelState.Remove("ProjectId");
                if (!ModelState.IsValid)
                {
                    return View(project);
                }
                HomeProjectViewModel createdProject = _homeProjectsRestService.CreateHomeProject(project);
                return RedirectToAction("Dashboard");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"ProjectsController.Create.  Message: {ex.Message}");
                return RedirectToAction("Error", "Home", new { ex });
            }
        }


        [HttpGet]
        [Route("Projects/Update/{projectId}")]
        public IActionResult Update([FromRoute] string projectId)
        {
            try
            {
                HomeProjectViewModel project = _homeProjectsRestService.GetHomeProject(projectId);
                return View(project);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"ProjectsController.Edit.  Message: {ex.Message}");
                return RedirectToAction("Error", "Home", new { ex });
            }
        }

        [HttpPost]
        public IActionResult Update(HomeProjectViewModel project)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(project);
                }
                HomeProjectViewModel updatedProject = _homeProjectsRestService.UpdateHomeProject(project);
                return RedirectToAction("Dashboard");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"ProjectsController.Edit.  Message: {ex.Message}");
                return RedirectToAction("Error", "Home", new { ex });
            }
        }

        [HttpDelete]
        public IActionResult Delete([FromRoute] string projectId)
        {
            try
            {
                HomeProjectViewModel project = _homeProjectsRestService.DeleteHomeProject(projectId);
                return RedirectToAction("Dashboard");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"ProjectsController.Delete.  Message: {ex.Message}");
                return RedirectToAction("Error", "Home", new { ex });
            }
        }
    }
}

