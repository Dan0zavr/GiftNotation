   M S B A M L   `   `   `  ���� G  CGiftNotation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:GiftNotation.ViewsGiftNotation.Views  =#clr-namespace:GiftNotation.CommandsGiftNotation.Commands  "    GiftNotation.Views.GiftsView   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     2local clr-namespace:GiftNotation.Views     8commands#clr-namespace:GiftNotation.Commands     $	��400��$	��700��  � 	Resources     CustomScrollBarStyle �� 
TargetType �� Property �� Value �� 
TargetType �Name  Key �� 
StartPoint �� EndPoint � Color	 � Offset
 ]� Thumb ]� DecreaseRepeatButton ]� IncreaseRepeatButton  TextFon �� Color  	TextColor �� CornerRadius ! GiftNameWithHyperlinkTemplate �� TextAlignment $  GiftNameWithoutHyperlinkTemplate1   +GiftNotation.Views.GiftNameTemplateSelector  GiftNameTemplateSelector$   GiftNameWithHyperlinkTemplate'    GiftNameWithoutHyperlinkTemplate��%�  &	        &	 �    &	 �    '��     &	 �    &	 >    &	 u    7  7  �� " ��.���  � ��$ 12����  � ��$ 12����  � ��
 ���� ��  � ��
 �������  �@��Orientation$ Vertical=���  � �� �� " ��.R�� $
 Grid��  ���� TrackBackground $	 0,0&�$	 1,1&�.��� $ 	LightGray��$		 0.0Q�� $ DarkGray��$		 1.0Q�.+�]� $��
PART_Track��$
��True��
 n� $��
PART_Thumb��
�����F�$��12�� �� 
�������$��12��$��12��$	��◁�� �� 
�������$��12��$��12��$	��▷���� $ #DFB6B2���� $ #f3f4ea���� " ��.���  � �� �� " ��.R��� #��z��#��z��#��z��$ 3��._��� #��z��#��z��$��Center=�$��Center=���  � ��# �  ��  � ��# �  �� .R�� $��Center=�$��Center=�.+��� $
��Wrap=�$ Center=��� -   ���� *Url+.�.��� $��16(���� *
GiftName+�� .R��� $��16(�$
��Wrap=����� *
GiftName+  8   8  .���� ���#7e7f7b$ 	0,0,20,20��._�� .+���  �� Orientation$ 
Horizontal=�$	��250��$��-375,-330,0,0q�$��30��.+��� ���#2c2b2a$	��100��$��20��$��5,0,5,0q����� *OpenAddGiftCommand+���� " ��.���  � �� �� " ��.R���  ��Name$ Button_Border��$ 7��
������ ���� 
color1��$ #292a2c��._��� $��60��$��15��$��Center=�$��Center=�$��3,-2,0,0q� �� Triggers :�  :� RoutedEvent$ Border.MouseEnter��.[��� .���� .����  �� TargetProperty$ Color� �� 
TargetName$ color1�� �� From #292a2c	 �� To #414b4d g� Duration$ 0:0:0.2D�:� $ Border.MouseLeave��.[��� .���� .���� $ Color�$ color1�� #414b4d #292a2c$ 0:0:0.3D�P�  P� Property � �� P� Value$
 True��. ���  �� 
TargetName$ Button_Border�� � ��
 ������� $ Button_Border�� � �� �#121a1d�� $ Button_Border�� � ��$ 2q�.���� 
�������$��0,1,0,0q�$��70��$��Добавить���� ���#2c2b2a$	��120��$��20��$��5,0,5,0q����� *OpenChangeGiftCommand+���� " ��.���  � �� �� " ��.R��� $ Button_Border��$ 7��
������ ���� 
color1��$ #292a2c��._��� $��85��$��15��$��Center=�$��Center=�$��3,-2,0,0q� :� $ Border.MouseEnter��.[��� .���� .���� $ Color�$ color1�� #292a2c #414b4d$ 0:0:0.2D�:� $ Border.MouseLeave��.[��� .���� .���� $ Color�$ color1�� #414b4d #292a2c$ 0:0:0.3D�P�  � ��$
 True��. ��� $ Button_Border�� � ��
 ������� $ Button_Border�� � �� �#121a1d�� $ Button_Border�� � ��$ 2q�.���� 
�������$ ��Редактировать��$��85��$��0,1,0,0q��� -   $��90��$��20�����#2c2b2a$��0,-330,-540,0q����� *DeleteGiftCommand+���� " ��.���  � �� �� " ��.R��� $ Button_Border��$ 7��
������ ���� 
color1��$ #292a2c��._��� $��60��$��15��$��Center=�$��Center=�$��3,-2,0,0q� :� $ Border.MouseEnter��.[��� .���� .���� $ Color�$ color1�� #292a2c #414b4d$ 0:0:0.2D�:� $ Border.MouseLeave��.[��� .���� .���� $ Color�$ color1�� #414b4d #292a2c$ 0:0:0.3D�P�  � ��$
 True��. ��� $ Button_Border�� � ��
 ������� $ Button_Border�� � �� �#121a1d�� $ Button_Border�� � ��$ 2q�.���� 
�������$��46��$��0,1,0,0q�$��Удалить���� $��ПОДАРКИ��$��25(�$��Heavy"�$��Center=�$	��Top=�$��0,13,0,0q�$��Britannic Bold)�&   System.Windows.Controls.DataGrid  -     Name$ 	ddataGrid��   SelectionMode$ Extended=�$��3q�
���   ����	#FFDFDBD7    CanUserAddRows$  False��$��Bottom=�$	��325��$	��625��!   AutoGenerateColumns$! False��$��5,0,0,20q�"   CanUserResizeColumns$" False��# �� SelectedItem# �� *SelectedGift+$ �� UpdateSourceTrigger$$ PropertyChanged=����� *Gifts+  =  7System.Windows.Controls.Primitives.DataGridColumnHeader)  #System.Windows.Controls.DataGridRow*  $System.Windows.Controls.DataGridCell��%[  '        '  �     '      �� "  .���  � ��$ Center=���  � ��$ Center=���  � �� �#786e65��  � ��$ 30����  � ��
 �   ���  � ��$ 0,0,1,0q���  � ��$ 14(���  � ��
 �   ��� "  .���  � ��
 �   ���  � ��$ 0,0,0,1q��� "  .���  � �� �#cacac8%   Columns% 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn&   Header$& Подарок��'   Width5  /System.Windows.Controls.DataGridLengthConverter$' 80 (   CellTemplate( �� .R��� #��[ $��Center=�$��Center=�����   $& Картинка��$' 90 ( �� .R��� $
��auto��$
��auto��$��90��$��90������ *	GiftPic+)   CellEditingTemplate) �� .R��� $
��auto��$
��auto������ *	GiftPic+0	  *System.Windows.Controls.DataGridTextColumn	  $& Стоимость��$' 90 1
  +System.Windows.Controls.DataGridBoundColumn* 
  Binding* �� *Price+$$ PropertyChanged=�+ 
  ElementStyle+ �� " ��.���  �@��TextAlignment$ Center=���  � ��$ Center=���  � ��$ 16(�	  $& Люди��$' * * �� *ContactName+$$ PropertyChanged=�+ �� " ��.���  �@��TextAlignment$ Center=���  � ��$ Center=���  � ��$ 16(�	  $& Событие��$	' 130 * �� *	EventName+$$ PropertyChanged=�+ �� " ��.���  �@��TextAlignment$ Center=���  � ��$ Center=���  � ��$ 16(���  � ��$
 Wrap=�	  $& Статус��$	' 100 * �� *
StatusName+$$ PropertyChanged=�+ �� " ��.���  �@��TextAlignment$ Center=���  � ��$ Center=���  � ��$ 16(���  � ��$
 Wrap=�