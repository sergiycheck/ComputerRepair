   M S B A M L   `   `   `  ����B  >mvvmapp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:mvvmappmvvmapp  5   	   7 clr-namespace:mvvmapp.Convertersmvvmapp.Converters  5   	       mvvmapp.HomeWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:mvvmapp     5   	   7
converters clr-namespace:mvvmapp.Converters     5   	     � Title$  
HomeWindow��5	   	   $	��700��6    � 	Resources 5      &    mvvmapp.Converters.ConvertString   ConvertString"   mvvmapp.Converters.ConverInt  
ConvertInt��%:   &	        &	        5   
   6;     5   
   65   5      .��5      �� .+�5   
   �  � ColumnDefinitions 5      �� 5      $��2* �6#   �� 5      $��* �6#   �� 5      $��* �6#   �� 5      $��* �6#   .+�5      �� -   5         ��Name$ SearchTxtBox��5      $��0��6,   $��Type to search��6<   $
��5 10q�6R    �� AcceptsReturn .  �� TextWrapping$
 Wrap=�6u    �� 	IsEnabled .  � Language$ en-US�6�   6�   �� 5      $��1��6   $��Search��6'   $
��5 10q�68   5      �� 5      -   5        $��2��5      $��Orders��6&   $
��5 10q�67   6_   �� 5      -   5         ��Name$ 
SignOutBtn��5   G   $��3��6   $��Sign out��6%   $��15 10q�68   6w   5      � 5    
    5!      �� 5"      $��1* �6#   �� 5#      $
��0.5* �6#   .+�5&      �� -   5        	 ��Name$	 ComputersListBox��5+      $��0��5&      $��20q�5'   8   ��. $��Visible=�5)      $	��400��5*      ��5'      �� *	Computers+
 �� SelectedItem
 6E   ��  �� Path$ SelectedComputer���5,      �� 5-      .R�5.      �� .+�5/      ]� $��5q�6(   .+�50   "   �  51   &   �� 52   *   $��* �6;   �� 53   *   $��* �6;   �� 54   *   $��* �6;   .+�56   &   �� $��0��61   $��0 0 10 0q�6A   .+�57   *   �� $	��100��60   $��75��6<   ��6H   �� $ 	ImagePath�58   '   �� 59   &   $��1��61   .+�5:   *   �� ��64   �� $ Title��� 5;   *   ��64   �� $ Company��� 5<   *   ��5=   .   �� 5>   2   $ Price�6:    �� ValidationRules 5?   6   5  /System.Windows.Controls.ExceptionValidationRule  5@   :   5B   3   5D   +   5E   '   5F   #   5H      5J      5K      5M      �� 5O      -   5         ��Name$ StackPanelCompProp��5O   )   $��1��6    � DataContext 6E   �� *SelectedComputer+ �� Mode$ TwoWay=�.+�5P      �� .��6   Selected computer6+   �� 5Q      .��6   Id computer6%   �� 5R      -   5        $ IdTxt��5R      {�.  ��6)   �� $ Id�6V   �� 5S      .��6   Title of the computer6/   �� 5T      -   5        $ TitleTxt��5T      ��6,   �� $ Title� �� UpdateSourceTrigger$ PropertyChanged=�6r   �� 5U      .��6   Company of the computer61   �� 5V      -   5        $ 
CompanyTxt��5V      ��6.   �� $ Company�$ PropertyChanged=�6w   �� 5W      .��6   Price of the computer6/   �� 5X      -	   5        $ PriceTxt��5X      ��6,   �� $ Price�$ PropertyChanged=�6s   �� 5Y      .��6   Path to image6'   �� 5Z      -
   5        $ ImageTxt��5Z      ��6,   �� $ 	ImagePath�$ PropertyChanged=�6y   5\      5^      � 5_   
    5`      �� 5a      $��* �6#   �� 5b      $��* �6#   �� 5c      $��* �6#   .+�5f      �� -   5        $ AddBtn��5f   R   $��0��6   $��Add computer to list��6%   $
��5 10q�6D   ��6b   �� *AddComputerCommand+��6�   ��  �� ElementName$ StackPanelCompProp���� 5g      -   5        $ 
DeletetBtn��5g   D   $��1��6   $��Delete��6%   $
��5 10q�66   ��6X   �� *DeleteComputerCommand+��6�   �� *SelectedComputer+�� 5h      -   5        $ 	UpdateBtn��5h   D   $��2��6   $��Update��6%   $
��5 10q�66   ��6W   �� *UpdateComputerCommand+��6�   �� *SelectedComputer+5i      � 5j   
   $��
0,0,-0.4,0q�6    5k      �� 5l      $��* �6#   �� 5m      $��* �6#   �� 5n      $��* �6#   .+�5q      �� -   5        $ AddToDatabaseBtn��5q   V   $��0��6   $��Add computer to database��6%   $
��5 10q�6H   ��6p   �� *AddComputerToDatabaseCommand+��6�   �� *SelectedComputer+�� 5s      -   5        $ MoveToOrderList��5s   &   $��2��6   $��Order��6?   $
��5 10q�6O   6}   5u      � 5v   
   $��
0,0,-0.4,0q�6    5w      �� 5x      $��* �6#   �� 5y      $��* �6#   �� 5z      $��* �6#   .+�5}      �� -   5        $ AddInNewWindowBtn��5}   &   $��0��6   $��Add in window��6A   $
��5 10q�6Y   6�   �� 5~      -   5        $ UpdateInNewWindow��5~   R   $��1��6   $��Update in new window��6%   $
��5 10q�6D   6m   �� 5      -   5        $ SaveBtn��5   B   $��2��6   $
��Save��6%   $
��5 10q�64   ��6S   �� *saveComputerCommand+5�      5�      5�      