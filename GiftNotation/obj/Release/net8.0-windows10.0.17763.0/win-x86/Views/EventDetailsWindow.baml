   M S B A M L   `   `   `  ���� G  CGiftNotation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:GiftNotation.ViewsGiftNotation.Views  A%clr-namespace:GiftNotation.ConvertersGiftNotation.Converters  +    %GiftNotation.Views.EventDetailsWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     2local clr-namespace:GiftNotation.Views     <
converters%clr-namespace:GiftNotation.Converters     -     � Title$  EventDetailsWindow��$	��300��$	��400�� � WindowStyle$
 None=� � AllowsTransparency$
 True��
������  � 	Resources 9   3GiftNotation.Converters.StringToVisibilityConverter   StringToVisibilityConverter��%   &	          .����  �� CornerRadius$ 20��$��3q����#b6b7ba���#7e8080._�� .+���  � Cursor$ Arrow��$��30��$	��365��$	��Top=�$��Center=�$��0,10,0,0q�._��� .u�� $ Arrow��.+�� .+��� -    ��Name$ TextVisibilityForNameGift��$��12(�$��5q�$	��362��$��30�����#afb3b7���� *	EventName+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�.������ 	 �� 
TargetType"	 ��
 �� Triggers
 ��  �� Binding �� *IsEventNameValid+ �� Value	 False.a���  �� Property � �� �� Value
 �  ����  � ��$ 1q���  �� *IsEventNameValid+ True.a���  � �� �#253336��  � ��$ 1q�.���� $(��"Название события...��$	��150�� J� Opacity$	 0.5Q����#46464a$��Center=� �� Padding$ 5q� J� IsHitTestVisible$ False��$��2,0,0,0q�$
��Left=�y��� *Text+ �� ElementName$ TextVisibilityForNameGift�� �� 	Converter# [  �� $��25��$	��180��$
��Left=�$��10,-160,0,0q�.+��� $��Right=�$��25��$	��140��._��� -    ��Name$ 	EnterDate��$��Center=� �� TextAlignment$ Center=�$��Center=�$��13(����� *	EventDate+ �� StringFormat$ {0:dd.MM.yyyy}������ "	 ��
 ��  �� *IsEventDateValid+	 False.a���  � ��
 �  ����  � ��$ 1q���  �� *IsEventDateValid+ True.a���  � ��
 �   ���  � ��$ 1q��� $��Дата��$��Medium"�$��Center=�$��14(�$��50��$
��Left=�$��	0,-26,0,0q��� $��25��$	��350��$��0,-100,10,0q�$
��Left=�.+��� -    ��Name$ Tip_prasdnicaa��
������ 
����  �$	��120��$��Center=�$��10,2,0,0q� �� DisplayMemberPath$ EventTypeName�� �� 
IsEditable$ False������ *
EventTypes+ �� SelectedItem �� *	EventType+���� "	 ��
 ��  �� *IsEventDateValid+	 False.a���  � ��
 �  ����  � ��$ 1q���  �� *IsEventDateValid+ True.a���  � ��
 �������  � ��$ 1q��� $
��Left=�$��14(�$��Center=�$ ��Тип праздника:��$��
10,-18,0,0q��� $	��135��$	��400�����#cacac8$ 5��$��0,80,0,0q�._�� $��	10,0,10,0q� � ColumnDefinitions �� $��* ��� $
��auto ��� $��* �.+��� $��0��$	��120��$	��150��$��Center=�.+��� $	��120��$ 5��$	��150��$��2q�
�������._�� .+��� $��5,2,0,0q�$��	Люди:��$��14(�$
��Bold)�$	��Top=��� $��85��$	��130��$ ContactName�����#cacac8$��0,10,0,0q����� *
Contacts+ �� *SelectedContact+�� $��1��$��Center=�.+��� $��Добавить>��$��Center=�$��Center=����#292a2c$��12(�$
��Bold)�$��18��$��3q����� *AddContactOnEventCommand+���� "	 ��.���  � �� ��  �� 
TargetType" ��.R���  ��Name$ Button_Border��$ 7��
������ ���� 
color1�� �� Color$
 Gray��._��� $��65��$��15��$��Center=�$��Center=�$��3,-2,0,0q� �� Triggers :�   :� RoutedEvent$  Border.MouseEnter��.[��� .���� .���� ! �� TargetProperty$! Color�" �� 
TargetName$" color1��# �� From# Gray	$ �� To$ #5d5b59% g� Duration$% 0:0:0.2D�:� $  Border.MouseLeave��.[��� .���� .���� $! Color�$" color1��# #5d5b59$ Gray$% 0:0:0.3D�P� & P� Property& � ��' P� Value$
' True��. ��� ( �� 
TargetName$( Button_Border�� � �� �#7e7d7b�� $( Button_Border�� � ��$ 2q��� $��<Удалить��$��Center=�$��Center=����#292a2c$��3q�$��18��$��12(�$
��Bold)����� *DeleteContactFromEventCommand+���� "	 ��.���  � �� �� " ��.R��� $ Button_Border��$ 7��
������ ���� 
color1��$
 Gray��._��� $��65��$��15��$��Center=�$��Center=�$��3,-2,0,0q� :� $  Border.MouseEnter��.[��� .���� .���� $! Color�$" color1��# Gray$ #5d5b59$% 0:0:0.2D�:� $  Border.MouseLeave��.[��� .���� .���� $! Color�$" color1��# #5d5b59$ Gray$% 0:0:0.3D�P� & � ��$
' True��. ��� $( Button_Border�� � �� �#7e7d7b�� $( Button_Border�� � ��$ 2q��� $��2��$	��120��.+��� $	��120��$ 5��$	��150��$��2q�
�������._�� .+��� $��5,2,0,0q�$��На празднике:��$��14(�$
��Bold)�$	��Top=��� $��85��$	��130��$ ContactName��$��0,10,0,0q����#cacac8���� *ContactsOnEvent+ �� *SelectedContactOnEvent+�� ) �� Orientation$) 
Horizontal=�$��Bottom=�.+��� -   $��90��$��18��$��	10,0,0,10q����� "	 ��.���  � �� �� " ��.R��� $ Button_Border��$ 7��
������ ���� 
color1��$ #292a2c��._��� $��60��$��15��$��Center=�$��Center=�$��3,-2,0,0q� :� $  Border.MouseEnter��.[��� .���� .���� $! Color�$" color1��# #292a2c$ #414b4d$% 0:0:0.2D�:� $  Border.MouseLeave��.[��� .���� .���� $! Color�$" color1��# #414b4d$ #292a2c$% 0:0:0.3D�P� & � ��$
' True��. ��� $( Button_Border�� � �� �#545755�� $( Button_Border�� � ��$ 2q�.���� $��Отменить��$��0,1,0,0q����	#FFF0F0F0$��12(�$
��Bold)��� $��90��$��20��$��
196,0,0,10q����#292a2c���� *AddEventCommand+���� * �� RelativeSource* �� + �� AncestorType
+ Window���� "	 ��.���  � �� �� " ��.R��� $ Button_Border��$ 7��
������ ���� 
color1��$ #292a2c��._��� $��60��$��15��$��Center=�$��Center=�$��3,-2,0,0q� :� $  Border.MouseEnter��.[��� .���� .���� $! Color�$" color1��# #292a2c$ #414b4d$% 0:0:0.2D�:� $  Border.MouseLeave��.[��� .���� .���� $! Color�$" color1��# #414b4d$ #292a2c$% 0:0:0.3D�P� & � ��$
' True��. ��� $( Button_Border�� � �� �#545755�� $( Button_Border�� � ��$ 2q�.���� $��Готово��$��40��$��0,1,0,0q����	#FFF0F0F0$��12(�$
��Bold)�