   M S B A M L   `   `   `  ����G  CGiftNotation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:GiftNotation.ViewsGiftNotation.Views  5           GiftNotation.Views.Filters   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:GiftNotation.Views     5      $	��120��5      $	��300��6     � WindowStyle$
  None=�5	       � Topmost$
 True��5
       � 
ResizeMode$ NoResize=�5       � WindowStartupLocation$ Manual=�5       � Left$	 100��5      
 � Top$	 100��6   .��5      �� ���#2c2b2a.+�5   
   � $��0, 10, 0, 0q�6    � ColumnDefinitions 5      �� 5      $
��auto �6#   �� 5      $��* �6#   .+�5      �� $%��События за месяц:��6   
�������$��Center=�6H   $��14(�6c    �� Padding$ 5q�6q   $��0��6}   �� 5      $��1��6   $��
0, 0, 5, 0q�6(   ��6<   �� *Month+ �� SelectedItem 5      �� *SelectedMonth+5      � 5   
   $��0, 10, 0, 0q�6    5      �� 5      $
��auto �6#   �� 5      $��* �6#   .+�5      �� $��Тип события:��6   
�������$��Center=�6C   $��14(�6^   $ 5q�6l   $��0��6x   �� 5      $��1��6   $��
0, 0, 5, 0q�6(   	 �� DisplayMemberPath$	 EventTypeName��5      ��5   <   �� *
EventTypes+ 5       �� *SelectedEventType+5!      � 5"   
   $��0, 10, 0, 0q�6    5#      �� 5$      $
��auto �6#   �� 5%      $��* �6#   .+�5'      �� $*��$Категория контакта:��6   
�������$��Center=�6J   $��14(�6e   $ 5q�6s   $��0��6   �� 5(      $��1��6   $��
0, 0, 5, 0q�6(   $	 RelpTypeName��5)      ��5(   <   �� *	RelpTypes+ 5*      �� *SelectedRelpType+5+      5,      5-      