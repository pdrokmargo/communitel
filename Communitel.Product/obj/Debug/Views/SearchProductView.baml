   M S B A M L   `   `   `  ����U  QCommunitel.Product.Plugins, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Communitel.Product.ViewsCommunitel.Product.Views  5      L HCommunitel.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullbCclr-namespace:Communitel.Common.Converts;assembly=Communitel.CommonCommunitel.Common.Converts 5	      0    *Communitel.Product.Views.SearchProductView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:Communitel.Product.Views     5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      Z VFontAwesome.WPF, Version=4.5.0.37524, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5      QconvertCclr-namespace:Communitel.Common.Converts;assembly=Communitel.Common  5	        � 	Resources  5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $7 1/Communitel.Common;component/Themes/StyleApp.xaml?�6&   �� 5      $; 5/Communitel.Common;component/Themes/StyleTextBox.xaml?�6&   �� 5      $: 4/Communitel.Common;component/Themes/StyleButton.xaml?�6&   �� 5      $< 6/Communitel.Common;component/Themes/StyleGroupBox.xaml?�6&   �� 5      $< 6/Communitel.Common;component/Themes/StyleDataGrid.xaml?�6&   %    5      .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *GetAllCommand+5      .��5      �  � ColumnDefinitions 5    
   �� 5!      $
��Auto �6   �� 5"      �� 5#      $
��Auto �6    � RowDefinitions 5%   
   �� 5&      $	��120 �6   �� 5'      �� 5(      $��60 �6   .+�5*   
   �� $��2��6   $��0��6!      DesignButtonImageFont#���   6.   $
��Left=�6^   $
��Auto��6y   $��45��6�   ��5+      �� *OpenCreateCommand+.��5,      �  5-      �� 5.      $
��Auto �6'   �� 5/      $
��Auto �6'   .+�51      "  FontAwesome.WPF.ImageAwesome  	   Icon$	 
PlusCircle=�6"   $��0��64   $��Center=�6�   $��4q�6�   
   
Foreground
 6D   ��  �� Path$ 
Foreground� �� RelativeSource ��  �� AncestorType" ��6�   �� 52      $��Add New��6   $��1��6+   $��Center=�6�   $��7q�6�   ��6;   �� $ 
Foreground� �� " ��6�   53      54      �� 55   
   $��1��6   $��0��6!   #���   6.   $��Right=�6^   $
��Auto��6z   $��45��6�   ��56      �� *OpenMoreFiltersCommand+.��57      �  58      �� 59      $
��Auto �6'   �� 5:      $
��Auto �6'   .+�5<        $	 Filter=�6"   $��0��60   $��Center=�6�   $��4q�6�   
 6@   �� $ 
Foreground� �� " ��6�   �� 5=      $��More filters��6   $��1��60   $��Center=�6�   $��7q�6�   ��6@   �� $ 
Foreground� �� " ��6�   5>      5?      � 5@   
   $��0��6   $��0��6   $
��Left=�6,    5A      �� 5B      �� 5C      $
��Auto �6#   .+�5E      �� $��0��6   $	��200��6&     DesignTextBoxSearch#���  62   $��Right=�6`   ��6|   �� *Search+�� 5F      $��1��6   $��Search��6%     DesignButtonSearch#���  66   $
��Left=�6c   $	��110��6~   ��6�   �� *GetAllCommand+5G      �� 5I   
   $��0��6   $��1��6#   $��3��60     DesignGroupBox#���  6D   $��Search Products��6m   .��5J      � .+�5K      &   System.Windows.Controls.DataGrid  -   5           AutoGenerateColumns .     
IsReadOnly .    ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 5K   t     DesignDataGrid#���  5L         CanUserSortColumns .    CanUserReorderColumns . ��5K   I   �� $ Products.data�  5M      1  +Communitel.Common.Converts.ConvertToDecimal  convertToDecimal��%   &	         5N      63   5O         RowStyle 5P      �� 5Q       �� 
TargetType)	  #System.Windows.Controls.DataGridRow" 	 6      DesignRowsDataGrid �� BasedOn# [ 6B   .�5R      ��  �� Property � �� �� Value$ 40��6:   �� 5S       � ��$
 Auto��67   5T         Columns 5V      0
  *System.Windows.Controls.DataGridTextColumn
  5W      ,  &System.Windows.Controls.DataGridColumn   Header$ 	Reference��6-      SortMemberPath$
 code��6Y   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6@   �� *code+6Y   
  5X      $
 Name��6-   $
 name��6T    6;   �� *name+6T   
  5Y      $ Stock��6-   $ quantity��6Y    6<   �� *
quantity+6Y   
  5Z      $ Price��6-   $ price��6�    6<   �� $ price� �� StringFormat$ {0:C}�� �� 	Converter# [ 6�   4  .System.Windows.Controls.DataGridTemplateColumn  5\      $ 
Categories��61      CellTemplate 5]      �� 5^   "   .R�5_   &   �� ��63   �� *
categories+��5`   *   �� 5a   .   .R�5b   2   A�  A� Columns$ 1��6>   5c   /   ��5e   *   �� 5f   .   .R�5g   2   �� 
�������
�������$��1q�6c     �� Padding$  6,3,6,3q�6w   ! �� CornerRadius$! 10��6�   $��20��5h   9   $
��Auto��6E   $	��Top=�6R   $��0,4,4,4q�6j   ._�5i   6   ]� .+�5j   :   �� $
��Left=�6D   $��12(�6w   ��6Z   �� *description+6w   5k   7   5l   3   5m   /   5o   '   5p   #   5r        5s       5t      �� 5u   "   .R�5v   &   �� #���   6-   $��Center=�6]   $��Center=�6x   ��5w   -   �� $! DataContext.OpenEditCommand� �� "  ��5x   -   �� .��5y   *     $	 Pencil=�6:   $��25��6H   $��25��6S     ForeGroundFontAwesome#
 �  6_   5z   '   5{   #   5}      5      5�      5�      �� 5�   
   " �� Orientation$" 
Horizontal=�6   $��0��6.   $��3��6>   $��2��6R   $��Center=�6_   .+�5�      �� $��Center=�6     DesignButtonPreviousPage#���  62   $��previous��6�   ��6e   �� *NextPageCommand+6�   �� 5�      $��Center=�6   $��Center=�65   $��20(�6P   �� 5�      �6   �� $ Products.current_page�# �� Mode$# TwoWay=�$ �� UpdateSourceTrigger$$ PropertyChanged=� �� 5�      $�of��6    �� 5�      �6   �� $ Products.last_page�$$ PropertyChanged=�5�      �� 5�       	 DesignButtonNextPage#��� 	 6   $
��next��6h   ��6D   �� *NextPageCommand+6h   5�      5�      5�      