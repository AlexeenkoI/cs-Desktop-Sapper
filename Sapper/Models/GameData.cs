using System;

namespace Sapper.Models
{
    public class GameData
    {
        public int cUserId  { get; set; }
        public int cGameLvl { get; set; }
        public int cGameType    { get; set; }
        public TimeSpan cGameTime   { get; set; }
        public DateTime cCreateTime { get; set; }
        public int cGameScore   { get; set; }
    }
}
