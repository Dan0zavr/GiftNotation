   M S B A M L   `   `   `  ����G  CGiftNotation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:GiftNotation.ControlsGiftNotation.Controls  5   	   M+clr-namespace:GiftNotation.State.NavigatorsGiftNotation.State.Navigators  5   	   7 clr-namespace:GiftNotation.ViewsGiftNotation.Views  5   	   #    GiftNotation.Views.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8controls#clr-namespace:GiftNotation.Controls     5   	   B
navigation+clr-namespace:GiftNotation.State.Navigators     5   	   2local clr-namespace:GiftNotation.Views     5   	     � Title$  Виш-листы��5
   	   $	��440��6   $	��700��6(    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5   	    � AllowsTransparency$
 True��5   	   
������  � 	Resources 5       �� 
TargetType �� Property �� Value �� 
TargetType	 �� CornerRadius��%�  '��       �� 5   
   " ��6   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��5   !   #��z��5   !   $	 5��5    !   ._�5!      �� $��Center=�6/   $��Center=�6L   5"      5#      5%      �� 5&       � �� �	#FF867C6F6+   �� 5'       � ��$ 13(�6)   �� 5(       � ��$ Medium"�6+   �� 5)       � ��
 �   �5+      5-      5/      .��53   
   � .+�55   
   �� ���#7e7d7b$	 20��56      $��3q�6(   ���#b6b7ba._�58      � 
 � RowDefinitions
 5:      �� 5;      $��35 �6$   �� 5<      $��* �6$   .+�5?      )   #GiftNotation.Controls.NavigationBar   � DataContext 6+   �� *	Navigator+�� 5A      $��1��6#   $��Stretch=�60   $��Stretch=�6N   ��6j   �� *Navigator.CurrentViewModel+5D      5E      5F      5H      