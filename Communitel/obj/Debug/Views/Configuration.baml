   M S B A M L   `   `   `  ����E  ACommunitel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Communitel.ViewsCommunitel.Views  5      E'clr-namespace:Communitel.CustomControlsCommunitel.CustomControls  5      $    Communitel.Views.Configuration   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:Communitel.Views     5      7eo(http://schemas.essentialobjects.com/wpf/     5      BCustomControls'clr-namespace:Communitel.CustomControls     5      .��5      � -   5          �Name$	  grd��5      
������� � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       �� 5!      �� 5"      �� 5#      �� 5$      �� 5%      �� 5&      �� 5'      .+�5)   
   � -   5        $  grdConfiguration��5)      $��0��6)   $��3��69   $��10��6F   $��11��6X   $y�Visible=�6m   $��30,30,30,30q�6�   .+�5*      ��  �� Orientation$ 
Horizontal=�6   $��Right=�62   $��Bottom=�6N   .+�5+      �� -   5         ��Name$ 	btnUpdate��5+         
ButtonSave#��[  6,   $	��120��6P   $��40��6\   $��Update��6h   $��Bottom=�6y   $��Right=�6�   $��10,10,10,10q�6�   6�   5,      )   #Communitel.CustomControls.TextField  5.      -   5          Name$ txtYellowPrice��5.   <   ���#CBC50A   Label$ Yellow Lines Price��6T   $
��Left=�6�   $��	10,49,0,0q�6�   $	��Top=�6�   $	��145��6�      Text 6o   �� *yellow_price+6�   �� 5/      $��Babagge��6   $
��Left=�6'   $��0��6B   $��0��6O   
������ 
������� �� TextAlignment$
 Left=�6�   $��ExtraExpanded&�6�   $��20(�6�   $
��Bold"�6�   $��
10,2,0,334q�6�     50      -   5        $ txtRedPrice��50   <   ���#BC1313$ Red Lines Price��6Q   $
��Left=�6�   $��
159,49,0,0q�6�   $	��Top=�6�   $	��145��6�    6i   �� *	red_price+6�     51      -   5        $ txtOrangePrice��51   <   ���#E95B14$ Orange Lines Price��6T   $
��Left=�6�   $��
309,49,0,0q�6�   $	��Top=�6�   $	��145��6�    6o   �� *orange_price+6�     52      -   5        $ txtExpiryDays��52   (   $ Expiry Days��6?   $
��Left=�6p   $��
459,49,0,0q�6�   $	��Top=�6�   $	��145��6�    6S   �� *expiry_days+6�     53      -   5        $ txtTax��53   (   $ Tax (%)��68   $
��Left=�6e   $��
10,186,0,0q�6�   $	��Top=�6�   $	��108��6�    6H   �� *tax_percent+6�   �� 54      $��Sales��6   $
��Left=�6%   $��0��6@   $��0��6M   
������ 
�������$
 Left=�6�   $��ExtraExpanded&�6�   $��20(�6�   $
��Bold"�6�   $��10,149,0,187q�6�   55      �� 56   
   -	   5        	 ��Name$	 txbTitle��56   �   $��60��6   $��Configuration��6!   $
��Left=�66   $��0��6Q   $��0��6^   $��4��6n   $��3��6�   
������ 
�������$
��Wrap=�6�   $
 Left=�6�   $��ExtraExpanded&�6�   $��32(�6  $��
30,37,0,32q�6%  58      59      