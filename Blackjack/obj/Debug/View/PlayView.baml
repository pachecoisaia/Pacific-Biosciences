   M S B A M L   `   `   `  ����D  @Blackjack, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Blackjack.ViewBlackjack.View  5      9!clr-namespace:Blackjack.ViewModelBlackjack.ViewModel  5          Blackjack.View.PlayView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:Blackjack.View     5      7	ViewModel!clr-namespace:Blackjack.ViewModel     5        N� Title$  PlayView��5
      .��5      � .+�5      �� $��Images/background.png��6
   $
��Fill=�6)   �� 5      $��Images/table.png��6
   $	��Top=�6$   $
��Fill=�6<   �� 5      � 5      $	��Top=�6
   $��Stretch=�6"   $��	0,60,0,20q�6A    � ColumnDefinitions 5      �� 5       � RowDefinitions 5      �� 5      $��* �6   �� 5      $��* �6   .+�5      � -   5         �Name$ 
DealerGrid��5   
   $��Center=�6   $��1��6;    5      �� 5      $��* �6   �� 5      $��* �6    5      �� 5      .+�5!      �� $	��100��6   
������ $��0��65   $��0��6E   $��0,0,0,60q�6R   $��Disabled=�6�   $��Center=�6�   
������ ��6d   �� *DealerRevealedCards+��5"      �� 5#      .R�5$   	   ��  �� Orientation$ 
Horizontal=�6   5%   	   ��5'      �� 5(      .R�5)   	   �� $��50��6(   $
��Auto��63   ��6   �� *Front+63   5*   	   5,      �� 5.      -   5         ��Name$ LvDealerHiddenCards��5.      $	��100��6,   
������ $��1��6R   $��0��6b   $��0,0,0,60q�6o   $��Disabled=�6�   $��Center=�6�   
������ ��6�   �� *DealerHiddenCard+��5/      �� 50      .R�51   	   �� $ 
Horizontal=�6   52   	   ��54      �� 55      .R�56   	   ��  ��Name$ ImageDealer��6   $��50��6<   $
��Auto��6G   ��6$   �� *Back+6G   57   	   59      5:      5;      � 5<      $��Bottom=�6
   $��Stretch=�6%   $��0,0,0,20q�6D    5=      �� 5>       5@      �� 5A      $��* �6   �� 5B      $��* �6   .+�5D      �� $	��100��6   
������ $��0��64   $��0,0,0,60q�6A   $��Disabled=�6w   $��Center=�6�   
������ ��6S   �� *PlayerCards+��5E      �� 5F      .R�5G      �� $ 
Horizontal=�6   5H      ��5J      �� 5K      .R�5L      �� $��50��6'   $
��Auto��62   ��6   �� *Front+62   5M      5O      � 5P      -   5        $ ActionsGrid��5P   
   $��Center=�6   $��1��6<    5Q      �� 5R      $��* �6   �� 5S      $��* �6    5U      �� 5V      .+�5X      �� -   5         ��Name$ BtnHit��5X      $
��Left=�6x   $	��Top=�6�   $	��100��6�   $
��Auto��6�   $��0��6�   
������ 
������ ��6   �� *
HitCommand+y�6R   �� *HitVisibility+.��5Y      �� $��Images/button_hit.png��6   $��Uniform=�6,   5Z      �� 5[      -   5        $ BtnStand��5[      $
��Left=�6i   $	��Top=�6�   $	��100��6�   $
��Auto��6�   $��1��6�   
������ 
������ ��6    �� *StandCommand+y�6A   �� *StandVisibility+.��5\      �� $��Images/button_stand.png��6   $��Uniform=�6.   5]      5^      � 5`      -   5        $ PageGrid��5`   
   $��Center=�6   $��1��69    5a      �� 5b      $��* �6    5d      �� 5e      .+�5g      �� -   5        $ BtnNext��5g      $��Center=�6\   $��Bottom=�6y   $	��100��6�   $
��Auto��6�   $��1��6�   
������ 
������ y�65   �� *NextVisibility+.��5h      �� $��Images/button_next.png��6   $��Uniform=�6-   5i      5j      5k      �� 5l      $
��Auto��6   $	��Top=�6   $��Center=�61   $	��100��6N   ._�5m      �  5n      �� 5o       5q      �� 5r      .+�5t      �� $��Images/dealer.png��6   �� 5u      $��Dealer��6   
�������$��18(�61   $��40,5,0,0q�6?   5v      5w      5x      5y      