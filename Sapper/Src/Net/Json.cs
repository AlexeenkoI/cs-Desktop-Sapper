using Sapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Json;
using System.Windows;

namespace Sapper.Src
{
    public static class Json
    {
        public static StringContent generateRegJson(RegData data)
        {
            if (data.Name != null && data.Nickname != null && data.Password != null)
            {
                JsonObject jsonObj = new JsonObject();

                jsonObj.Add("Name", data.Name);
                jsonObj.Add("Password", data.Password);
                jsonObj.Add("NickName", data.Nickname);

                StringContent res = new StringContent(jsonObj.ToString(), Encoding.UTF8, "application/json");
                
                return res;
            }
            return null;
        }

        public static StringContent generateRequestGameDataJson(AuthData data)
        {
            JsonObject jsonObj = new JsonObject();
            jsonObj.Add("Token", data.Token.ToString());
            jsonObj.Add("id", data.userId.ToString());
            StringContent res = new StringContent(jsonObj.ToString(), Encoding.UTF8, "application/json");
            return res;
        }

        public static StringContent generateGameDataJson(GameData data, AuthData authData)
        {
            if (data.cGameLvl != 0 && data.cGameType != 0)
            {
                JsonObject jsonObj = new JsonObject();
                jsonObj.Add("Token", authData.Token.ToString());
                JsonObject obj= new JsonObject();
                obj.Add("GameTime", data.cGameTime.ToString());
                obj.Add("GameType", data.cGameType);
                obj.Add("UserId", data.cUserId);
                //obj.Add("CreateTime", data.cCreateTime.ToString());
                obj.Add("GameLvl", data.cGameLvl);
                obj.Add("GameScore", data.cGameScore);
                jsonObj.Add("Data", new JsonArray(obj));
                StringContent res = new StringContent(jsonObj.ToString(), Encoding.UTF8, "application/json");
                return res;

            }
            return null;
        }

        public static AuthData parseAuthJson(string data)
        {
            JsonValue result = JsonValue.Parse(data);
            AuthData authData = new AuthData(result["id"], result["NickName"], Guid.Parse(result["Token"]));
            return authData;
        }

        public static GameData parseGameDataJson(string incdata)
        {
            JsonValue result = JsonValue.Parse(incdata);
            DateTime ts = DateTime.Parse(result["GameTime"]["date"]);
            TimeSpan TimeSpan  = new TimeSpan(ts.Hour, ts.Minute, ts.Second);
            GameData data = new GameData(result["UserId"], result["GameLvl"], result["GameType"], TimeSpan, result["GameScore"]);
            return data;
        }
    }
}
