   M S B A M L   `   `   `  ����U  QCommunitel.CheckIn.Plugins, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Communitel.CheckIn.ViewsCommunitel.CheckIn.Views  5      -    'Communitel.CheckIn.Views.AddPersonsView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:Communitel.CheckIn.Views     5      $	��500��5   8   $	��460��6E     � 	Resources  5
       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $7 1/Communitel.Common;component/Themes/StyleApp.xaml?�6&   �� 5      $; 5/Communitel.Common;component/Themes/StyleTextBox.xaml?�6&   �� 5      $: 4/Communitel.Common;component/Themes/StyleButton.xaml?�6&   �� 5      $< 6/Communitel.Common;component/Themes/StyleGroupBox.xaml?�6&   %    5      .��5      ��    DesignGroupBox#���   6   $��Person Information��68   .��5   
   �  � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5       $
��Auto �6    .+�5#      �� $��
Given Name��6   $��0��6*   �� 5$        DesignTextBox#���  6   $��1��6>   ��6K   ��  �� Path$ Category.code��� 5%      $��
Midle name��6   $��2��6*   �� 5&      #���  6   $��3��6>   ��6K   �� $ Category.description��� 5(      $��Surname��6   $��4��6'   �� 5)      #���  6   $��5��6>   ��6K   �� $ Category.code��� 5*      $��	Surname 2��6   $��6��6)   �� 5+      #���  6   $��7��6>   ��6K   �� $ Category.description��� 5-      $	��Add��6     DesignButton#���  6#   $��8��6J   ��6W   �� *AddCategoryCommand+5/      50      51      