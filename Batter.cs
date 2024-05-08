using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BaseballScorekeeper
{
    class Batter : Player
    {
        private float AVG = .000f;
        private int hits = 0;
        private int atBats = 0;
        private int runs = 0;
        private int homeRuns = 0;
        private int RBIs = 0;
        private List<String> plays = new List<string>();

        public Batter (string name) : base(name) {}

        public void addHit (string play, int runnersScored) //Add to at bat count, calculate average accordingly. RBIs are added for every runner that scored on the hit.
        {
            atBats++;
            hits++;
            AVG = hits / atBats;
            RBIs = RBIs + runnersScored;
            plays.Add(play);
        }

        public void addAtBat (string play) //Add an atbat when an out has happened.
        {
            atBats++;
            AVG = (hits / atBats);
            plays.Add (play);
        }

        public void addWalk (int inning) //Not an official at bat if walked, just add it to plays.
        {
            plays.Add("Walked in inning " +  inning);
        }

        public void addPlay(string play) //For miscelaneous plays.
        {
            plays.Add(play);
        }
        public void addRun (int inning) //Add to run count, plays.
        {
            runs++;
            plays.Add("Run Scored in inning " + inning);
        }

        public void addHomeRun (string play, int runnersOnBase) //Add home run, hits, and count RBIs for every batter on bases.
        {
            homeRuns++;
            hits++;
            atBats++;
            RBIs = RBIs + runnersOnBase;
            AVG = (hits / atBats);
            plays.Add(play);
        }

        public int Runs { get { return runs; } }

        public string PlaysToString() // Put array into a string for each play.
        {
            if(plays.Count == 0)
            {
                return "First AtBat.";
            }
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < plays.Count - 1; i++)
            {
                sb.Append(plays[i].ToString() + ", ");
            }
            sb.Append(plays[plays.Count - 1].ToString());
            return sb.ToString();
        }

        public override string ToString() //Print out stats for screen when up to bat.
        {
            return Name + ": " + string.Format("{0:0.000}",AVG) + ", " + hits + "-" + atBats + ", RBIs:" + RBIs + ", Home Runs: " + homeRuns + ", " + PlaysToString();
        }
    }
}
