   M S B A M L   `   `   `  ����E  ACommunitel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Communitel.ViewsCommunitel.Views  5   	        Communitel.Views.Dashboard   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:Communitel.Views     5   	     � Title$  	Dashboard��5   	    � WindowState$ 	Maximized=�6   $	��900��63   $
��1600��6@   .��5	      � -   5         �Name$	 grd��5	       � RowDefinitions 5
   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       �� 5!      �� 5"      �� 5#      �� 5$      �� 5%      .+�5'   
   � -   5        $ grdTop��5'      $��0��6   $��2��6/   $��0��6C   $��1��6P   $y�Visible=�6a   .+�5(      �� $��0��6   $��2��6)   ���	#FF18C6F95*      5,      �� 5-   
   -   5         ��Name$ grdMenu��5-      $��0��6&   $��2��66   $��1��6J   $��11��6W   ���	#FF37474F50      � 52   
   -   5        $ grdRight��52      $��2��6!   $��10��61   $��0��6F   $��12��6S   ���	#FFEEF1F5.+�53      � -   5        $ 
grdContent��53      $��10q�6'   55      56      � 58   
   $
��Left=�6   $	��100��6*   $��2��67   $	��Top=�6H   $	��100��6`   � 59   
   -   5        $ 
grdOverlay��59      $��0��6#   $��12��63   $��0��6H   $��12��6U   $y�Visible=�6g   5:      5;      5>      