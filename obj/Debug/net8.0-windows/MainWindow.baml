   M S B A M L   `   `   `  ����N  JBaseballScorekeeper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:BaseballScorekeeperBaseballScorekeeper  5   	   $    BaseballScorekeeper.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:BaseballScorekeeper     5   	     � Title$,  &Starting Lineup - Baseball Scorekeeper��5   	   $	��458��68   $	��800��6E   .��5	      � -   5         �Name$ MainGrid��5	       � ColumnDefinitions 5
   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ AwayPlayer1��5      $��Player1��6'   $��0��66   $��
0,0,30,400q�6F   �� 5   
   -   5        $ AwayPlayer2��5      $��Player2��6'   $��0��66   $��0,39,30,361q�6F   �� 5   
   -   5        $ AwayPlayer3��5      $��Player3��6'   $��0��66   $��0,78,30,317q�6F   �� 5   
   -   5        $ AwayPlayer4��5      $��Player4��6'   $��0��66   $��0,122,30,273q�6F   �� 5   
   -   5        $ AwayPlayer5��5      $��Player5��6'   $��0��66   $��0,166,30,229q�6F   �� 5   
   -   5        $ AwayPlayer6��5      $��Player6��6'   $��0��66   $��0,210,30,185q�6F   �� 5   
   -   5        $ AwayPlayer7��5      $��Player7��6'   $��0��66   $��0,254,30,141q�6F   �� 5   
   -	   5        $ AwayPlayer8��5      $��Player8��6'   $��0��66   $��0,298,30,97q�6F   �� 5   
   -
   5        $ AwayPlayer9��5      $��Player9��6'   $��0��66   $��0,342,30,53q�6F   �� 5   
   -   5        $ AwayPitcher��5      $��Pitcher��6'   $��0��66   $��
0,386,30,9q�6F   �� 5   
   -   5        $ HomePlayer1��5      $��Player1��6'   $��30,0,10,400q�66   $��1��6K   �� 5   
   -   5        $ HomePlayer2��5      $��Player2��6'   $��30,39,10,361q�66   $��1��6L   �� 5   
   -   5        $ HomePlayer3��5      $��Player3��6'   $��30,78,10,317q�66   $��1��6L   �� 5   
   -   5        $ HomePlayer4��5      $��Player4��6'   $��30,122,10,273q�66   $��1��6M   �� 5   
   -   5        $ HomePlayer5��5      $��Player5��6'   $��30,166,10,229q�66   $��1��6M   �� 5   
   -   5        $ HomePlayer6��5      $��Player6��6'   $��30,210,10,185q�66   $��1��6M   �� 5   
   -   5        $ HomePlayer7��5      $��Player7��6'   $��30,254,10,141q�66   $��1��6M   �� 5    
   -   5        $ HomePlayer8��5       $��Player8��6'   $��30,298,10,97q�66   $��1��6L   �� 5!   
   -   5        $ HomePlayer9��5!      $��Player9��6'   $��30,342,10,53q�66   $��1��6L   �� 5"   
   -   5        $ HomePitcher��5"      $��Pitcher��6'   $��30,386,10,9q�66   $��1��6K   �� 5$   
   -   5        $��0��5$      $��Start��6!   $��370,390,370,13q�61   $��2��6I   6]   5&      5'      