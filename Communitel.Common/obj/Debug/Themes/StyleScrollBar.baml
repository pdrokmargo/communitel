   M S B A M L   `   `   `  ����L  HCommunitel.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Communitel.Common.ThemesCommunitel.Common.Themes  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   ScrollThumbs  �� 
TargetType �� Property �� Value �� 
TargetType �Name ��Name �� CornerRadius �� Triggers P� Property	 P� Value
 �� 
TargetName � RowDefinitions ]�Name ]� Thumb n�Name J� Opacity ]� IncreaseRepeatButton ��Name  ScrollBarLineButton ]� DecreaseRepeatButton  ScrollBarPageButton P� 
SourceName  ButtonSelectBrush  	DarkBrush �� Angle �� Path �� RelativeSource�� 5      F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml     5      0local&clr-namespace:Communitel.Common.Themes  5      %?  &	        '�� C    &	 #
    &	 �    �� 5      "  n�6!   .�5   
   ��  � �� 5      �� 5	      " n�6"   .R�5
      � $
 Grid��6   .+�5      �� $��Stretch=�6$   $��Stretch=�6B   $
��Auto��6^   $
��Auto��6k   
������ 6y   �� 5      $ 
Rectangle1��6!   $ 0��65   $��Stretch=�6F   $��Stretch=�6d   $
��Auto��6�   $
��Auto��6�   #��z��6�   5       5      P� 5       �@�Tag$	 
Horizontal��61   . �5      �� $
 
Rectangle1��6%    � ��$
 Auto��6N   �� 5      $
 
Rectangle1��6%    � ��$ 7��6O   5      5      5      5      �� 5      "  ��6'   .�5   
   ��  �@��IsFlicksEnabled .  63   �� 5   
    � �� �	#FF18C6F96'   �� 5   
    � �� �	#FF37474F6'   �� 5   
    � ��$ 10��6"   �� 5    
    � �� 5!      �� 5"      " ��6"   .R�5#      � $ GridRoot��6   $��5��6-   #��z��67    5$      �� 5%      $��0.00001* �6,   .+�5(      ]� $ 
PART_Track��6    $��0��64   ��. |�.   5)      n� 5*   "   $ Thumb��6(   $	 0.5Q�67   #��z��6E   #���   6o    5,      �� 5-   "   $ PageUp��6/   $��ScrollBar.PageDownCommand��6?   $ 0Q�6c   |�.  #���  5.   /    50      �� 51   "   $ PageDown��6/   $��ScrollBar.PageUpCommand��6A   $ 0Q�6c   |�.  #���  52   /   54      55       57      P� 58      $ Thumb��6"    �@J�IsMouseOver	 . . �59      �� $
 Thumb��6/    �@J�Opacity$ 1Q�6%   6B   �� 5:      # �  6%   $
 Thumb��6Q    � ��6d   5;      P� 5=      $ GridRoot��6"    �@J�IsMouseOver	 . . �5>      �� $
 Thumb��6/    �@J�Opacity$ 1Q�6%   6B   5?      P� 5A      $ Thumb��6"    �@n�
IsDragging	 . . �5B      �� # �  6%   $
 Thumb��6I    � ��6\   �� 5C      $
 Thumb��6/    �@J�Opacity$ 1Q�6%   6B   5D      P� 5F       � {�	 .  . �5G      �� $
 Thumb��6%    � y�$ 	Collapsed=�6N   5H      P� 5I       �@��Orientation$	 
Horizontal=�69   . �5J      �� $
 GridRoot��6%    �@�LayoutTransform 5K   "   �� 5L   &   $	 -90Q�66   5N      �� 5O      $
 
PART_Track��6%    �@�LayoutTransform 5P   "   �� 5Q   &   $	 -90Q�66   5S      �� 5T       � ��$
 Auto��66   �� 5U       � ��$ 12��67   �� 5V      $
 Thumb��6%    �@�Tag$ 
Horizontal��6G   �� 5W      $
 PageDown��6%    � ��$ ScrollBar.PageLeftCommand��6N   �� 5X      $
 PageUp��6%    � ��$  ScrollBar.PageRightCommand��6L   5Y      5\      5^      5`      �� 5c      "  ��6(   .�5d   
   ��  �@J�SnapsToDevicePixels . 60   �� 5e   
    �@�OverridesDefaultStyle . 62   �� 5f   
    � |� .  6&   �� 5g   
    � �� 5h      �� 5i      " ��6"   .R�5j      �� $��Border��6   $��1q�6+   $ 2��66   
���   �
���   �$��1q�5k   1   ._�5l      F� $��Center=�5m      $��Center=�5n      
���   ���5o      �� $ Content� �� *TemplatedParent+5q       5r      P� 5s       � ��	 . . �5t      �� $
 Border��6%    � ��
 ��  �6O   5u      P� 5v       � {�	 .  . �5w      ��  � ��
 �����6;   5x      5z      5|      5}      �� 5      "  ��6(   .�5�   
   ��  �@J�SnapsToDevicePixels . 60   �� 5�   
    �@�OverridesDefaultStyle . 62   �� 5�   
    � �� .  6&   �� 5�   
    � |� .  6&   �� 5�   
    � �� 5�      �� 5�      " ��6"   .R�5�      �� 
������ 6   5�      5�      5�      5�      