using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darts
{
    public class Dart
    {
        public Random Random { get; set; }
        public int Score { get; set; }
        public bool IsDoubleBand { get; set; }
        public bool IsTripleBand { get; set; }
        public bool IsOuterBullseye { get; set; }
        public bool IsInnerBullseye { get; set; }

        public Dart(Random random)
        {
            Random = random;
        }
        public void Throw()
        {
            int dartBoardSection = CalculateDartBoardSection();
            Score = dartBoardSection;
            ProcessThrowAction(dartBoardSection);
        }

        private int CalculateDartBoardSection()
        {
            return Random.Next(0, 21);
        }

        private void ProcessThrowAction(int dartBoardSection)
        {
            if (dartBoardSection == 0)
                DetermineTheBullseyeLandedOn();
            else
                DetermineTheBandLandedOn();
        }

        private void CalculateScore(int score)
        {
            score = CalculateBullseyeScore(score);
            score = CalculateBandScore(score);
            Score = score;
        }

        private int CalculateBullseyeScore(int score)
        {
            if (score == 0 && IsInnerBullseye)
                score = 50;
            if (score == 0 && IsOuterBullseye)
                score = 25;
            return score;
        }

        private int CalculateBandScore(int score)
        {
            if (IsDoubleBand)
                score = score * 2;
            if (IsTripleBand)
                score = score * 3;
            return score;
        }

        private void DetermineTheBullseyeLandedOn()
        {
            if (CalculateLandingOnInnerBullseye())
                IsInnerBullseye = true;
            else
                IsOuterBullseye = true;
        }

        private void DetermineTheBandLandedOn()
        {
            if(CalculateLandingOnOuterBand())
            {
                IsDoubleBand = true;
            }
            else if(CalculateLandingOnInnerBand())
            {
                IsTripleBand = true;
            }
        }

        private bool CalculateLandingOnOuterBand()
        {
            return CalculateFivePercentChance();
        }

        private bool CalculateLandingOnInnerBand()
        {
            return CalculateFivePercentChance();
        }

        private bool CalculateLandingOnInnerBullseye()
        {
            return CalculateFivePercentChance();
        }

        private bool CalculateFivePercentChance()
        {
            int percentChance = Random.Next(0, 21);
            if (percentChance == 0)
                return true;
            else
                return false;
        }
    }
}
