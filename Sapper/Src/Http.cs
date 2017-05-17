using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Sapper.Enums;
using Sapper.Models;
using System.Runtime.Serialization;
namespace Sapper.Src
{
    public static class Http
    {
        
        public static async void RegRequest(RegData regData)
        {
            string uri = "1.1.1.1/";
            // string time = regData.regTime.ToString();
            // var sendContent = new FormUrlEncodedContent(new[] {
            //     new KeyValuePair<string, string>("login", regData.Name),
            //     new KeyValuePair<string, string>("password", regData.Password),
            //     new KeyValuePair<string, string>("nickName", regData.Nickname),
            //     new KeyValuePair<string, string>("time",time)
            // });
           
            var sendContent = json.generateRegJson(regData);  //to do class json
            var httpClient = new HttpClient();
            var response = await httpClient.PostAsync(uri, sendContent);
            if (response.IsSuccessStatusCode)
            {
                //some logic for user to show that he's succsessfully registered
                
            }else
            {
                //some logic for user to show that something goes wrong
                
            }

        }
    }
}
