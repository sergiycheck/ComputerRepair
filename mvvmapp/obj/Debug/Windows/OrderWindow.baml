   M S B A M L   `   `   `  ����B  >mvvmapp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:mvvmapp.Windowsmvvmapp.Windows  5   	   !    mvvmapp.Windows.OrderWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:mvvmapp.Windows     5   	     � Title$  OrderWindow��5   	   .��5
      �� .+�5   
   �  � ColumnDefinitions 5      �� 5      $��2* �6#   �� 5      $��* �6#   �� 5      $��* �6#   �� 5      $��* �6#   .+�5      �� -   5         ��Name$ SearchTxtBox��5      $��0��6,   $��Type to search��6<   $
��5 10q�6R    �� AcceptsReturn .  �� TextWrapping$
 Wrap=�6u    �� 	IsEnabled .  � Language$ en-US�6�   6�   �� 5      $��1��6   $��Search��6'   $
��5 10q�68   5      �� 5      -   5         ��Name$ BacktBtn��5   C   $��3��6   $
��Back��6%   $��15 10q�64   6n   5      � 5   
    5      �� 5      $��* �6#   �� 5      $��* �6#   .+�5      �� -   5         ��Name$ ComputersListBox��5#      $��0��5      $��20q�5   ?   ��. $��Visible=�5!      $	��400��5"      ��5      �� *OrderedComputers+	 �� SelectedItem	 6L   �� 
 �� Path$
 SelectedOrderedComputer���5$      �� 5%      .R�5&      �� $��5q�6%   .+�5'      �  5(   "   �� 5)   &   $��* �67   �� 5*   &   $��* �67   .+�5,   "   �� $��0��6-   $��0 0 10 0q�6=   .+�5-   &   �� $	��100��6,   $��75��68   ��6D   �� $
 	ImagePath�5.   #   �� 5/   "   $��1��6-   .+�50   &   �� ��60   �� $
 Title��� 51   &   ��60   �� $
 Company��� 52   &   ��53   *   �� 54   .   $
 Price�66    �� ValidationRules 55   2   5  /System.Windows.Controls.ExceptionValidationRule  56   6   58   /   5:   '   5<   #   5=      5?      5@      5B      �� 5D      $��1��6   .+�5E      �� .��6   Enter your phone number61   �� 5F      -   5        $ PhoneTxt��5F      ��6,   �� $
 PhoneNumber� �� UpdateSourceTrigger$ PropertyChanged=�6x   �� 5G      .��6   Enter your address6,   �� 5H      -   5        $ 
CompanyTxt��5H      ��6.   �� $
 Address�$ PropertyChanged=�6v   5I      5K      � 5L   
    5M      �� 5N      $��* �6#   �� 5O      $��* �6#   �� 5P      $��* �6#   .+�5R      �� -   5        $ DeleteOrdertBtn��5R   D   $��0��6   $��Delete��6%   $
��5 10q�66   ��6]   �� *DeleteOrderedComputerCommand+��6�   �� *SelectedOrderedComputer+�� 5S      -   5        $ MakeOrderBtn��5S   C   $��2��6   $��Order��6%   $
��5 10q�65   ��6Y   �� *MakeOrderCommand+5T      5U      5V      