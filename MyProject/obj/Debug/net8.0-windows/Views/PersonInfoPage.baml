   M S B A M L   `   `   `  ����D  @MyProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:MyProject	MyProject  5      $    MyProject.Views.PersonInfoPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:MyProject     5        N� Title$  PersonInfoPage��5	      $��Stretch=�6   $��Stretch=�6<    N� 
Background
 �   �.��5
      � .+�5   
   �� $
��Auto=�6   .��5      �  � RowDefinitions 5      �� 5      $
��Auto �6$   �� 5      $	��500 �6$   �� 5      $
��Auto �6$   .+�5      � $��50��6   $	��Top=�6#   
������ $��0��6T    � ColumnDefinitions 5      �� 5      $
��Auto �6+   �� 5      $��* �6+   �� 5      $
��Auto �6+   .+�5      �� -   5        $��30��5      
������ $	��←��6A   
�������$��40(�6`   
������ 5   9   5      � 5      $��1��6    5      �� 5      $	��300 �6+   �� 5      $��* �6+   .+�5"      �� $	��Top=�6   $��0,20,0,0q�65   $��0��6G   $	��340��6W   ��6d   �� *
Image_path+�� 5$      $��1��6!   .+�5%      �� $��36(�6:   $
��Bold"�6H   
���������6$   �� *Name+6Z   �� 5&      $��	Biography��6$   $��18(�65   $
��Bold"�6C   
�������$��0,15,0,0q�6h   �� 5(      
�������$
��Wrap=�5)      $��14(�6%   $��
0,10,10,20q�63   ��5(   7   �� *	Biography+5)   3   5*      5,      �� 5-      $��2��5.      .+�5/      �� $��Movies��6    $��18(�6.   $
��Bold"�6<   
�������$��15,10,10,20q�6a   �� 50      $��10q�6#   ��6/   �� *Movies+��51      �� 52      .R�53   "   � 54      ��56      �� 57      .R�58   "   �� -   5        ���#444$	��120��58   ;   $	��200��6G   $��10q�6T    �� CornerRadius$ 5��6`   ._�59   &   �� .+�5:   *   �� $	��160��6N   $��UniformToFill=�6[   ��60   �� *
Image_path+6[   �� 5;   *   
������� �� TextAlignment$ Center=�5=      $��5,5,5,0q�5>      $
��Wrap=�5?      ��5;   4   �� *Title+5?      5@   '   5A   #   5B      5D      5F      5H      5I      5J      5K      