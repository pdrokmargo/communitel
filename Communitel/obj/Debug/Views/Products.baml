   M S B A M L   `   `   `  ����E  ACommunitel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Communitel.ViewsCommunitel.Views  5      E'clr-namespace:Communitel.CustomControlsCommunitel.CustomControls  5          Communitel.Views.Products   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:Communitel.Views     5      BCustomControls'clr-namespace:Communitel.CustomControls     5      .��5
      � -   5          �Name$	  grd��5
      
������� � ColumnDefinitions 5   
   �� 5       � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ txbTitle��5   d   $��Products Catalog��6   $
��Left=�6,   $��0��6G   $��0��6T   
������ 
�������$
��Wrap=�6�    �� TextAlignment$
 Left=�6�   $��ExtraExpanded&�6�   $��32(�6�   $	��Top=�6�   $��5q�6  � 5   
   -   5        $  grdProductsForm��5      $��0��6(   $��1��68   $y�Visible=�6E   $��5q�6Z   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��Right=�62   $��Bottom=�6N   .+�5      �� -   5         ��Name$ btnClose��5         ButtonClose#��[  6+   $	��120��6P   $��40��6\   $��Close��6h   $��Bottom=�6x   $��Right=�6�   $��10,10,10,10q�6�   6�   �� 5      -   5        $ btnSave��5        
ButtonSave#��[ 6*   $	��120��6N   $��40��6Z   $
��Save��6f   $��Bottom=�6u   $��Right=�6�   $��10,10,10,10q�6�   6�   5      )   #Communitel.CustomControls.TextField  5         Label$ 	Reference��6'   $
��Left=�6O   $��	10,10,0,0q�6j   $	��Top=�6}   $	��144��6�      Text 69   �� *code+6�     5      $
 Name��6'   $
��Left=�6J   $��
159,10,0,0q�6e   $	��Top=�6y   $	��445��6�    64   �� *name+6�     5      $ Description��6'   $
��Left=�6X   $��
10,112,0,0q�6s   $	��Top=�6�   $	��594��6�    6;   �� *description+6�     5      $ Quantity��6'   	   DataType$	 Numeric=�68   $
��Left=�6e   $��
10,206,0,0q�6�   $	��Top=�6�   $��81��6�    6K   �� *
quantity+6�   0   *Communitel.CustomControls.AggregatedObject  5      
   Label$
 Category��6.   $
��Left=�6?   $��468,206,0,0q�6Z   $	��Top=�6o   $	��176��6�     5      $ Price��6'   $	 Numeric=�65   $
��Left=�6_   $��
96,206,0,0q�6z   $	��Top=�6�   $��81��6�    6H   �� *price+6�     5      $ Status��6'   $	 Numeric=�66   $
��Left=�6`   $��182,206,0,0q�6{   $	��Top=�6�   $��81��6�    6I   �� *price+6�   5!      � 5"   
   -   5        $  grdProductsList��5"      $��0��6(   $��1��68   $��5q�6E   $y�	Collapsed=�6P    5#      �� 5$      $
��Auto �6    60   �� 5%      $��* �6    6-    5'      �� 5(      $	��11* �6#   �� 5)      $	��68* �6#   .+�5+      �� $ 
Horizontal=�6   $��Right=�62   $��1��6N   .+�5,      �� -   5         ��Name$ 	txtSearch��5,      $��40��6-   $	��200��69   $��5q�6E   �� 5-      -   5        $ 	btnAddNew��5-       
 AddNew#��[ 6,   $	��120��6L   $��40��6X   $��Add Product��6d   $��5q�6z   6�   5.      �� 5/      -	   5         ��Name$ listView��5/   $   $��1��6   $��5q�66   
������  �� AlternationCount$ 2��6\     alternatingStyle#��[ 6q   $��2��6�    �� View 50      �� 51      -
   5        ListViewHeader��.P�52      �� $��	Reference��6)    �� Width$	 150��6<    �� CellTemplate 53      �� 54   "   .R�55   &   �� $��10,10,10,10q�6F   $��Stretch=�6[   $ Center=�6y   $��16(�6�   ���	#FF3C3C3C��60   �� *code+6�   56   #   58      �� 59      $
��Name��6)   $	 400��67    5:      �� 5;   "   .R�5<   &   �� $��10,10,10,10q�6F   $��Stretch=�6[   $ Center=�6y   $��16(�6�   ���	#FF3C3C3C��60   �� *name+6�   5=   #   5?      �� 5@      $��Stock��6)   $	 100��68    5A      �� 5B   "   .R�5C   &   �� $��10,10,10,10q�60   $��Stretch=�6E   $ Center=�6c   $��16(�6�   ���	#FF3C3C3C��6z   �� *
quantity+6�   5D   #   5F      �� 5G      $��Category��6)   $	 200��6;    5H      �� 5I   "   .R�5J   &   �� $��10,10,10,10q�60   $��Stretch=�6E   $ Center=�6c   $��16(�6�   ���	#FF3C3C3C��6z   �� *
lastname+6�   5K   #   5M      5N      5P      5Q      5R      5S      