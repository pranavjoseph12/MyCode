using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
namespace Nest.Task.Web.Helper
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