using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BaseballScorekeeper
{
    class Game
    {
        private List<Player> awayPlayers = new();
        private int currentAtBatAway = 0;
        private List<Player> homePlayers = new();
        private int currentAtBatHome = 0;
        private int inning = 1; public int Inning { get { return inning; } }
        public enum halfInning
        {
            Top,
            Bottom
        }
        private halfInning state = halfInning.Top; public halfInning State { get { return state; } }
        private int visitorScore = 0; public int VisitorScore { get { return visitorScore; } set { visitorScore = value; } }
        private int homeScore = 0; public int HomeScore { get { return homeScore; } set { homeScore = value; } }
        private int visitorHits = 0; public int VisitorHits { get { return visitorHits; } set { visitorHits = value; } }
        private int homeHits = 0; public int HomeHits { get { return homeHits; } set { homeHits = value; } }
        private int visitorErrors = 0; public int VisitorErrors { get { return visitorErrors; } set { visitorErrors = value; } }
        private int homeErrors = 0; public int HomeErrors { get { return homeErrors; } set { homeErrors = value; } }
        public int[,] boxScores = { { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 } };

        public string? LastPlay { get; set; }
        private int balls = 0; public int Balls { get { return balls; } }
        private int strikes = 0;  public int Strikes { get { return strikes; } }
        private int outs = 0;  public int Outs { get { return outs; } }

        public Batter? RunnerOnFirst = null;
        public Batter? RunnerOnSecond = null;
        public Batter? RunnerOnThird = null;

        public int battersHitInInning = 0;

        public void AddAwayPlayer(string playerName) {
            awayPlayers.Add(new Batter(playerName));
        }

        public void AddAwayPitcher(string playerName)
        {
            awayPlayers.Add(new Pitcher(playerName));
        }

        public void AddHomePlayer(string playerName)
        {
            homePlayers.Add(new Batter(playerName));
        }

        public void AddHomePitcher(string playerName)
        {
            homePlayers.Add(new Pitcher(playerName));
        }

        public string getHomePitcher()
        {
            return ((Pitcher)homePlayers[9]).ToString();
        }

        public string getAwayPitcher()
        {
            return ((Pitcher)awayPlayers[9]).ToString();
        }

        public string GetAwayAtBat()
        {
            Batter current = (Batter)awayPlayers[currentAtBatAway];
            return current.ToString();
        }

        public string GetHomeAtBat()
        {
            Batter current = (Batter)homePlayers[currentAtBatHome];
            return current.ToString();
        }

        public bool AddBall()
        {
            balls++;
            //Check for walk
            if(balls == 4)
            {
                //Keep track of batters that have batted in the inning in terms of help for the UI
                battersHitInInning++;
                balls = 0;
                strikes = 0;
                //Adjust pitchers and batters stats based on who is batting/pitching, adjust people on the bases and bring next up to bat.
                if(state == halfInning.Top)
                {
                    Pitcher current = (Pitcher)homePlayers[9];
                    current.addWalk();
                    Batter batter = (Batter)awayPlayers[currentAtBatAway];
                    batter.addWalk(inning);
                    
                    if (RunnerOnFirst == null)
                    {
                        RunnerOnFirst = (Batter)awayPlayers[currentAtBatAway];
                        LastPlay = batter.Name + " walked.";
                        currentAtBatAway++;
                        if(currentAtBatAway == 9)
                        {
                            currentAtBatAway = 0;
                        }
                        
                    } else if (RunnerOnSecond == null)
                    {
                        RunnerOnSecond = RunnerOnFirst;
                        RunnerOnFirst = (Batter)awayPlayers[currentAtBatAway];
                        LastPlay = batter.Name + " walked. " + RunnerOnSecond.Name + " advanced to 2nd.";
                        currentAtBatAway++;
                        if (currentAtBatAway == 9)
                        {
                            currentAtBatAway = 0;
                        }
                    } else if (RunnerOnThird == null)
                    {
                        RunnerOnThird = RunnerOnSecond;
                        RunnerOnSecond = RunnerOnFirst;
                        RunnerOnFirst = (Batter)awayPlayers[currentAtBatAway];
                        LastPlay = batter.Name + " walked. " + RunnerOnSecond + " advanced to second. " + RunnerOnThird + " advanced to third.";
                        currentAtBatAway++;
                        if (currentAtBatAway == 9)
                        {
                            currentAtBatAway = 0;
                        }
                    } else //If there is a runner on third, the bases were loaded when walk was drawn, so a runner scores.
                    {
                        RunnerOnThird.addRun(inning);
                        RunnerOnThird = RunnerOnSecond;
                        RunnerOnSecond = RunnerOnFirst;
                        RunnerOnFirst = (Batter)awayPlayers[currentAtBatAway];
                        LastPlay = batter.Name + " walked. Run scored.";
                        currentAtBatAway++;
                        if (currentAtBatAway == 9)
                        {
                            currentAtBatAway = 0;
                        }
                        current.addRuns(1);
                        visitorScore++;
                        boxScores[inning - 1, 0]++;
                    }
                }
                else //Home batting, visitors pitching.
                {
                    Pitcher current = (Pitcher)awayPlayers[9];
                    current.addWalk();
                    Batter batter = (Batter)homePlayers[currentAtBatHome];
                    batter.addWalk(inning);
                    if (RunnerOnFirst == null)
                    {
                        RunnerOnFirst = (Batter)homePlayers[currentAtBatHome];
                        LastPlay = batter.Name + " walked.";
                        currentAtBatHome++;
                        if (currentAtBatHome == 9)
                        {
                            currentAtBatHome = 0;
                        }

                    }
                    else if (RunnerOnSecond == null)
                    {
                        RunnerOnSecond = RunnerOnFirst;
                        RunnerOnFirst = (Batter)homePlayers[currentAtBatHome];
                        LastPlay = batter.Name + " walked. " + RunnerOnSecond.Name + " advanced to 2nd.";
                        currentAtBatHome++;
                        if (currentAtBatHome == 9)
                        {
                            currentAtBatHome = 0;
                        }
                    }
                    else if (RunnerOnThird == null)
                    {
                        RunnerOnThird = RunnerOnSecond;
                        RunnerOnSecond = RunnerOnFirst;
                        RunnerOnFirst = (Batter)homePlayers[currentAtBatHome];
                        LastPlay = batter.Name + " walked. " + RunnerOnSecond + " advanced to second. " + RunnerOnThird + " advanced to third.";
                        currentAtBatHome++;
                        if (currentAtBatHome == 9)
                        {
                            currentAtBatHome = 0;
                        }
                    }
                    else
                    {
                        RunnerOnThird.addRun(inning);
                        RunnerOnThird = RunnerOnSecond;
                        RunnerOnSecond = RunnerOnFirst;
                        RunnerOnFirst = (Batter)homePlayers[currentAtBatHome];
                        LastPlay = batter.Name + " walked. Run scored.";
                        currentAtBatHome++;
                        if (currentAtBatHome == 9)
                        {
                            currentAtBatHome = 0;
                        }
                        current.addRuns(1);
                        homeScore++;
                        boxScores[inning - 1, 1]++;
                    }
                }
                //return true if a walk has been detected.
                return true;
            }
            return false;
        }

        public bool addStrike()
        {
            strikes++;
            if(strikes == 3)
            {
                //if strkeout detected, keep track of the batters that have been at bat, reset count and add stats to both batter and hitter based on top or bottom of inning, send next batter up to plate
                battersHitInInning++;
                strikes = 0;
                balls = 0;
                outs++;
                if (state == halfInning.Top) //Visitors hitting, home is pitching
                {
                    Pitcher pitcher = (Pitcher)homePlayers[9];
                    pitcher.addStrikeout();
                    Batter batter = (Batter)awayPlayers[currentAtBatAway];
                    batter.addAtBat("Strikeout in inning " + inning);
                    LastPlay = batter.Name + " struckout.";
                    currentAtBatAway++;
                    if(currentAtBatAway == 9)
                    {
                        currentAtBatAway = 0;
                    }
                }
                else //Home is hitting, visitors are pitching
                {
                    Pitcher pitcher = (Pitcher)awayPlayers[9];
                    pitcher.addStrikeout();
                    Batter batter = (Batter)homePlayers[currentAtBatHome];
                    batter.addAtBat("Strikeout in inning " + inning);
                    LastPlay = batter.Name + " struckout.";
                    currentAtBatHome++;
                    if(currentAtBatHome == 9)
                    {
                        currentAtBatHome = 0;
                    }
                }
                if(outs == 3) //If end of inning, change the stats accordingly.
                {
                    LastPlay += " End of inning.";
                    endInning();
                }
                return true;
            }
            return false;
        }

        public void endInning()
        {
            //Change to bottom or top of inning, if on the bottom of the inning, its a new inning.
            if (state == halfInning.Bottom)
            {
                state = halfInning.Top;
                inning++;
            }
            else
            {
                state = halfInning.Bottom;
            }
            //Reset outs, people on bases, batters hitting in inning
            outs = 0;
            RunnerOnFirst = null;
            RunnerOnSecond = null;
            RunnerOnThird = null;
            battersHitInInning = 0;
        }

        public void addBatterOuts(string play, int outs, Batter? batter1 = null, Batter? batter2 = null)
        {
            //Adjust count on batter, increase count of batters that have hit in the inning.
            battersHitInInning++;
            balls = 0;
            strikes = 0;
            this.outs++;
            Pitcher pitcher;
            //Adjust stats of batter and pitcher accordingly.
            if(state == halfInning.Top)
            {
                pitcher = (Pitcher)homePlayers[9];
                pitcher.addOuts(outs);
                Batter batter = (Batter)awayPlayers[currentAtBatAway];
                batter.addAtBat(play);
                LastPlay = batter.Name + " " + play;
                currentAtBatAway++;
                if (currentAtBatAway == 9)
                {
                    currentAtBatAway = 0;
                }
            } else
            {
                pitcher = (Pitcher)awayPlayers[9];
                pitcher.addOuts(outs);
                Batter batter = (Batter)homePlayers[currentAtBatHome];
                LastPlay = batter.Name + " " + play;
                batter.addAtBat(play);
                currentAtBatHome++;
                if(currentAtBatHome == 9)
                {
                    currentAtBatHome = 0;
                }
            }
            //This is for double or triple plays, later functonality.
            if (batter1 != null && outs != 3) {
                batter1.addPlay(play);
                this.outs++;
            }
            if (batter2 != null && outs != 3)
            {
                batter2.addPlay(play);
                this.outs++;
            }
            if(this.outs == 3) //If end of inning, finish the inning.
            {
                LastPlay += " End of inning.";
                endInning();
            }
        }
        public void addRunnerOuts(string play, Batter? batter1 = null, Batter? batter2 = null, Batter? batter3 = null)
        {
            //This is for adding outs on the base paths.
            Pitcher pitcher;
            if(state == halfInning.Top)
            {
                pitcher= (Pitcher)homePlayers[9];
            }
            else
            {
                pitcher = (Pitcher)awayPlayers[9];
            }
            //Adjust stats of batter out and pitcher
            if (batter1 != null && outs != 3)
            {
                batter1.addPlay(play);
                LastPlay = " " + batter1.Name + " " + play;
                pitcher.addOuts(1);
                outs++;
            }
            if (batter2 != null && outs != 3)
            {
                batter2.addPlay(play);
                LastPlay += " " + batter2.Name + " " + play;
                pitcher.addOuts(1);
                outs++;
            }
            if (batter3 != null && outs != 3)
            {
                batter3.addPlay(play);
                LastPlay += " " + batter3.Name + " " + play;
                pitcher.addOuts(1);
                outs++;
            }
            if(outs == 3) //End the inning if three outs.
            {
                LastPlay += " End of inning.";
                endInning();
            }
        }

        public void addSingle() //Add a base hit to the stats, adjust people on the bases accordingly to make room for battter.
        {
            battersHitInInning++;
            Batter current;
            int runnersScored = 0;
            if(state == halfInning.Top)
            {
                Pitcher pitcher = (Pitcher)homePlayers[9];
                pitcher.addHit();
                current = (Batter)awayPlayers[currentAtBatAway];
                LastPlay = current.Name + " Singled.";
                currentAtBatAway++;
                visitorHits++;
            }
            else
            {
                Pitcher pitcher = (Pitcher)awayPlayers[9];
                pitcher.addHit();
                current = (Batter)homePlayers[currentAtBatHome];
                LastPlay = current.Name + " Singled.";
                currentAtBatHome++;
                homeHits++;
            }
            if(RunnerOnFirst != null) { 
                if(RunnerOnSecond != null)
                {
                    if(RunnerOnThird != null) //Bases were loaded when batter had a base hit.
                    {
                        addRuns(RunnerOnThird);
                        runnersScored++;
                    }
                    RunnerOnThird = RunnerOnSecond;
                }
                RunnerOnSecond = RunnerOnFirst;
            }
            RunnerOnFirst = current;
            if (runnersScored != 0)
            {
                LastPlay += " " + runnersScored + " runners scored.";
            }
            current.addHit("Single in Inning " + Inning, runnersScored);
        }

        public void addDouble() //Put batter on 2nd base, adjust people on the base paths accordingly.
        {
            battersHitInInning++;
            Batter current;
            int runnersScored = 0;
            if (state == halfInning.Top)
            {
                Pitcher pitcher = (Pitcher)homePlayers[9];
                pitcher.addHit();
                current = (Batter)awayPlayers[currentAtBatAway];
                currentAtBatAway++;
                LastPlay = current.Name + " Doubled.";
                visitorHits++;
            }
            else
            {
                Pitcher pitcher = (Pitcher)awayPlayers[9];
                pitcher.addHit();
                current = (Batter)homePlayers[currentAtBatHome];
                LastPlay = current.Name + " Doubled.";
                currentAtBatHome++;
                homeHits++;
            }
            if(RunnerOnFirst != null)
            {
                if(RunnerOnSecond != null)
                {
                    if(RunnerOnThird != null)
                    {
                        //The double made two people on the base paths go home, bases were loaded.
                        addRuns(RunnerOnThird);
                        runnersScored++;
                    }
                    addRuns(RunnerOnSecond);
                    runnersScored++;
                }
                RunnerOnThird = RunnerOnFirst;
            } else if (RunnerOnSecond != null)
            {
                if(RunnerOnThird != null)
                {
                    addRuns(RunnerOnThird); //Runners on 2nd and 3rd, the runner on 3rd has to score.
                    runnersScored++;
                }
                RunnerOnThird = RunnerOnSecond;
            }
            RunnerOnSecond = current;
            RunnerOnFirst = null;
            if (runnersScored != 0)
            {
                LastPlay += " " + runnersScored + " runners scored.";
            }
            current.addHit("Double in Inning " + Inning, runnersScored);
        }

        public void addTriple() //Add triple to stats of pitcher and batter, adjust people on the base paths accordingly.
        {
            battersHitInInning++;
            Batter current;
            int runnersScored = 0;
            if (state == halfInning.Top)
            {
                Pitcher pitcher = (Pitcher)homePlayers[9];
                pitcher.addHit();
                current = (Batter)awayPlayers[currentAtBatAway];
                currentAtBatAway++;
                LastPlay = current.Name + " Tripled.";
                visitorHits++;
            }
            else
            {
                Pitcher pitcher = (Pitcher)awayPlayers[9];
                pitcher.addHit();
                current = (Batter)homePlayers[currentAtBatHome];
                currentAtBatHome++;
                homeHits++;
            }
            if(RunnerOnFirst != null)
            {
                if(RunnerOnSecond != null)
                {
                    if(RunnerOnThird != null)
                    {
                        addRuns(RunnerOnThird); //Bases were loaded, bases have to clear.
                        runnersScored++;
                    }
                    addRuns(RunnerOnSecond);
                    runnersScored++;
                }
                addRuns(RunnerOnFirst);
                runnersScored++;
            } else if(RunnerOnSecond != null)
            {
                if(RunnerOnThird != null)
                {
                    addRuns(RunnerOnThird); //Runners on 2nd and 3rd, bases have to clear.
                    runnersScored++;
                }
                addRuns(RunnerOnSecond);
                runnersScored++;
            } else if(RunnerOnThird != null)
            {
                addRuns(RunnerOnThird);
                runnersScored++;
            }
            RunnerOnThird = current;
            RunnerOnSecond = null;
            RunnerOnFirst = null;
            if (runnersScored != 0)
            {
                LastPlay += " " + runnersScored + " runners scored.";
            }
            current.addHit("Tripled in Inning" + inning, runnersScored);
        }

        public void addHomeRun() //Clear bases, add home run to stats of pitcher and batter.
        {
            battersHitInInning++;
            Pitcher pitcher;
            Batter current;
            int runnersScored = 0;
            if (state == halfInning.Top)
            {
                pitcher = (Pitcher)homePlayers[9];
                current = (Batter)awayPlayers[currentAtBatAway];
                currentAtBatAway++;
                visitorHits++;
            }
            else
            {
                pitcher = (Pitcher)awayPlayers[9];
                current = (Batter)homePlayers[currentAtBatHome];
                currentAtBatHome++;
                homeHits++;
            }
            LastPlay = current.Name + " Homered.";
            if (RunnerOnFirst != null) {
                addRuns(RunnerOnFirst);
                runnersScored++;
                RunnerOnFirst = null;
            }
            if (RunnerOnSecond != null) { 
                addRuns(RunnerOnSecond);
                runnersScored++;
                RunnerOnSecond = null;
            } if (RunnerOnThird != null)
            {
                addRuns(RunnerOnThird);
                runnersScored++;
                RunnerOnThird = null;
            }
            current.addHomeRun("Homered in Inning" + Inning, runnersScored);
            pitcher.addHomeRun();
            if (runnersScored != 0)
            {
                LastPlay += " " + runnersScored + " runners scored.";
            }
            addRuns(current);
        }

        public void addRuns(Batter? batter1 = null, Batter? batter2 = null, Batter? batter3 = null) { //Add runs to score and stats accordingly.
            Pitcher current;
            if(state == halfInning.Top)
            {
                current = (Pitcher)homePlayers[9];
            }
            else
            {
                current = (Pitcher)awayPlayers[9];
            }
            if(batter1 != null)
            {
                current.addRuns(1);
                batter1.addRun(Inning);
                if (state == halfInning.Top)
                {
                    visitorScore++;
                    boxScores[inning - 1, 0]++;
                    
                } else
                {
                    homeScore++;
                    boxScores[inning - 1, 1]++;
                }
            }
            if (batter2 != null)
            {
                current.addRuns(1);
                batter2.addRun(Inning);
                if (state == halfInning.Top)
                {
                    visitorScore++;
                    boxScores[inning - 1, 0]++;

                }
                else
                {
                    homeScore++;
                    boxScores[inning - 1, 1]++;
                }
            }
            if (batter3 != null)
            {
                current.addRuns(1);
                batter3.addRun(Inning);
                if (state == halfInning.Top)
                {
                    visitorScore++;
                    boxScores[inning - 1, 0]++;

                }
                else
                {
                    homeScore++;
                    boxScores[inning - 1, 1]++;
                }
            }
        }
    }
}
