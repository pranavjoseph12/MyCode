using System.Configuration;

namespace Nest.Task.Web.Aggregator.Helper
{
    public static class ConfigurationHelper
    {
        public static string BaseUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["APIEndPoint"].ToString();
            }
        }
    }
}
