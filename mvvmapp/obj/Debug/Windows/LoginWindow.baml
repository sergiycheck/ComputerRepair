   M S B A M L   `   `   `  ����B  >mvvmapp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:mvvmappmvvmapp  5   	       mvvmapp.LoginWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:mvvmapp     5   	     � Title$  LoginWindow��5   	   .��5	      �� .+�5
   
   �  � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��* �6#   �� 5      $��* �6#    � RowDefinitions 5      �� 5      6"   �� 5      6"   �� 5      6"   .+�5      �� $��1��6   $��0��6)   .+�5      �� $��
0 100 0 10q�68   ��6   �� *PhoneNumber+6N   5      �� 5      $��1��6   $��1��6)   .+�5      G� -   5        5   P   5      �� 5      $��1��6   $��2��6)   .+�5      �� -   5         ��Name$ forgotPaswordLink��5   q   $��Forgot password��6   $��	10 10 0 0q�63   ���	#FF1000FF
�������
�������6�   5      5      � 5    
   $��
10 200 0 0q�6    5!      �� 5"      $��* �6#   �� 5#      $��* �6#   �� 5$      $��* �6#   �� 5%      $��* �6#   .+�5(      �� -   5        $ BackBtn��5(   4   $��0��6   $
��Back��6%   $��10 0 q�6[   6m   �� 5)      -   5        $ LoginBtn��5)   5   $��1��6   $��Login��6%   6G   �� 5*      -   5        $��2��5*      $��Login as worker��6%   $��10 0 q�6\   6m   �� 5+      -   5        $ LoginUserBtn��5+   L   $��3��6   $��Login as user��6%   $��10 0 q�6=   6   5,      � 5-   
   $��	10 10 0 0q�6    5.      �� 5/      $
��250* �6#   �� 50      $
��251* �6#   �� 51      $
��211* �6#   �� 52      $	��39* �6#   .+�56      �� $��0��6   $��10,0,250.6,-0.6q�6�    �� AcceptsReturn .  �� TextWrapping$
 Wrap=�6�   $��2��6  ��6&   ��  �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType" ��	 �� Path$	 
Background�
 �� UpdateSourceTrigger$
 PropertyChanged=�6  57      58      5:      