   M S B A M L   `   `   `  ����N  JBaseballScorekeeper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:BaseballScorekeeperBaseballScorekeeper  5      $    BaseballScorekeeper.GameWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:BaseballScorekeeper     5      -   5          � Title$!  Game - Baseball Scorekeeper��5	      .��5      � $	��450��6   $��10,6,0,6q�6   .+�5   
   �� -   5         ��Name$ 
RecordBall��5   *   $
��Ball��6>   $��33,378,613,10q�6M   $	��100��6d   �� 5   
   -   5        $ RecordStrike��5   ,   $��Strike��6B   $��182,378,464,10q�6S   $	��100��6k   �� 5   
   -   5        $ 	RecordOut��5      $	��Out��6$   $��331,378,315,10q�6J   $	��100��6b   �� 5   
   -   5        $ RecordInPlay��5      $��InPlay��6(   $��480,378,166,10q�6T   $	��100��6l   �� 5   
   -   5        $ 
RecordExit��5      $
��Exit��6>   $��629,378,17,10q�6M   $	��100��6d   �� 5   
   -   5         ��Name$ AtBat��5      $��At Bat: ��6   $��10,285,238,106q�62   �� 5   
   -   5        $ Pitcher��5      $��
Pitching: ��6!   $��105,196,428,196q�66   �� 5   
   -	   5        $ On_Base��5      $��On Base:��6!   $��459,178,65,138q�64   �� 5   
   $��1��6   $��82,0,652,422q�6   �� 5   
   $��2��6   $��110,0,652,422q�6   �� 5   
   $��3��6   $��138,0,624,422q�6   �� 5   
   $��4��6   $��166,0,596,422q�6   �� 5   
   $��5��6   $��199,0,563,422q�6   �� 5   
   $��6��6   $��232,0,530,422q�6   �� 5   
   $��7��6   $��254,0,508,422q�6   �� 5   
   $��8��6   $��282,0,480,422q�6   �� 5   
   $��9��6   $��310,0,452,422q�6   �� 5   
   $��10��6   $��338,0,424,422q�6   �� 5   
   $��11��6   $��375,0,387,422q�6   �� 5   
   $��12��6   $��408,0,354,422q�6   �� 5    
   $��Visitor��6   $��10,28,736,397q�6"   �� 5!   
   $
��Home��6   $��10,58,736,367q�6   �� 5"   
   -
   5        $ Visitor1��5"      $��-��6"   $��82,28,680,394q�6.   �� 5#   
   -   5        $ Home1��5#      $��-��6   $��82,53,680,369q�6+   �� 5$   
   -   5        $ Visitor2��5$      $��-��6"   $��105,28,657,394q�6.   �� 5%   
   -   5        $ Home2��5%      $��-��6   $��105,53,657,369q�6+   �� 5&   
   -   5        $ Visitor3��5&      $��-��6"   $��133,28,629,394q�6.   �� 5'   
   -   5        $ Home3��5'      $��-��6   $��133,53,629,369q�6+   �� 5(   
   -   5        $ Visitor4��5(      $��-��6"   $��161,28,601,394q�6.   �� 5)   
   -   5        $ Home4��5)      $��-��6   $��161,53,601,369q�6+   �� 5*   
   -   5        $ Visitor5��5*      $��-��6"   $��189,28,573,394q�6.   �� 5+   
   -   5        $ Home5��5+      $��-��6   $��189,53,573,369q�6+   �� 5,   
   -   5        $ Visitor6��5,      $��-��6"   $��226,28,536,394q�6.   �� 5-   
   -   5        $ Home6��5-      $��-��6   $��226,53,536,369q�6+   �� 5.   
   -   5        $ Visitor7��5.      $��-��6"   $��249,28,513,394q�6.   �� 5/   
   -   5        $ Home7��5/      $��-��6   $��249,53,513,369q�6+   �� 50   
   -   5        $ Visitor8��50      $��-��6"   $��277,28,485,394q�6.   �� 51   
   -   5        $ Home8��51      $��-��6   $��277,53,485,369q�6+   �� 52   
   -   5        $ Visitor9��52      $��-��6"   $��305,28,457,394q�6.   �� 53   
   -   5        $ Home9��53      $��-��6   $��305,53,457,369q�6+   �� 54   
   -   5        $ 	Visitor10��54      $��-��6#   $��334,28,428,394q�6/   �� 55   
   -   5        $ Home10��55      $��-��6    $��334,53,428,369q�6,   �� 56   
   -   5        $ 	Visitor11��56      $��-��6#   $��371,28,391,394q�6/   �� 57   
   -   5        $ Home11��57      $��-��6!   $��371,53,391,369q�6-   �� 58   
   -    5        $ 	Visitor12��58      $��-��6#   $��403,28,359,394q�6/   �� 59   
   -!   5        $ Home12��59      $��-��6    $��404,53,358,369q�6,   �� 5:   
   $��R��6   $��431,0,331,422q�6   �� 5;   
   $��H��6   $��459,0,303,422q�6   �� 5<   
   $��E��6   $��487,0,275,422q�6   �� 5=   
   -"   5        $ VisitorR��5=      $��0��6"   $��432,28,330,394q�6.   �� 5>   
   -#   5        $ HomeR��5>      $��0��6    $��429,53,333,369q�6,   �� 5?   
   -$   5        $ VisitorH��5?      $��0��6"   $��457,28,305,394q�6.   �� 5@   
   -%   5        $ HomeH��5@      $��0��6    $��457,53,305,369q�6,   �� 5A   
   -&   5        $ VisitorE��5A      $��0��6"   $��485,28,277,394q�6.   �� 5B   
   -'   5        $ HomeE��5B      $��0��6    $��485,53,277,369q�6,   �� 5C   
   -(   5        $ Inning��5C      $��Top 1st��6!   $��674,28,62,392q�63   �� 5D   
   -)   5        $ LastPlay��5D      $��Last Play: Game Started.��6"   $��18,114,514,278q�6E   �� 5E   
   -*   5        $ Balls��5E      $��Balls: 0��6   $��47,344,652,77q�62   �� 5F   
   -+   5        $ Strikes��5F      $��
Strikes: 0��6!   $��203,344,496,77q�66   �� 5G   
   -,   5        $
 Outs��5G      $��Outs: 0��6   $��340,344,359,77q�60   5L      5M      