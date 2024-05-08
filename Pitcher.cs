using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing.IndexedProperties;
using System.Text;
using System.Threading.Tasks;

namespace BaseballScorekeeper
{
    class Pitcher : Player
    {
        private double ERA = 0.00;
        private int earnedRuns = 0;
        private int strikeouts = 0;
        private int walks = 0;
        private int homeRuns = 0;
        private int hits = 0;
        private double innings = 0;

        public Pitcher(string name) : base(name) { }

        public void addHit () //Add hit
        {
            hits++;
        }

        public void addWalk () //Add walk
        {
            walks++;
        }

        public void addRuns (int runs) //Add runs, calculate GPA
        {
            earnedRuns = earnedRuns + runs;
            CalculateGPA();
        }

        private void CalculateGPA() //Calculate GPA for stats using formula
        {
            ERA = 9 * earnedRuns / innings;
        }

        public void addOuts(int outs) //Add outs by adding to inning count of pitcher.
        {
            for (int i = 0; i < outs; i++)
            {
                innings = Math.Round(innings + .1, 1);
                if (Math.Round(innings % 1, 1) == 0.3)
                {
                    innings = Math.Round(innings + 0.6, 0);
                }
            }
            CalculateGPA();
        }

        public void addStrikeout() //Add out with strikeout
        {
            strikeouts++;
            addOuts(1);
        }

        public void addHomeRun() //Add a hit along with homeruns.
        {
            homeRuns++;
            hits++;
        }

        public override string ToString() //Use this for displaying the pitcher to the screen.
        {
            return Name + ": " + innings + " IP, " + hits + " H, " + earnedRuns +  " R, " + walks + " BB, " + strikeouts + " K, " + homeRuns + " HR, " + string.Format("{0:0.00}", ERA) + " ERA";
        }
    }
}
