using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Sapper.Enums;
using Sapper.Models;
using System.Runtime.Serialization;
using System.Net;

namespace Sapper.Src
{
    public static class Http
    {
        
        public static async Task<bool> RegRequest(RegData regData)
        {
            HttpContent sendContent = Json.generateRegJson(regData);  //to do class json

            var httpClient = new HttpClient();
            var response = await httpClient.PostAsync(QueryApi.SERVER + QueryApi.QUERY_REGISTER, sendContent); // uri will be switched for configurred baseaddr

            if (response.IsSuccessStatusCode)
            {
                return true;//some logic for user to show that he's succsessfully registered
            }
            else
            {
                //some logic for user to show that something goes wrong
                return false;
            }
        }

        public static async Task<AuthData> AuthRequest(string log, string pass)
        {
            var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Basic",
                Convert.ToBase64String(
                Encoding.ASCII.GetBytes(
                string.Format("{0}:{1}", log, pass))));

            var response = await httpClient.GetAsync(QueryApi.SERVER + QueryApi.QUERY_AUTH); // uri will be switched for configurred baseaddr

            if (response.IsSuccessStatusCode)
            {
                AuthData constructedData = Json.parseAuthJson(response);
                //some logic for user to show that he's succsessfully registered
                return constructedData;
            }
            else
            {
                return null;//some logic for user to show that something goes wrong
            }
        }

        public static async Task<GameData> getGameData (AuthData data)
        {
            var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Basic",
                Convert.ToBase64String(
                Encoding.ASCII.GetBytes(
                string.Format("{0}:{1}", Auth.login, Auth.password))));

            HttpContent sendContent = Json.generateAuthJson(data);
            var response = await httpClient.PostAsync(QueryApi.SERVER + QueryApi.QUERY_GET_DATA, sendContent);

            if (response.IsSuccessStatusCode)
            {
                GameData constructedData = Json.parseGameDataJson(response);
                return constructedData;
            }
            
            Message.show((int) response.StatusCode);
            return null;
        }

        public static async Task<bool> saveGameData(GameData gameData)
        {
            HttpClient httpClient = new HttpClient();
            HttpContent httpContent = Json.generateGameDataJson(gameData);
            //HttmpContent httpContent = Json.generateJson(gameData);

            HttpResponseMessage response = await httpClient.PostAsync(QueryApi.SERVER + QueryApi.QUERY_REGISTER, httpContent);

            return response.IsSuccessStatusCode;
        }
    }
}
