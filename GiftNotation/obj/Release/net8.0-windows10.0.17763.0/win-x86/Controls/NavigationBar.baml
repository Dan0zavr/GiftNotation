   M S B A M L   `   `   `  ���� G  CGiftNotation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:GiftNotation.ControlsGiftNotation.Controls  M+clr-namespace:GiftNotation.State.NavigatorsGiftNotation.State.Navigators  )    #GiftNotation.Controls.NavigationBar   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     5local#clr-namespace:GiftNotation.Controls     B
navigation+clr-namespace:GiftNotation.State.Navigators     .����   �� CornerRadius$  	20,20,0,0�����#2c2b2a$��35��$	��Top=�._��� $	��Top=�$	��700��$��0,0,0,0q� �� Orientation$ 
Horizontal=�$��0��$��2��$��Stretch=�$��35��.+��� -   $��25�� � Cursor$
 Hand��$��23�����#B6b7ba$��10,0,5,0q�����  �� 
TargetType" ��.���  �� Property � �� �� Value ��  �� 
TargetType" ��.R���  ��Name$ Button_Border��$  5��
������ ���� 
color1�� �� Color$ #B6b7ba��._��� $��15��$��15��$��Center=�$��Center=�$��3,-2,0,0q�	 �� Triggers	 :� 
 :� RoutedEvent$
 Border.MouseEnter��.[��� .���� .����  �� TargetProperty$ Color� �� 
TargetName$ color1�� �� From #B6b7ba	 �� To Gray g� Duration$ 0:0:0.2D�:� $
 Border.MouseLeave��.[��� .���� .���� $ Color�$ color1�� Gray #B6b7ba$ 0:0:0.3D�P�  P� Property � �� P� Value$
 True��. ���  �� 
TargetName$ Button_Border�� � ��
 ������� $ Button_Border�� � �� �#121a1d�� $ Button_Border�� � ��$ 2q�.���� $��X��$��18(�$��Heavy"��� -   $��25��$
 Hand��$��23�����#B6b7ba$��2,0,15,0q����� " ��.���  � �� �� " ��.R��� $ Button_Border��$  5��
������ ���� 
color1��$ #B6b7ba��._��� $��25��$��25��$��Center=�$��Center=�$��0,-2,0,0q�	 :� $
 Border.MouseEnter��.[��� .���� .���� $ Color�$ color1�� #B6b7ba Gray$ 0:0:0.2D�:� $
 Border.MouseLeave��.[��� .���� .���� $ Color�$ color1�� Gray #B6b7ba$ 0:0:0.3D�P�  � ��$
 True��. ��� $ Button_Border�� � ��
 ������� $ Button_Border�� � �� �#121a1d�� $ Button_Border�� � ��$ 2q�.���� $��-��$��30(� �� TextAlignment$ Center=�$��Heavy"�$��0,-6,0,0q�$��36��$	��Top=��� $��5,0,20,0q�$
 Hand�����#B6b7ba$	��130��$��Center=�$��23��,   &GiftNotation.State.Navigators.ViewType   Calendar#��Z ���� *UpdateCurrentVMCommand+���� " ��.���  � �� �� " ��.R��� $ Button_Border��$  5��
������ ���� 
color1��$ #B6b7ba��._��� $��75��$��15��$��Center=�$��Center=�	 :� $
 Border.MouseEnter��.[��� .���� .���� $ Color�$ color1�� #B6b7ba Gray$ 0:0:0.2D�:� $
 Border.MouseLeave��.[��� .���� .���� $ Color�$ color1�� Gray #B6b7ba$ 0:0:0.3D�P�  � ��$
 True��. ��� $ Button_Border�� � ��
 ������� $ Button_Border�� � �� �#121a1d�� $ Button_Border�� � ��$ 2q�.���� $��Medium"�$��КАЛЕНДАРЬ��$
��Left=�$��75���� $��5,0,20,0q�$
 Hand�����#B6b7ba$	��130��$��Center=�$��23��   Events#��Z ���� *UpdateCurrentVMCommand+���� " ��.���  � �� �� " ��.R��� $ Button_Border��$  5��
������ ���� 
color1��$ #B6b7ba��._��� $��75��$��15��$��Center=�$��Center=�	 :� $
 Border.MouseEnter��.[��� .���� .���� $ Color�$ color1�� #B6b7ba Gray$ 0:0:0.2D�:� $
 Border.MouseLeave��.[��� .���� .���� $ Color�$ color1�� Gray #B6b7ba$ 0:0:0.3D�P�  � ��$
 True��. ��� $ Button_Border�� � ��
 ������� $ Button_Border�� � �� �#121a1d�� $ Button_Border�� � ��$ 2q�.���� $��Medium"�$��СОБЫТИЯ��$��Center=��� $��3,0,20,0q�$��23��$
 Hand�����#B6b7ba$	��130��   Gifts#��Z ���� *UpdateCurrentVMCommand+���� " ��.���  � �� �� " ��.R��� $ Button_Border��$  5��
������ ���� 
color1��$ #B6b7ba��._��� $��60��$��15��$��Center=�$��Center=�	 :� $
 Border.MouseEnter��.[��� .���� .���� $ Color�$ color1�� #B6b7ba Gray$ 0:0:0.2D�:� $
 Border.MouseLeave��.[��� .���� .���� $ Color�$ color1�� Gray #B6b7ba$ 0:0:0.3D�P�  � ��$
 True��. ��� $ Button_Border�� � ��
 ������� $ Button_Border�� � �� �#121a1d�� $ Button_Border�� � ��$ 2q�.���� $��Medium"�$��ПОДАРОК���� -   $��	peoplebtn��$��3,0,28,0q�$	��130��$��23��$
 Hand��   Contacts#��Z ���#B6b7ba���� *UpdateCurrentVMCommand+���� " ��.���  � �� �� " ��.R��� $��Button_Border��$  5������ xz��$ #B6b7ba��._��� $��45��$��15��$��Center=�$��Center=�	 :� $
 Border.MouseEnter��.[��� .���� .���� $ Color�$ xz�� #B6b7ba Gray$ 0:0:0.2D�:� $
 Border.MouseLeave��.[��� .���� .���� $ Color�$ xz�� Gray #B6b7ba$ 0:0:0.3D�P�  � ��$
 True��. ��� $ Button_Border�� � ��
 ������� $ Button_Border�� � �� �#121a1d�� $ Button_Border�� � ��$ 2q�.���� $��Medium"�$��ЛЮДИ��