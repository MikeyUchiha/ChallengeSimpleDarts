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
            Score = CalculateDartBoardSection();
            ProcessThrowAction(Score);
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
