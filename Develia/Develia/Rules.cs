using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Develia
{
    class Rules
    {
        public static int BONUS = 0;
        public static int LIFE = 0;
        public static int STARTING_SCORE = 0;
        public static int LIFE_SCORE = 0;
        
        public static bool isEndGame(Player player)
        {
            if (player.life > 0 ) return false;
            if (player.score > 0 ) return false;
            return true;
        }

        public static void decreaseScore(ref Player player,int score)
        {
            player.score -= score;
            if (player.score>0) return;
            player.life--;
            player.score += LIFE_SCORE;
        }

        public void increaseScore(ref Player player, int score)
        {
            player.score += score;
        }
    }
}
