   M S B A M L   `   `   `  ����U  QCommunitel.Product.Plugins, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Communitel.Product.ViewsCommunitel.Product.Views  5      L HCommunitel.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullbCclr-namespace:Communitel.Common.Controls;assembly=Communitel.CommonCommunitel.Common.Controls 5      bCclr-namespace:Communitel.Common.Converts;assembly=Communitel.CommonCommunitel.Common.Converts 5      *    $Communitel.Product.Views.ProductView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:Communitel.Product.Views     5      SctlCclr-namespace:Communitel.Common.Controls;assembly=Communitel.Common     5      WconvertCclr-namespace:Communitel.Common.Converts;assembly=Communitel.Common     5      Z VFontAwesome.WPF, Version=4.5.0.37524, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5	        � 	Resources  5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $7 1/Communitel.Common;component/Themes/StyleApp.xaml?�6&   �� 5      $; 5/Communitel.Common;component/Themes/StyleTextBox.xaml?�6&   �� 5      $: 4/Communitel.Common;component/Themes/StyleButton.xaml?�6&   �� 5      $< 6/Communitel.Common;component/Themes/StyleGroupBox.xaml?�6&   �� 5      $< 6/Communitel.Common;component/Themes/StyleComboBox.xaml?�6&   �� 5      $: 4/Communitel.Common;component/Themes/StyleSwitch.xaml?�6&   %    5      .��5      �  � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6    � RowDefinitions 5    
   �� 5!      $
��Auto �6   �� 5"      $��* �6   �� 5#      $
��Auto �6   .+�5&   
   �� $��1��6   $��1��6       DesignGroupBox#���   60   $��Catalog Products��6Y     5'      .  (Communitel.Common.Converts.ConvertToBool  convertToBool��%   &	         5(      6(   5)      .��5*      �  5+      �� 5,      �� 5-      �� 5.       50      �� 51      $
��Auto �6$   �� 52      $
��Auto �6$   �� 53      $
��Auto �6$   �� 54      $
��Auto �6$   �� 55      $
��Auto �6$   �� 56      $
��Auto �6$   �� 57      $
��Auto �6$   �� 58      $
��Auto �6$   �� 59      $��* �6$   .+�5;      �� $��0��6   $��0��6,   $��	Reference��69   �� 5<      $��0��6   $��1��6*     DesignTextBox#���  67   ��6_   ��  �� Path$ Product.code��� 5>      $��1��6   $��0��6,   $
��Name��69   �� 5?      $��1��6   $��1��6*   $��2��67   #���  6K   ��6s   �� $ Product.name��� 5A      $��0��6   $��2��6,   $��Description��69   �� 5B      $��0��6   $��3��6*   $��3��67   #���  6K    �� TextWrapping$
 Wrap=�5C       �� AcceptsReturn . $
��Auto��6C   ��5B   s   �� $ Product.description�5C   C   �� 5E      $��0��6   $��4��6,   $��Quantity��69   2  ,Communitel.Common.Controls.TextBoxOnlyNumber  5F      $��0��6(   $��5��68   #���  6E   ��6m   �� $ Product.quantity��� 5H      $��1��6   $��4��6,   $��Price��69     5I      $��1��6(   $��5��68   #���  6E   ��6m   �� $ Product.price��� 5K      $��2��6   $��4��6,   $��Status��69   $��Center=�6G   �� 5L      $��2��6   $��5��6+     DesignSwitch#���  68   $��Center=�5M   o    d� 	IsChecked 6   �� $ Product.status�	 �� 	Converter#	 [ 6o   �� 5O      $��0��6   $��6��6,   $��
Categories��69   $
��Left=�6K   �� 5Q      $��1��6   $��6��6)     DesignButtonImageFont#���  66   $��Right=�6f   $
��Auto��6�   $��45��6�   ��5R      �� *OpenCategoriesCommand+.��5S      �  5T      �� 5U      $
��Auto �6/   �� 5V      $
��Auto �6/   .+�5X      "  FontAwesome.WPF.ImageAwesome  
   Icon$
 Search=�6*   $��0��68   $��Center=�6�   $��4q�6�      
Foreground 6H   �� $ 
Foreground� �� RelativeSource ��  �� AncestorType" ��6�   �� 5Y      $��Search categories��6$   $��1��6=   $��Center=�6�   $��7q�6�   ��6M   �� $ 
Foreground� �� " ��6�   5Z      5[      �� 5]      $��0��6   $��2��6)   $��7��6=   
������� �� Padding$ 10q�6]   $��2q�5^      $	��200��6-   ._�5_      �� ��6#   �� $ Product.categories���5`      �� 5a      .R�5b   "   A�  A� Columns$ 3��6.   5c      ��5e      �� 5f      .R�5g   "   �� 
�������
�������$��1q�6S   $ 10q�6g    �� CornerRadius$ 10��6t   $��45��6�   $
��Auto��6�   $	��Top=�6�   $��0,0,4,4q�6�   ._�5h   &   ]� .+�5i   *   �� $
��Left=�64   $��17(�6g   ��6J   �� *description+6g   �� 5j   *   $��Right=�61   $��r��6H     DesignButtonClose#���  6T   
�������$��17(�6�   $��20��6�   $��20��6�   ��5k   1   �� $' !DataContext.RemoveCategoryCommand� �� " ����5l   1   �� 5m   '   5n   #   5o      5q      5r      �� 5t      $��1��6   $��8��6)   $��Close��66     DesignButton#���  6F   $��0,0,5,0q�6m   $��Bottom=�5u      $	��300��6a   ��64   �� *OpenSearchProductCommand+6a   �� 5w      $��2��6   $��8��6)   $
��Save��66   #���  6E   $��5,0,0,0q�6l   $��Bottom=�5x      $	��300��6T   ��64   �� *SaveCommand+6T   5z      5{      5}      5~      