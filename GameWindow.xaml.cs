using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BaseballScorekeeper
{
    /// <summary>
    /// Interaction logic for GameWindow
    /// </summary>
    public partial class GameWindow : Window
    {
        private Game game;
        private CancellationTokenSource cts = new CancellationTokenSource();
        public GameWindow(string[] AwayPlayers,
                     string[] HomePlayers)
        {
            //Initialize game, set lineups from each team as done from the previous window
            InitializeComponent();
            game = new Game();
            for (int i = 0; i < AwayPlayers.Length - 1; i++)
            {
                game.AddAwayPlayer(AwayPlayers[i]);
            }
            game.AddAwayPitcher(AwayPlayers[9]);
            for (int i = 0; i < HomePlayers.Length - 1; i++)
            {
                game.AddHomePlayer(HomePlayers[i]);
            }
            game.AddHomePitcher(HomePlayers[9]);
            updateBoxScore();
            //Start checking for game end
            ThreadPool.QueueUserWorkItem(new WaitCallback(CheckForGameEnd), cts.Token);
            AtBat.Content = "At Bat: " + game.GetAwayAtBat();
            Pitcher.Content = "Pitcher: " + game.getHomePitcher();
        }

        public void CheckForGameEnd(object? obj)
        {
            if (obj == null) return;
            CancellationToken token = (CancellationToken)obj;
                while (true)
                {
                //If exiting program, break thread
                if (token.IsCancellationRequested) break;
                if (game.Inning == 13)//Game cannot go past the 13th inning in this program currently.
                {
                    Dispatcher.Invoke(new Action(() =>
                    {
                        RecordBall.IsEnabled = false;
                        RecordStrike.IsEnabled = false;
                        RecordOut.IsEnabled = false;
                        RecordInPlay.IsEnabled = false;
                        LastPlay.Content = "Game over. This program currently dosen't go past the 13th inning.";
                        Inning.Content = "FINAL";
                    }));
                    break;
                } 
                if (game.State == Game.halfInning.Bottom)
                {
                    //home wins scenario
                    if (game.Inning >= 9 && game.HomeScore > game.VisitorScore)
                    {
                        Dispatcher.Invoke(new Action(() =>
                        {
                            RecordBall.IsEnabled = false;
                            RecordStrike.IsEnabled = false;
                            RecordOut.IsEnabled = false;
                            RecordInPlay.IsEnabled = false;
                            LastPlay.Content = "Game over.";
                            Inning.Content = "FINAL";
                        }));
                        break;
                    }
                }
                else
                {
                    //Visitor wins scenario
                    if(game.Inning > 9 && game.VisitorScore > game.HomeScore && game.Outs == 0 && game.State == Game.halfInning.Top && game.battersHitInInning == 0)
                    { 
                            Dispatcher.Invoke(new Action(() =>
                            {
                                RecordBall.IsEnabled = false;
                                RecordStrike.IsEnabled = false;
                                RecordOut.IsEnabled = false;
                                RecordInPlay.IsEnabled = false;
                                LastPlay.Content = "Game over.";
                                Inning.Content = "FINAL";
                            }));
                            break;
                    }
                }
            }
        }

        public void updateBoxScore()
        {
            //Update individual box scores
            Visitor1.Content = game.boxScores[0, 0];
            Home1.Content = game.boxScores[0, 1];
            Visitor2.Content = game.boxScores[1, 0];
            Home2.Content = game.boxScores[1, 1];
            Visitor3.Content = game.boxScores[2, 0];
            Home3.Content = game.boxScores[2, 1];
            Visitor4.Content = game.boxScores[3, 0];
            Home4.Content = game.boxScores[3, 1];
            Visitor5.Content = game.boxScores[4, 0];
            Home5.Content = game.boxScores[4, 1];
            Visitor6.Content = game.boxScores[5, 0];
            Home6.Content = game.boxScores[5, 1];
            Visitor7.Content = game.boxScores[6, 0];
            Home7.Content = game.boxScores[6, 1];
            Visitor8.Content = game.boxScores[7, 0];
            Home8.Content = game.boxScores[7, 1];
            Visitor9.Content = game.boxScores[8, 0];
            Home9.Content = game.boxScores[8, 1];
            Visitor10.Content = game.boxScores[9, 0];
            Home10.Content = game.boxScores[9, 1];
            Visitor11.Content = game.boxScores[10, 0];
            Home11.Content = game.boxScores[10, 1];
            Visitor12.Content = game.boxScores[11, 0];
            Home12.Content = game.boxScores[11, 1];
            VisitorR.Content = game.VisitorScore;
            HomeR.Content = game.HomeScore;
            VisitorH.Content = game.VisitorHits;
            HomeH.Content = game.HomeHits;
            VisitorE.Content = game.VisitorErrors;
            HomeE.Content = game.HomeErrors;
            //Set inning
            string inningSide;
            if(game.State == Game.halfInning.Top)
            {
                inningSide = "Top";
            }
            else
            {
                inningSide = "Bottom";
            }
            string inning;
            switch(game.Inning)
            {
                case 1:
                    inning = "1st";
                    break;
                case 2:
                    inning = "2nd";
                    break;
                case 3:
                    inning = "3rd";
                    break;
                default:
                    inning = game.Inning + "th";
                    break;
            }
            Inning.Content = inningSide + " " + inning;
        }

        private void RecordBall_Click(object sender, RoutedEventArgs e)
        {
            //Add a ball, update content.
            bool status = game.AddBall();
            Balls.Content = "Balls: " + game.Balls;
            //If walk detected, update UI
            if (status)
            {
                updateBoxScore();
                updatePitcherBatterRunnersCount();
                LastPlay.Content = "Last Play: " + game.LastPlay;
            }
        }

        private void RecordStrike_Click(object sender, RoutedEventArgs e)
        {
            //Add a strike, update content
            bool status = game.addStrike();
            Strikes.Content = "Strikes: " + game.Strikes;
            if (status)
            {
                //If strike detected, update content
                updateBoxScore();
                updatePitcherBatterRunnersCount();
                LastPlay.Content = "Last Play: " + game.LastPlay;
            }
        }

        public void updatePitcherBatterRunnersCount()
        {
            //Update pitcher, batter, runners on bases, and count on batter.
            Balls.Content = "Balls: " + game.Balls;
            Strikes.Content = "Strikes: " + game.Strikes;
            Outs.Content = "Outs: " + game.Outs;
            if (game.State == Game.halfInning.Top)
            {
                Pitcher.Content = "Pitcher: " + game.getHomePitcher();
                AtBat.Content = "At Bat: " + game.GetAwayAtBat();

            }
            else
            {
                Pitcher.Content = "Pitcher: " + game.getAwayPitcher();
                AtBat.Content = "At Bat: " + game.GetHomeAtBat();
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("On Base: \n");
            if (game.RunnerOnFirst != null)
            {
                sb.Append("1st: " + game.RunnerOnFirst.Name + "\n");
            }
            if (game.RunnerOnSecond != null)
            {
                sb.Append("2nd: " + game.RunnerOnSecond.Name + "\n");
            }
            if (game.RunnerOnThird != null)
            {
                sb.Append("3rd: " + game.RunnerOnThird.Name + "\n");
            }
            On_Base.Content = sb.ToString();
        }

        private void RecordOut_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Enter the out choice: Yes for groundout, No for popout, Cancel for Flyout", "Out selection", MessageBoxButton.YesNoCancel);
            if (result == MessageBoxResult.Yes)
            {
                game.addBatterOuts("Groundout in inning" + game.Inning, 1);
                
            }
            else if(result == MessageBoxResult.No)
            {
                game.addBatterOuts("Popout in inning " + game.Inning, 1);
            }
            else if(result == MessageBoxResult.Cancel)
            {
                game.addBatterOuts("Flyout in inning " + game.Inning, 1);
            }
            //Update UI after out
            updateBases();
            updateBoxScore();
            updatePitcherBatterRunnersCount();
            LastPlay.Content = "Last Play: " + game.LastPlay;
        }

        private void updateBases()
        {
            //Check for advance or more outs on each base path, adjust accordingly.
            if (game.RunnerOnFirst != null && game.Outs != 3)
            {
                MessageBoxResult resultAdvance = MessageBox.Show("Did the runner on 1st advance to 2nd (Yes), did the runner stay (No), or is the runner out (Cancel)?", "Runner advanced?", MessageBoxButton.YesNoCancel);
                if (resultAdvance == MessageBoxResult.Yes)
                {
                    if (game.RunnerOnSecond != null)
                    {
                        if (game.RunnerOnThird != null)
                        {
                            game.addRuns(game.RunnerOnThird);
                            game.RunnerOnThird = game.RunnerOnSecond;
                        }
                    }
                    game.RunnerOnSecond = game.RunnerOnFirst;
                    game.RunnerOnFirst = null;
                }
                else if(resultAdvance == MessageBoxResult.Cancel)
                {
                    game.addRunnerOuts("Grounded out by way of batter in inning" + game.Inning, game.RunnerOnFirst);
                    game.RunnerOnFirst = null;
                }
            }
            if (game.RunnerOnSecond != null && game.Outs != 3)
            {
                MessageBoxResult resultAdvance = MessageBox.Show("Did the runner on 2nd advance to 3rd (yes), did they stay (no), or is the batter out (cancel)?", "Runner on 2nd", MessageBoxButton.YesNoCancel);
                if (resultAdvance == MessageBoxResult.Yes)
                {
                    if (game.RunnerOnThird != null)
                    {
                        game.addRuns(game.RunnerOnThird);

                    }
                    game.RunnerOnThird = game.RunnerOnSecond;
                    game.RunnerOnSecond = null;
                }
                else if (resultAdvance == MessageBoxResult.Cancel)
                {
                    game.addRunnerOuts("Grounded out at 2nd", game.RunnerOnSecond);
                    game.RunnerOnSecond = null;
                }
            }
            if (game.RunnerOnThird != null && game.Outs != 3)
            {
                MessageBoxResult resultAdvance = MessageBox.Show("Did the runner on 3rd advance Home(yes), did they stay (no), or are they out (cancel)?", "Runner on Third", MessageBoxButton.YesNoCancel);
                if (resultAdvance == MessageBoxResult.Yes)
                {
                    game.addRuns(game.RunnerOnThird);
                    game.RunnerOnSecond = null;
                }
                else if (resultAdvance == MessageBoxResult.Cancel)
                {
                    game.addRunnerOuts("Grounded out on bases in inning " + game.Inning, game.RunnerOnThird);
                    game.RunnerOnThird = null;
                }
            }
            LastPlay.Content = "Last Play: " + game.LastPlay;
        }

        private void RecordExit_Click()
        {
            //Cancel thread, exit environment
            cts.Cancel();
            Thread.Sleep(2500);
            cts.Dispose();
            Environment.Exit(0);
        }

        private void RecordExit_Click(object sender, RoutedEventArgs e)
        {
            //Cancel thread, exit environment from button
            cts.Cancel();
            Thread.Sleep(2500);
            cts.Dispose();
            Environment.Exit(0);
        }

        private void RecordInPlay_Click(object sender, RoutedEventArgs e)
        {
            //Determine hit, adjust runners accordingly.
            MessageBoxResult result = MessageBox.Show("What happened? \n\nSingle (Yes), Double (No), Triple/HomeRun (Cancel)", "In Play", MessageBoxButton.YesNoCancel);
            if (result == MessageBoxResult.Yes)
            {
                game.addSingle();
            }
            else if(result == MessageBoxResult.No)
            {
                game.addDouble();
            } 
            else
            {
                MessageBoxResult resultTripleHome = MessageBox.Show("Did the batter hit a triple (yes) or a home run (no)?", "Triple or Home Run", MessageBoxButton.YesNo);
                if(resultTripleHome == MessageBoxResult.Yes)
                {
                    game.addTriple();
                }
                else
                {
                    game.addHomeRun();
                }
            }
            //Update UI
            updateBases();
            updateBoxScore();
            updatePitcherBatterRunnersCount();
            LastPlay.Content = "Last Play: " + game.LastPlay;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            RecordExit_Click();
        }
    }
}
