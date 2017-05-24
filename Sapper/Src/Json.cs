﻿using Sapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Json;

namespace Sapper.Src
{
    public static class Json
    {
        public static StringContent generateRegJson (RegData data)
        {
            if (data.Name != null && data.Nickname != null && data.Password != null)
            {
                JsonObject jsonObj = new JsonObject();
                
                jsonObj.Add("Name", data.Name);
                jsonObj.Add("Password", data.Password);
                jsonObj.Add("NickName", data.Nickname);
                //jsonObj.Add("RegTime", data.regTime.ToString());
                
                StringContent res = new StringContent(jsonObj.ToString(), Encoding.UTF8, "application/json");
                return res;
            }
            return null;
        }

        public static StringContent generateAuthJson(AuthData data)
        {
            return null;
        }

        public static StringContent generateGameDataJson(GameData data)
        {
            if (data.cGameLvl!=0 && data.cGameType!=0) {
                JsonObject jsonObj = new JsonObject();

                jsonObj.Add("UserId", data.cUserId);
                jsonObj.Add("Difficult", data.cGameLvl);
                jsonObj.Add("GameType", data.cGameType);
                jsonObj.Add("Score", data.cGameScore);
                jsonObj.Add("Time", data.cGameTime.ToString());
                jsonObj.Add("Date", data.cCreateTime.ToString());

                StringContent res = new StringContent(jsonObj.ToString(), Encoding.UTF8, "application/json");
                return res;
            }
            return null;
        }

        public static AuthData parseAuthJson (string data)
        {
           
     
            JsonValue result = JsonValue.Parse(data);

            //int id = result["id"];
            //string nick = result["NickName"];
            //Guid token = Guid.Parse(result["Token"]);
            string t = "1";
            //AuthData authData = new AuthData(result["id"],result["NickName"],Guid.Parse(result["Token"]));
            AuthData st = new AuthData();
            return st;//authData;
        }

        public static GameData parseGameDataJson(HttpResponseMessage data)
        {
            return null;
        }
    }
}
