   M S B A M L   `   `   `  ����D  @MyProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:MyProject	MyProject  5           MyProject.Views.SignUpPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:MyProject     5        N� 
Background
  �����$��Stretch=�5	      $��Stretch=�6%    N� Title$ 
SignUpPage��5
      .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   � $��0��6   ���#5138EE.+�5      �� $��Center=�6   $��Center=�66   .+�5      �� $��Welcome to MOVIEDB��6   $��40(�66   $
��Bold"�6D   
�������$��0,0,0,5q�6i   �� 5      $��Create a new account��6   
�������68   �� 5      $��Already have an account?��6   
�������6<   �� 5      -   5        $��Sign in��5      
�������$��
10,55,10,5q�5      $	��100��5      $��34��5      $��12(�5      $��Center=�5       � 	Resources 5        �� 
TargetType �� Property �� Value��%^   '��       �� 5!      " ��6    .�5"      ��  �@��CornerRadius$ 6��6=   5#      5$      5%      5&      5'      �� 5*   
   $��1��6   $��50,50,50,30q�6%   $��Center=�6:   .+�5+      �� $��Sign Up��6   $��28(�6'   $
��Bold"�65   $��0,0,0,20q�6G   �� 5-      $��EMAIL��6   $��0,0,0,5q�6%   $��12(�66   $
��Bold"�6D   �� 5.      -   5         ��Name$ EmailTextbox��5.   j   $��35��6   $��0,0,0,15q�6"   ���#EFEFEF$��0q�6I   $��10q�6]   6j   �� 50      $��USERNAME��6   $��0,0,0,5q�6(   $��12(�69   $
��Bold"�6G   �� 51      -   5        $ UserNameTextbox��51   j   $��35��6   $��0,0,0,15q�6"   ���#EFEFEF$��0q�6I   $��10q�6]   6j   �� 53      $��PASSWORD��6   $��0,0,0,5q�6(   $��12(�69   $
��Bold"�6G   G� 54      -   5         G�Name$ PasswordBox��54   n   $��35��6   $��0,0,0,15q�6&   ���#EFEFEF$��0q�6M   $��10q�6a   6n   �� 58      -   5        $��Sign up��58      ���#5138EE
�������$��0,0,0,15q�5;      $	��100��5<      $��34��5=      $��12(�5>      $��Center=�5@       5A      ��%^   '��       �� 5B      " ��6   .�5C      ��  �@��CornerRadius$ 3��69   5D      5E      5F      5G      5H      5I      