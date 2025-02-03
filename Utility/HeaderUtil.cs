using System.Text;

namespace DTH.App.Utility
{
    public static class HeaderUtil
    {
        public static string CreateBasicAuthHeader(string username, string password)
        {
            if(username == null || password == null ||
                username.Length == 0 || password.Length == 0)
            {
                throw new ArgumentException("Method must receive not null and not empty values");
            }
            return Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
        }
    }
}