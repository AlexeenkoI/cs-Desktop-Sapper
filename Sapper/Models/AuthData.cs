using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapper.Models
{
    public class AuthData
    {
        public int userId { get; set; }
        public string nickName { get; set; }
        public int Token { get; set; }
         
        public AuthData()
        {

        }   

        public AuthData(int id, string nickName, int Token)
        {
            this.userId = id;
            this.nickName = nickName;
            this.Token = Token;
        }
    }
}
