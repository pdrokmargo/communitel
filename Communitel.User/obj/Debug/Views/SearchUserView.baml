   M S B A M L   `   `   `  ����R  NCommunitel.User.Plugins, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Communitel.User.ViewsCommunitel.User.Views  5      *    $Communitel.User.Views.SearchUserView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:Communitel.User.Views     5      Z VFontAwesome.WPF, Version=4.5.0.37524, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5        � 	Resources  5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $7 1/Communitel.Common;component/Themes/StyleApp.xaml?�6&   �� 5      $; 5/Communitel.Common;component/Themes/StyleTextBox.xaml?�6&   �� 5      $: 4/Communitel.Common;component/Themes/StyleButton.xaml?�6&   �� 5      $< 6/Communitel.Common;component/Themes/StyleGroupBox.xaml?�6&   �� 5      $< 6/Communitel.Common;component/Themes/StyleDataGrid.xaml?�6&   %    5      .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *GetAllCommand+5      .��5      �  � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5       �� 5!      $
��Auto �6    � RowDefinitions 5#   
   �� 5$      $	��120 �6   �� 5%      �� 5&      $��60 �6   .+�5(   
   �� $��2��6   $��0��6!      DesignButtonImageFont#���   6.   $
��Left=�6^   $
��Auto��6y   $��45��6�   ��5)      �� *OpenCreateCommand+.��5*      �  5+      �� 5,      $
��Auto �6'   �� 5-      $
��Auto �6'   .+�5/      "  FontAwesome.WPF.ImageAwesome  	   Icon$	 
PlusCircle=�6"   $��0��64   $��Center=�6�   $��4q�6�   
   
Foreground
 6D   ��  �� Path$ 
Foreground� �� RelativeSource ��  �� AncestorType" ��6�   �� 50      $��Add New��6   $��1��6+   $��Center=�6�   $��7q�6�   ��6;   �� $ 
Foreground� �� " ��6�   51      52      �� 53   
   $��1��6   $��0��6!   #���   6.   $��Right=�6^   $
��Auto��6z   $��45��6�   $y�	Collapsed=�54   <   ��6   �� *OpenMoreFiltersCommand+.��55      �  56      �� 57      $
��Auto �6'   �� 58      $
��Auto �6'   .+�5:        $	 Filter=�6"   $��0��60   $��Center=�6�   $��4q�6�   
 6@   �� $ 
Foreground� �� " ��6�   �� 5;      $��More filters��6   $��1��60   $��Center=�6�   $��7q�6�   ��6@   �� $ 
Foreground� �� " ��6�   5<      5=      � 5>   
   $��0��6   $��0��6   $
��Left=�6,    5?      �� 5@      �� 5A      $
��Auto �6#   .+�5C      �� $��0��6   $	��200��6&     DesignTextBoxSearch#���  62   $��Right=�6`   ��6|   �� *Search+�� 5D      $��1��6   $��Search��6%     DesignButtonSearch#���  66   $
��Left=�6c   $	��110��6~   ��6�   �� *GetAllCommand+5E      �� 5G   
   $��0��6   $��1��6#   $��3��60     DesignGroupBox#���  6D   $��Search Users��6m   .��5H      � .+�5I      &   System.Windows.Controls.DataGrid  -   5           AutoGenerateColumns .     
IsReadOnly .    ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 5I   q     DesignDataGrid#���  5J         CanUserSortColumns .    CanUserReorderColumns . ��5I   I   �� $ 
Users.data�   RowStyle 5L      �� 5M       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6      DesignRowsDataGrid �� BasedOn# [ 6B   .�5N      ��  �� Property � �� �� Value$ 40��6:   �� 5O       � ��$
 Auto��67   5P         Columns 5R      0	  *System.Windows.Controls.DataGridTextColumn	  5S      ,
  &System.Windows.Controls.DataGridColumn 
  Header$ 
First Name��6-    
  SortMemberPath$ 	firstname��6_   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6A   �� *	firstname+6_   	  5T      $ 	Last Name��6-   $ lastname��6]    6@   �� *
lastname+6]   	  5U      $ 	User Name��6-   $ username��6]    6@   �� *
username+6]   	  5V      $ Email��6-   $ email��6V    
  Width$	 200 6m    6<   �� *email+6m   	  5W      $ Profile��6-   $ user_profile_id��6o    6>   �� $ userprofile.description�6o   4  .System.Windows.Controls.DataGridTemplateColumn  5p         CellTemplate 5q      �� 5r   "   .R�5s   &   �� #���   6-   $��Center=�6]   $��Center=�6x   ��5t   -   �� $! DataContext.OpenEditCommand� �� "  ��5u   -   �� .��5v   *     $	 Pencil=�6:   $��25��6H   $��25��6S     ForeGroundFontAwesome#
 �  6_   5w   '   5x   #   5z      5|      5}      5~      �� 5�   
    �� Orientation$ 
Horizontal=�6   $��0��6.   $��3��6>   $��2��6R   $��Center=�6_   .+�5�      �� $��Center=�6     DesignButtonPreviousPage#���  62   $��previous��6�   ��6e   �� *NextPageCommand+6�   �� 5�      $��Center=�6   $��Center=�65   $��20(�6P   �� 5�      �6   �� $ Users.current_page� �� Mode$ TwoWay=�  �� UpdateSourceTrigger$  PropertyChanged=� �� 5�      $�of��6    �� 5�      �6   �� $ Users.last_page�$  PropertyChanged=�5�      �� 5�        DesignButtonNextPage#���  6   $
��next��6h   ��6D   �� *NextPageCommand+6h   5�      5�      5�      