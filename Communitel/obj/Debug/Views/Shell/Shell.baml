   M S B A M L   `   `   `  ����E  ACommunitel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Communitel.Views.ShellCommunitel.Views.Shell  5   	   "    Communitel.Views.Shell.Shell   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:Communitel.Views.Shell     5   	   l hMicrosoft.Practices.Prism.Composition, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35m iMicrosoft.Practices.Prism.Mvvm.Desktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jMicrosoft.Practices.Prism.Interactivity, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35-prismhttp://www.codeplex.com/prism    5   	   Z VFontAwesome.WPF, Version=4.5.0.37524, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5   	     � Title$  Shell��5
   	   $	��300��6   $	��300��6$    � WindowState$ 	Maximized=�60    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $= 7/Communitel.Common;component/Themes/StyleScrollBar.xaml?�6&   %    5      .��5      � .+�5   
   �  � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5       � RowDefinitions 5      �� 5      .+�5      �� $��0��6   $��0��6*   5  /Microsoft.Practices.Prism.Regions.RegionManager   
RegionName$ NavigationRegion��6:   $
��Auto��6l   �� 5      $��0��6   $��1��6*   $ WorkSpaceRegion��6:   $
��Auto��6k   5       �� 5!   
   $ PopupRegion��6   $
��Auto��6F   �� 5"   
   $ Popup2Region��6   $
��Auto��6G   �� 5#   
   $ IndicatorRegion��6   $
��Auto��6J   5$      5%      