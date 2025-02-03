using System.Net;
using System.Text.Json;
using DTH.App.Models;
using DTH.App.Utility;

namespace DTH.App.Services
{
    public class HomeProjectsRestService
    {
        private readonly ILogger<HomeProjectsRestService> _logger;
        private readonly HomeProjectClientRequestService _service;
        public HomeProjectsRestService(ILogger<HomeProjectsRestService> logger,
            HomeProjectClientRequestService service)
        {
            _logger = logger;
            _service = service;
        }

        /// <summary>
        /// Gets all HomeProjects from the API provider.
        /// </summary>
        /// <returns>List&lt;HomeProjectViewModel%gt;</returns>
        public List<HomeProjectViewModel> GetHomeProjects()
        {
            try
            {
                HttpResponseMessage response = _service.GetAsync("get/homeprojects");
                List<HomeProjectViewModel> projects = response.CreateGetAllHomeProjectsResponse();
                return projects;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"GetHomeProjectsService.GetHomeProject Exception: {ex.Message}");
                return new List<HomeProjectViewModel>();
            }
        }

        /// <summary>
        /// Gets a single HomeProject from the API provider where the ProjectId matches the parameter.
        /// </summary>
        /// <param name="projectId">string</param>
        /// <returns>HomeProjectViewModel</returns>
        public HomeProjectViewModel GetHomeProject(string projectId)
        {
            try
            {
                HttpResponseMessage response = _service.GetAsync($"get/homeproject/projectid/{projectId}");
                HomeProjectViewModel project = response.CreateGetHomeProjectResponse();
                return project;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"GetHomeProjectsService.GetHomeProject Exception: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Creates a home project from the parameter using the API provider.
        /// </summary>
        /// <param name="project">HomeProjectViewModel</param>
        /// <returns>HomeProjectViewModel</returns>
        public HomeProjectViewModel CreateHomeProject(HomeProjectViewModel project)
        {
            try
            {
                string projectJson = JsonSerializer.Serialize(project);
                HttpResponseMessage response = _service.PostAsync("create/homeproject", projectJson);
                HomeProjectViewModel createdProject = response.CreateCreateHomeProjectResponse();
                return createdProject;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"GetHomeProjectsService.CreateHomeProject Exception: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Updates a home project using the API provider.
        /// </summary>
        /// <param name="project">HomeProjectViewModel</param>
        /// <returns>HomeProjectViewModel</returns>
        public HomeProjectViewModel UpdateHomeProject(HomeProjectViewModel project)
        {
            try
            {
                string projectJson = JsonSerializer.Serialize(project);
                HttpResponseMessage response = _service.PutAsync("update/homeproject", projectJson);
                HomeProjectViewModel updatedProject = response.CreateUpdateHomeProjectResponse();
                return updatedProject;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"GetHomeProjectsService.UpdateHomeProject Exception: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Deletes a home project using the API provider.
        /// </summary>
        /// <param name="projectId">string</param>
        /// <returns>HomeProjectViewModel</returns>
        public HomeProjectViewModel DeleteHomeProject(string projectId)
        {
            try
            {
                HttpResponseMessage response = _service.DeleteAsync($"delete/homeproject/{projectId}");
                HomeProjectViewModel project = response.CreateDeleteHomeProjectResponse();
                return project;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"GetHomeProjectsService.DeleteHomeProject Exception: {ex.Message}");
                throw;
            }
        }
    }
}
