   M S B A M L   `   `   `  ���� G  CGiftNotation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:GiftNotation.ViewsGiftNotation.Views  Y1clr-namespace:GiftNotation.Commands.EventCommands#GiftNotation.Commands.EventCommands  #    GiftNotation.Views.EventsView   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     2local clr-namespace:GiftNotation.Views     Fcommands1clr-namespace:GiftNotation.Commands.EventCommands     $	��400��$	��700��  � 	Resources     TextFon �� Color  	TextColor �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius��%�   &	        &	      '�� &     �� $ #DFB6B2���� $ #f3f4ea���� " ��.���  � �� �� " ��.R��� #��z��#��z��#��z��$ 3��._��� #��z��#��z��$��Center=�$��Center=���  � ��# �   ��  � ��# �  .���� ���#7e7f7b$ 	0,0,20,20��._�� .+���  �� Orientation$ 
Horizontal=�$	��250��$��-375,-330,0,0q�$��30��.+��� ���#2c2b2a$	��100��$��20��$��5,0,5,0q����� *OpenAddEventCommand+���� " ��.���  � �� �� " ��.R���  ��Name$ Button_Border��$ 7��
������ ���� 
color1��$ #292a2c��._��� $��60��$��15��$��Center=�$��Center=�$��3,-2,0,0q�	 �� Triggers	 :� 
 :� RoutedEvent$
 Border.MouseEnter��.[��� .���� .����  �� TargetProperty$ Color� �� 
TargetName$ color1�� �� From #292a2c	 �� To #414b4d g� Duration$ 0:0:0.2D�:� $
 Border.MouseLeave��.[��� .���� .���� $ Color�$ color1�� #414b4d #292a2c$ 0:0:0.3D�P�  P� Property � �� P� Value$
 True��. ���  �� 
TargetName$ Button_Border�� � ��
 ������� $ Button_Border�� � �� �#121a1d�� $ Button_Border�� � ��$ 2q�.���� 
�������$��0,1,0,0q�$��70��$��Добавить���� ���#2c2b2a$	��120��$��20��$��5,0,5,0q����� *OpenChangeEventCommand+���� " ��.���  � �� �� " ��.R��� $ Button_Border��$ 7��
������ ���� 
color1��$ #292a2c��._��� $��85��$��15��$��Center=�$��Center=�$��3,-2,0,0q�	 :� $
 Border.MouseEnter��.[��� .���� .���� $ Color�$ color1�� #292a2c #414b4d$ 0:0:0.2D�:� $
 Border.MouseLeave��.[��� .���� .���� $ Color�$ color1�� #414b4d #292a2c$ 0:0:0.3D�P�  � ��$
 True��. ��� $ Button_Border�� � ��
 ������� $ Button_Border�� � �� �#121a1d�� $ Button_Border�� � ��$ 2q�.���� 
�������$ ��Редактировать��$��85��$��0,1,0,0q��� $
}�True��$ 
Horizontal=�$	��250��$��380,-330,0,0q�$��30��.+��� -   $��OpenFiltersButton��$��90��$��20�����#2c2b2a$��35,0,0,0q����� *OpenCloseFilterCommand+����  �� ElementName$ OpenFiltersButton������ " ��.���  � �� �� " ��.R��� $ Button_Border��$ 7��
������ ���� 
color1��$ #292a2c��._��� $��60��$��15��$��Center=�$��Center=�$��3,-2,0,0q�	 :� $
 Border.MouseEnter��.[��� .���� .���� $ Color�$ color1�� #292a2c #414b4d$ 0:0:0.2D�:� $
 Border.MouseLeave��.[��� .���� .���� $ Color�$ color1�� #414b4d #292a2c$ 0:0:0.3D�P�  � ��$
 True��. ��� $ Button_Border�� � ��
 ������� $ Button_Border�� � �� �#121a1d�� $ Button_Border�� � ��$ 2q�.���� 
�������$
��auto��$��0,1,0,0q�$��Фильтры��$��Center=��� $��90��$��20�����#2c2b2a$��30,0,0,0q����� *DeleteEventCommand+���� " ��.���  � �� �� " ��.R��� $ Button_Border��$ 7��
������ ���� 
color1��$ #292a2c��._��� $��60��$��15��$��Center=�$��Center=�$��3,-2,0,0q�	 :� $
 Border.MouseEnter��.[��� .���� .���� $ Color�$ color1�� #292a2c #414b4d$ 0:0:0.2D�:� $
 Border.MouseLeave��.[��� .���� .���� $ Color�$ color1�� #414b4d #292a2c$ 0:0:0.3D�P�  � ��$
 True��. ��� $ Button_Border�� � ��
 ������� $ Button_Border�� � �� �#121a1d�� $ Button_Border�� � ��$ 2q�.���� 
�������$��46��$��0,1,0,0q�$��Удалить���� $��СОБЫТИЯ��$��25(�$��Heavy"�$��Center=�$	��Top=�$��0,13,0,0q�$��Britannic Bold)�&   System.Windows.Controls.DataGrid  -     Name$ 	ddataGrid��$��3q�
���   ����	#FFDFDBD7   CanUserAddRows$ False��$��Bottom=�$	��325��$	��625��   AutoGenerateColumns$ False��$��5,0,0,20q�   
IsReadOnly$
 True�� �� SelectedItem �� *SelectedEvent+ �� UpdateSourceTrigger$ PropertyChanged=����� *Events+  =  7System.Windows.Controls.Primitives.DataGridColumnHeader)  #System.Windows.Controls.DataGridRow*  $System.Windows.Controls.DataGridCell��%[  '        '  �     '      �� "  .���  � ��$ Center=���  � ��$ Center=���  � �� �#786e65��  � ��$ 30����  � ��
 �   ���  � ��$ 0,0,1,0q���  � ��$ 14(���  � ��
 �   ��� "  .���  � ��
 �   ���  � ��$ 0,0,0,1q��� "  .���  � �� �#cacac8   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Название��   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *	EventName+$ PropertyChanged=�   ElementStyle �� " ��.���  �@��TextAlignment$ Center=���  � ��$ Center=���  � ��$ 16(���  � ��$
 Wrap=�  $ Дата��$ *  �� *	EventDate+$ PropertyChanged=� �� StringFormat$ {0:dd.MM.yyyy}�� �� " ��.���  �@��TextAlignment$ Center=���  � ��$ Center=���  � ��$ 16(�  $ Тип��$ *  �� *EventTypeName+$ PropertyChanged=� �� " ��.���  �@��TextAlignment$ Center=���  � ��$ Center=���  � ��$ 16(���  � ��$
 Wrap=�4	  .System.Windows.Controls.DataGridTemplateColumn	  $ Люди��$ *   	  CellTemplate  �� .R��� $��Center=�$��Center=�$��Disabled=�
������ 
������ ���� *ContactsOnEvent+���� .R��� $ Vertical=�$��Stretch=����� .R��� $��Center=�$��Center=�$
��Wrap=�$��16(����� *ContactName+