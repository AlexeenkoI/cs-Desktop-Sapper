using Sapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Sapper.Src
{
    public static class Json
    {
        public static HttpContent generateRegJson (RegData data)
        {
            return null;
        }

        public static HttpContent generateAuthJson(AuthData data)
        {
            return null;
        }

        public static AuthData parseAuthJson (HttpResponseMessage data)
        {
            return null;
        }

        public static GameData parseGameDataJson(HttpResponseMessage data)
        {
            return null;
        }
    }
}
