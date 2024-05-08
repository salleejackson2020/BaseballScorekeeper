Baseball Scorekeeper (Demo at https://youtu.be/LGkxX6zt-Z0)

This app tries to follow the rules of MLB. Here is some documentation from MLB to try and explain Baseball: https://mktg.mlbstatic.com/mlb/official-information/2024-official-baseball-rules.pdf https://www.mlb.com/glossary

This program uses the following programming techniques:

Loops: This program uses loops in both windows:
•	In MainWindow, when start is called, it checks all text field to make sure they are not empty, and then adds the players names into an array.
•	In GameWindow, from the start it will keep on checking for the state of the game supposed to end.
Methods are used everywhere in the program to be used for common tasks like hits, outs, balls, strikes, etc.
Classes are: MainWindow, GameWindow, Game, Player, Batter, and Pitcher.
Inheritance is being used by Batter and Pitcher to inherit common things from a Player perspective.
Lists are used to keep track of all the players for both teams.
MVC is being used to keep the game logic away from UI logic as much as possible.
Multithreading is being used to always be checking for ending the game.
Exception Handling is done at the beginning for user input when a text box is blank when submitting lineups.

Basic functonality of buttons (start, balls, strikes, outs, in play, exit) have been tested and they work like they should.

DISCLAMER: This program was not designed for complex plays (like double play or triple play), errors, unearned runs, and is the simplest that this baseball scorekeeper can go.

Packages used:
using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Printing.IndexedProperties;
using System.Security.Policy;
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