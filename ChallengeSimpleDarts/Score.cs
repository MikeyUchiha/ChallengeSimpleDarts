using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Darts;

namespace ChallengeSimpleDarts
{
    public class Score
    {
        public static void CalculateScore(Player player, Dart dart)
        {
            player.Score += CalculateScore(dart.Score, dart);
        }

        private static int CalculateScore(int score, Dart dart)
        {
            score = CalculateBullseyeScore(score, dart);
            score = CalculateBandScore(score, dart);
            return score;
        }

        private static int CalculateBullseyeScore(int score, Dart dart)
        {
            if (score == 0 && dart.IsInnerBullseye)
                score = 50;
            if (score == 0 && dart.IsOuterBullseye)
                score = 25;
            return score;
        }

        private static int CalculateBandScore(int score, Dart dart)
        {
            if (dart.IsDoubleBand)
                score = score * 2;
            if (dart.IsTripleBand)
                score = score * 3;
            return score;
        }
    }
}