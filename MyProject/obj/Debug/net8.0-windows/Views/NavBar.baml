   M S B A M L   `   `   `  ����D  @MyProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:MyProject	MyProject  5          MyProject.NavBar   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:MyProject     5      .��5	      ]� ���#14181C$��60��6%   .+�5   
   �� -   5        $��15(�5      $��9,0,0,0q�6   
�������
������ $��Center=�5   .   
������ .��5      �� -   5          ��Name$  HomeText��5   7   $
��Home��6   
�������$��Center=�6I   $��10,0,0,0q�6d   $��15(�6v   6�   5      �� 5   
   -   5        $��15(�5      $��29,0,0,0q�6   
�������
������ $��Center=�5   5   
������ .��5      �� -   5        $  FavoritesText��5   )   $��	Favorites��6   6)   5      �� 5   
   -   5        $��15(�5      $��29,0,0,0q�6   
�������
������ $��Center=�5   0   
������ .��5      �� -   5        $  WatchListText��5   )   $��	WatchList��6   6)   5      �� 5   
   -   5        $��15(�5      $��29,0,0,0q�6   
�������
������ $��Center=�5   -   
������ .��5      �� -   5        $  WatchedText��5   '   $��Watched��6   6'   5      �� 5"   
    �� Orientation$ 
Horizontal=�6   $��Right=�6.   .+�5#      ��  �� CornerRadius$ 15��6   ���#D9D9D9$��120,10,10,10q�6<    �� Padding$ 5q�6R   $	��150��6^   $��Right=�6j   ._�5$      ]� $
��True��6   .+�5&      �� -	   5         ��Name$ SearchBoxTextBox��5&   c   $��Stretch=�6   $��Center=�6<   $	��120��6W   $
��10,0q�5'      
������ 
������ $��0q�6S   $��Search��5(      69   �� 5+      -
   5        $��Right=�5+   7   
������ 
������ $��0q�6�   $��5,0,0,0q�6�   $��Center=�6�   .��5,      �� $G��AC:\Users\ADMIN\source\repos\MyProject\MyProject\Images\search.png��6    $��20��6k   5-      5.      5/      �� 50      -   5         ��Name$ AccountButton��50      
������ 
������ $��5,0,3,0q�6_   $��Center=�6p   .��51      �� $L��FC:\Users\ADMIN\source\repos\MyProject\MyProject\Images\accounticon.png��6   $��20��6h   $��20��6t   52      �� 54      -   5        $  UserNameText��54      
�������$��Center=�6C   $��0,0,10,0q�6^   6r   � 57      -   5         �Name$ AccountPopup��57      $��Bottom=�6`    � 	StaysOpen$ False��6s    � PlacementTarget 6*   �� 	 �� ElementName$	 AccountButton��.��58      �� 
�������$��1q�6-   $	��100��6A   ���#1D232A._�59      �� .+�5<      �� -   5        $��Sign out��5<   !   $��5q�64   
������ 
�������$
��Left=�6k   
������ 6�   5=      5>      5?      5@      5E      5F      