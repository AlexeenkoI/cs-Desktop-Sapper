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
using System.Windows;
using System.Json;
using System.Web;
namespace Sapper.Src
{
    public static class Http
    {

        public static async Task<bool> RegRequest(RegData regData)
        {
            HttpContent sendContent = Json.generateRegJson(regData);  //to do class json

            var httpClient = new HttpClient();

            try
            {
                var response = await httpClient.PostAsync(QueryApi.SERVER + QueryApi.QUERY_REGISTER, sendContent); // uri will be switched for configurred baseaddr

                if (response.IsSuccessStatusCode)
                {                   
                    return true;
                    //some logic for user to show that he's succsessfully registered
                }
                if (response.StatusCode == HttpStatusCode.BadRequest)
                {                  
                    return false;
                }
                else
                {
                    //some logic for user to show that something goes wrong
                    return false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        public static async Task<AuthData> AuthRequest(string log, string pass)
        {
            var httpClient = new HttpClient();
            try
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Basic",
                Convert.ToBase64String(
                Encoding.ASCII.GetBytes(
                string.Format("{0}:{1}", log, pass))));

                var response = await httpClient.GetAsync(QueryApi.SERVER + QueryApi.QUERY_AUTH);
                string content = await response.Content.ReadAsStringAsync();
                string br = content.Remove(0, 1);
                if (response.IsSuccessStatusCode)
                {
                    AuthData constructedData = Json.parseAuthJson(br);
                    return constructedData;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }

        public static async Task<GameData> getGameData(AuthData data)
        {
            var httpClient = new HttpClient();

            HttpContent sendContent = Json.generateRequestGameDataJson(data);
            var response = await httpClient.PostAsync(QueryApi.SERVER + QueryApi.QUERY_GET_DATA, sendContent);
            var respBody = await response.Content.ReadAsStringAsync();
            respBody.Remove(0, 1);
            if (response.IsSuccessStatusCode)
            {
                GameData constructedData = Json.parseGameDataJson(respBody);
                return constructedData;
            }

            Message.show((int)response.StatusCode);
            return null;
        }

        public static async Task<bool> saveGameData(GameData gameData)
        {
            HttpClient httpClient = new HttpClient();
            HttpContent sendContent = Json.generateGameDataJson(gameData);

            var response = await httpClient.PostAsync(QueryApi.SERVER + QueryApi.QUERY_SAVE_DATA, sendContent);
            return response.IsSuccessStatusCode;
        }
    }
}
