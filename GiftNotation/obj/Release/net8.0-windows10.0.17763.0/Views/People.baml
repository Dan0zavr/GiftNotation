   M S B A M L   `   `   `  ���� G  CGiftNotation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:GiftNotationGiftNotation      GiftNotation.Views.People   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ,localclr-namespace:GiftNotation     $��Stretch=�$��Stretch=�$	��400��$	��700��  � 	Resources  ��%    .���� ���#7e7d7b �� CornerRadius$ 	0,0,20,20��._�� .+���  �� Orientation$ 
Horizontal=�$	��245��$��-380,-330,0,0q�$��30��.+��� ���#2c2b2a$	��100��$��20��$��5,0,5,0q����� *OpenAddContactCommand+����  �� 
TargetType" ��.���  �� Property � �� �� Value ��  �� 
TargetType" ��.R���  ��Name$ Button_Border��$ 7��
������ ���� 
color1�� �� Color$ #292a2c��._��� $��60��$��15��$��Center=�$��Center=�$��3,-2,0,0q�	 �� Triggers	 :� 
 :� RoutedEvent$
 Border.MouseEnter��.[��� .���� .����  �� TargetProperty$ Color� �� 
TargetName$ color1�� �� From #292a2c	 �� To #414b4d g� Duration$ 0:0:0.2D�:� $
 Border.MouseLeave��.[��� .���� .���� $ Color�$ color1�� #414b4d #292a2c$ 0:0:0.3D�P�  P� Property � �� P� Value$
 True��. ���  �� 
TargetName$ Button_Border�� � �� �#545755�� $ Button_Border�� � ��$ 2q�.���� ���#c7c6cb$��0,1,0,0q�$��Добавить��$��15��$	��Top=��� ���#2c2825$	��120��$��20��$��5,0,5,0q����� *OpenChangeContactCommand+���� " ��.���  � �� �� " ��.R��� $ Button_Border��$ 7��
������ ���� 
color1��$ #292a2c��._��� $��80��$��15��$��Center=�$��Center=�$��3,-2,0,0q�	 :� $
 Border.MouseEnter��.[��� .���� .���� $ Color�$ color1�� #292a2c #414b4d$ 0:0:0.2D�:� $
 Border.MouseLeave��.[��� .���� .���� $ Color�$ color1�� #414b4d #292a2c$ 0:0:0.3D�P�  � ��$
 True��. ��� $ Button_Border�� � �� �#545755�� $ Button_Border�� � ��$ 2q�.���� $ ��Редактировать��$��0,1,0,0q�$��Center=����#c7c6cb�� ���#2c2825$��90��$��20��$��530,-330,0,0q����� *DeleteContactCommand+���� " ��.���  � �� �� " ��.R��� $ Button_Border��$ 7��
������ ���� 
color1��$ #292a2c��._��� $��60��$��15��$��Center=�$��Center=�$��3,-2,0,0q�	 :� $
 Border.MouseEnter��.[��� .���� .���� $ Color�$ color1�� #292a2c #414b4d$ 0:0:0.2D�:� $
 Border.MouseLeave��.[��� .���� .���� $ Color�$ color1�� #414b4d #292a2c$ 0:0:0.3D�P�  � ��$
 True��. ��� $ Button_Border�� � �� �#545755�� $ Button_Border�� � ��$ 2q�.���� $��Удалить��$��0,1,0,0q�$��45�����#c7c6cb�� $��ЛЮДИ��$��25(�$��Heavy"�$��Center=�$	��Top=�$��0,13,0,0q�$��Britannic Bold)�&   System.Windows.Controls.DataGrid  -     Name$ 	ddataGrid��   SelectionMode$ Extended=�$��3q�
���   ����	#FFDFDBD7   CanUserAddRows$ False��$��Bottom=�$	��325��$	��625��   AutoGenerateColumns$ False��$��5,0,0,20q�   CanUserResizeColumns$ False�� �� SelectedItem �� *SelectedContact+ �� UpdateSourceTrigger$ PropertyChanged=����� *
Contacts+  =  7System.Windows.Controls.Primitives.DataGridColumnHeader)  #System.Windows.Controls.DataGridRow*  $System.Windows.Controls.DataGridCell��%[  '        '  �     '      �� "  .���  � ��$ Center=���  � ��$ Center=���  � �� �#786e65��  � ��$ 30����  � ��
 �   ���  � ��$ 0,0,1,0q���  � ��$ 14(���  � ��
 �   ��� "  .���  � ��
 �   ���  � ��$ 0,0,0,1q��� "  .���  � �� �#cacac8   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Имя��   Width5  /System.Windows.Controls.DataGridLengthConverter$	 150 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *ContactName+$ PropertyChanged=�   ElementStyle �� " ��.���  �@��TextAlignment$ Center=���  � ��$ Center=���  � ��$ 16(���  � ��$
 Wrap=�  $ Тип отношений��$	 180  �� *RelpTypeName+$ PropertyChanged=� �� " ��.���  �@��TextAlignment$ Center=���  � ��$ Center=���  � ��$ 16(���  � ��$
 Wrap=�4	  .System.Windows.Controls.DataGridTemplateColumn	  $ День рождения��$	 150  	  CellTemplate �� .R��� $��16(�$��Center=�$��Center=����� *Bday+  �� StringFormat$  {0:dd.MM.yyyy}��$ PropertyChanged=�	  $ Подарки��$ *  �� .R��� $��Stretch=�$��Stretch=�$��Disabled=�
������ ���� *	MyGifts+���� .R��� $ Vertical=�$��Stretch=����� .R��� $��Center=�$��Center=�$��16(�$
��Wrap=����� *
GiftName+