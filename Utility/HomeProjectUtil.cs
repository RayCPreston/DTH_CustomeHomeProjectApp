using DTH.App.Models;

namespace DTH.App.Utility
{
    public static class HomeProjectUtil
    {
        /// <summary>
        /// Creates a HomeProjectId by concatenating the address number and project name.
        /// </summary>
        /// <param name="homeProject">HomeProjectViewModel</param>
        public static void CreateHomeProjectId(this HomeProjectViewModel homeProject)
        {
            string addressNumber = StringUtil.CreateAddressSubstring(homeProject.StreetAddress);
            string projectId = $"{addressNumber}-{homeProject.ProjectName}";
            homeProject.ProjectId = StringUtil.RemoveWhitespace(projectId).Remove('\'');
        }
    }
}
