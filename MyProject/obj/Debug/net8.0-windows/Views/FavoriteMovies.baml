   M S B A M L   `   `   `  ����D  @MyProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:MyProject.ViewsMyProject.Views  5      %clr-namespace:MyProject	MyProject  5      $    MyProject.Views.FavoriteMovies   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:MyProject.Views     5      %uclr-namespace:MyProject     5        N� Title$  FavoriteMovies��5	      $��Stretch=�5      $��Stretch=�6&    N� 
Background �#1B2027 � 	Resources 5       �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius �� Padding��%�  '��       �� 5   
   " ��6   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��5   !   #��z��5   !   $ 9��5   !   # z��5   !   ._�5      �� $��Center=�6/   $��Center=�5   /   #��z��5   /   #��z��5   /   5      5      5      �� 5        � �� �#4446+   �� 5!       � ��
 �����6+   �� 5"       � ��
 ���� 6,   5#      5$      .��5%      �� $
��Auto=�6   .��5&   
   � 	 � RowDefinitions	 5(      �� 5)      $
��Auto �6    �� 5*      $��* �6    .+�5.      �� $��0��6   ���#14181C._�5/      � 
 � ColumnDefinitions
 50      �� 51      $��* �6+   �� 52      $
��Auto �6+   .+�56         MyProject.NavBar  -   5          Name$ NavBarUserControl��56      $��0��6:   5:      5;      �� 5=      $��1��6   .+�5>      �� $��Favorite Movies��6   
�������$��Center=�6F   $��40(�6c   � 5@      $��10q�6   
 5A      �� 5B      $��7* �6+   �� 5C      $	��11* �6+   �� 5D      $
��297* �6+   .+�5F      �� $
��1000��6!   $��3��6/   .+�5G      �� $��10q�6'   ��63   �� *FavoriteMovies+��5H      �� 5I   "   .R�5J   &   � 5K   #   ��5M      �� 5N   "   .R�5O   &   �� -   5        ���#444$	��120��5O   ?   $	��200��6K   $��10q�6X   $ 5��6d   ._�5P   *   �� .+�5Q   .   �� $	��160��6R   $��UniformToFill=�6_   ��64   �� *
Image_path+6_   �� 5R   .   
������� �� TextAlignment$ Center=�5T       $��5,5,5,0q�5U       $
��Wrap=�5V       ��5R   8   �� *Title+5V       5W   +   5X   '   5Y   #   5[      5\      5]      5^      5_      5`      5a      