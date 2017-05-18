using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapper.Src
{
    public static class QueryApi
    {
        public static string SERVER = ConfigurationManager.AppSettings.GetValues("HttpServer").FirstOrDefault();
        public static string PORT = ConfigurationManager.AppSettings.GetValues("Port").FirstOrDefault();
        public static string QUERY_AUTH = ConfigurationManager.AppSettings.GetValues("QueryAuth").FirstOrDefault();
        public static string QUERY_REGISTER = ConfigurationManager.AppSettings.GetValues("QueryRegister").FirstOrDefault();
        public static string QUERY_SAVE_DATA = ConfigurationManager.AppSettings.GetValues("QuerySaveData").FirstOrDefault();
        public static string QUERY_GET_DATA = ConfigurationManager.AppSettings.GetValues("QueryGetData").FirstOrDefault();
    }
}
