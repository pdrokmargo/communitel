   M S B A M L   `   `   `  ����L  HCommunitel.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Communitel.Common.ViewsCommunitel.Common.Views  5      ,    &Communitel.Common.Views.MessageBoxView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      l hMicrosoft.Practices.Prism.Composition, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35m iMicrosoft.Practices.Prism.Mvvm.Desktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jMicrosoft.Practices.Prism.Interactivity, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35-prismhttp://www.codeplex.com/prism    5      Z	 VFontAwesome.WPF, Version=4.5.0.37524, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/ 	 5      1local%clr-namespace:Communitel.Common.Views 	 5        � WindowStyle$
  None=�5      $
��Auto��6!   $
��Auto��6/   $	��600��6<    � 
ResizeMode$ NoResize=�5	       � WindowStartupLocation$ CenterScreen=�6+    � SizeToContent$ WidthAndHeight=�6P    � 	Resources 5
       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $7 1/Communitel.Common;component/Themes/StyleApp.xaml?�6&   �� 5      $: 4/Communitel.Common;component/Themes/StyleButton.xaml?�6&   �� 5      $= 7/Communitel.Common;component/Themes/StyleScrollBar.xaml?�6&   �� 5      $9 3/Communitel.Common;component/Themes/StylePopup.xaml?�6&   %    5      .��5      �� -   5        $��	bdContent��5         DesignPopupSinAnimacion#���   6   ._�5   
   �  � RowDefinitions 5      �� 5      $��50 �6    �� 5      �� 5      $��60 �6    .+�5      �� -   5        $��0��5       � Cursor$ SizeAll��6"   ._�5       ]� $��0��6     HeaderBackGroundPage#���  6)   .+�5!      �� -   5        	 ��Name$	 txttext��5!       $
��Left=�61   $��Century Gothic)�6G   $��10,0,0,0q�6c   $��Mensaje��6u   $
��Left=�5"       $��Center=�6;   
�������6V   �� 5#      -   5        $��	btncerrar��5#      $��r��6.     DesignButtonClose#���  6:   $��Right=�6f   5$      5%      5&      � 5(      $��1��6   
 K� ZIndex$
 10��6    
�������$��10q�6E    � ColumnDefinitions 5*      �� 5+      $��20 �6'   �� 5,      $��40 �6'   �� 5-      .+�53      " 	 FontAwesome.WPF.ImageAwesome  -   5        $��imginf��53   "   $��1��60      Icon$ 
InfoCircle=�6@      
Foreground �	#FF1E7AA1$��Center=�6i   $��Center=�6�   $y�	Collapsed=�6�     54      -   5        $��imgquest��54   "   $��1��62   $ QuestionCircle=�6B    �	#FF2AA100$��Center=�6o   $��Center=�6�   $y�	Collapsed=�6�     55      -   5        $��imgwarn��55   "   $��1��61   $ ExclamationCircle=�6A    �	#FFE7B529$��Center=�6q   $��Center=�6�   $y�	Collapsed=�6�     56      -   5        $��imgerror��56   "   $��1��62   $ TimesCircle=�6B    �	#FFFF591A$��Center=�6l   $��Center=�6�   $y�	Collapsed=�6�   �� 58      $��2��6   $
��Auto=�6/   .��59      �� -	   5        $��
txtmensaje��59       
���   �$��15q�6F   $��Center=�6R   $��Center=�6o   $��Century Gothic)�5:       $	��600��6<   $
��Auto��6K   $
��Wrap=�6Y    �� TextAlignment$ Justify=�6m   5;      5<      5?      � 5A      $��2��6    5B      �� 5C      �� 5D      .+�5F      �� -
   5        $
��btn1��5F      $�� ��6%   $	��250��60   $
��11,0q�6?   $��0��6M     DesignButton#���  6]   |�. $��0��5G   *   67   �� 5H      -   5        $
��btn2��5H      $�� ��6%   $	��250��60   $
��11,0q�6?   $��1��6M   #���  6]   |�. $��0��6�   5I      �� 5J      -   5        $
��btn3��5J      $�� ��6%   $	��250��60   $
��11,0q�6?   $��0��6M   $��2��6]   #���  6q   |�. $��0��6�   5K      5M      5O      5Q      5T      