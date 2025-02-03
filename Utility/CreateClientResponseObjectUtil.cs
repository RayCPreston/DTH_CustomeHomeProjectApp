using System.Text.Json;
using DTH.App.Models;

namespace DTH.App.Utility
{
    public static class CreateClientResponseObjectUtil
    {
        private readonly static JsonSerializerOptions _options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
        };

        /// <summary>
        /// Creates a List&lt;HomeProjectViewModel&gt; response from a call get all projects
        /// Return empty if response is not Ok.
        /// </summary>
        /// <param name="response">HttpResponseMessage</param>
        /// <returns>List&lt;HomeProjectViewModel&gt;</returns>
        public static List<HomeProjectViewModel> CreateGetAllHomeProjectsResponse(this HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                string responseContent = response.Content.ReadAsStringAsync().Result;
                if (responseContent == null || responseContent.Length == 0)
                {
                    return new List<HomeProjectViewModel>();
                }
                List<HomeProjectViewModel>? projects = JsonSerializer.Deserialize<List<HomeProjectViewModel>>(responseContent, _options);
                return projects ?? new List<HomeProjectViewModel>();
            }
            return new List<HomeProjectViewModel>();
        }

        /// <summary>
        /// Creates a HomeProjectViewModel response from a call to get project using ProjectID
        /// </summary>
        /// <param name="response">HttpResponseMessage</param>
        /// <returns>HomeProjectViewModel</returns>
        public static HomeProjectViewModel CreateGetHomeProjectResponse(this HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                string responseContent = response.Content.ReadAsStringAsync().Result;
                if (responseContent == null || responseContent.Length == 0)
                {
                    return new HomeProjectViewModel();
                }
                HomeProjectViewModel? project = JsonSerializer.Deserialize<HomeProjectViewModel>(responseContent, _options);
                return project ?? new HomeProjectViewModel();
            }
            return new HomeProjectViewModel();
        }

        /// <summary>
        /// Creates a HomeProjectViewModel response from a call to create a project
        /// </summary>
        /// <param name="response">HttpResponseMessage</param>
        /// <returns>HomeProjectViewModel</returns>
        /// <exception cref="Exception">Thrown if the API response is bad or empty.  This means creation failed.</exception>
        public static HomeProjectViewModel CreateCreateHomeProjectResponse(this HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to create the project.");
            }
            string responseContent = response.Content.ReadAsStringAsync().Result;
            if (responseContent == null || responseContent.Length == 0)
            {
                throw new Exception("Failed to create the project.");
            }
            HomeProjectViewModel? project = JsonSerializer.Deserialize<HomeProjectViewModel>(responseContent, _options);
            return project ?? throw new Exception("Failed to properly deserialize response");
        }

        /// <summary>
        /// Creates a HomeProjectViewModel response from a call to update a project
        /// </summary>
        /// <param name="response">HttpResponseMessage</param>
        /// <returns>HomeProjectViewModel</returns>
        /// <exception cref="Exception">Thrown if the API response is bad or empty.  This means update failed.</exception>
        public static HomeProjectViewModel CreateUpdateHomeProjectResponse(this HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to update the project.");
            }
            string responseContent = response.Content.ReadAsStringAsync().Result;
            if (responseContent == null || responseContent.Length == 0)
            {
                throw new Exception("Failed to create the project.");
            }
            HomeProjectViewModel? project = JsonSerializer.Deserialize<HomeProjectViewModel>(responseContent, _options);
            return project ?? throw new Exception("Failed to properly deserialize response");
        }

        /// <summary>
        /// Creates a HomeProjectViewModel response from a call to delete a project
        /// </summary>
        /// <param name="response">HttpResponseMessage</param>
        /// <returns>HomeProjectViewModel</returns>
        /// <exception cref="Exception">Thrown if the API response is bad or empty.  This means delete failed.</exception>
        public static HomeProjectViewModel CreateDeleteHomeProjectResponse(this HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to delete the project.");
            }
            string responseContent = response.Content.ReadAsStringAsync().Result;
            if (responseContent == null || responseContent.Length == 0)
            {
                throw new Exception("Failed to delete the project.");
            }
            HomeProjectViewModel? project = JsonSerializer.Deserialize<HomeProjectViewModel>(responseContent, _options);
            return project ?? throw new Exception("Failed to properly deserialize response");
        }
    }
}
