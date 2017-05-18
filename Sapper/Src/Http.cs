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


namespace Sapper.Src
{
    public static class Http
    {
        
        public static async Task<bool> RegRequest(RegData regData)
        {
            
            // string time = regData.regTime.ToString();
            // var sendContent = new FormUrlEncodedContent(new[] {
            //     new KeyValuePair<string, string>("login", regData.Name),
            //     new KeyValuePair<string, string>("password", regData.Password),
            //     new KeyValuePair<string, string>("nickName", regData.Nickname),
            //     new KeyValuePair<string, string>("time",time)
            // });
            HttpContent r = new StringContent("adasd");
            HttpContent sendContent = Json.generateRegJson(regData);  //to do class json
            var httpClient = new HttpClient();
            
            
            var response = await httpClient.PostAsync(uri, sendContent); // uri will be switched for configurred baseaddr
            if (response.IsSuccessStatusCode)
            {
                return true;//some logic for user to show that he's succsessfully registered
                
            }else
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
                string.Format("{0}:{1}",log,pass))));
            var response = await httpClient.GetAsync(uri); // uri will be switched for configurred baseaddr
            
            if (response.IsSuccessStatusCode)
            {
                AuthData constructedData = Json.parseAuthData(response);
                //some logic for user to show that he's succsessfully registered
                return constructedData;
            }
            else
            {
                return null;//some logic for user to show that something goes wrong

            }
        }
    }
}
