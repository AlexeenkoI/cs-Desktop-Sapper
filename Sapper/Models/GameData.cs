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

        public GameData(int userId, int gameLvl, int gameType, TimeSpan gameTime, DateTime createTime, int gameScore)
        {
            cUserId = userId;
            cGameLvl = gameLvl;
            cGameType = gameType;
            cGameTime = gameTime;
            cCreateTime = createTime;
            cGameScore = gameScore;
        }
    }
}
