   M S B A M L   `   `   `  ����D  @MyProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:MyProject	MyProject  5      %clr-namespace:MyProject	MyProject  5   	        MyProject.Views.MoviesPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:MyProject     5      %uclr-namespace:MyProject     5   	   $��Stretch=�5	      $��Stretch=�6%     N� 
Background  �#1B2027 N� Title$ HomePage��5
      .��5      �� $
��Auto=�6   .��5   
   �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   ���#14181C._�5      �  � ColumnDefinitions 5      �� 5      $��* �6'   �� 5      $
��Auto �6'   .+�5         MyProject.NavBar  -   5          Name$ NavBarUserControl��5      $��0��6:   5      5      �� 5!   
   $��1��6   .+�5"      �� $��Movies��6   
�������$��30,0,0,0q�69   $��40(�6K   �� 5#      $��
Use filter��6   ���#DACDCD$��	30,10,0,0q�6?   $��20(�6R   � 5$      $��10q�6    5%      �� 5&      $��7* �6'   �� 5'      $	��11* �6'   �� 5(      $
��297* �6'   .+�5*      �� $
��1000��6   $��3��6+   .+�5+      �� $��10q�6#   ��6/   �� *Movies+��5,      �� 5-      .R�5.   "   � 5/      ��51      �� 52      .R�53   "   �� -   5        ���#444$	��120��53   ;   $	��200��6G   $��10q�6T    �� CornerRadius$ 5��6`   ._�54   &   �� .+�55   *   �� $	��160��6N   $��UniformToFill=�6[   ��60   �� *
Image_path+6[   �� 56   *   
������� �� TextAlignment$ Center=�58       $��5,5,5,0q�59       $
��Wrap=�5:       ��56   4   �� *Title+5:       5;   '   5<   #   5=      5?      5@      5A      5B      5C      5D      5E      