   M S B A M L   `   `   `  ���� G  CGiftNotation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:GiftNotation.ConvertersGiftNotation.Converters  !    GiftNotation.Views.AddGifts   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     <
converters%clr-namespace:GiftNotation.Converters     -     � Title$  Подарок��$	��350��$	��500�� � WindowStyle$
 None=� � AllowsTransparency$
 True��
������  � 	Resources 9   3GiftNotation.Converters.StringToVisibilityConverter   StringToVisibilityConverter��%   &	          .����  �� CornerRadius$ 20�����#afb3b7$��3q����#666562._�� .+��� $��0��$��ДОБАВЛЕНИЕ��$��18(�$��25��$
��Bold"�$��Center=�$	��Top=�$��0,10,0,0q�� $��	0,40,0,40q� � RowDefinitions �� $��* ��� $��45 ��� $��45 ��� $��45 �.+��� .+��� $��0��$	��130��$	��450�����#cacac8$ 5��._�� $��10,0,0,0q�$��Center=� � ColumnDefinitions �� $��* ��� $
��auto �.+��� $��0��$��0�� �� Orientation$ Vertical=�.+���  � Cursor$ Arrow��$��25��$��0��$��0��$
��Left=�$��0,5,0,0q�$	��255��._��� .u�� .+�� $	��255��$��30��$��Center=�$��0,0,0,0q�.+��� -   	 ��Name$	 TextVisibilityForNameGift��$��12(�$��5q����#dbd8d4
 �� TextWrapping$

 Wrap=�" �� VerticalScrollBarVisibility$
 Auto=����� *
GiftName+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=�.���� $0��*Наименование подарка...�� J� Opacity$	 0.5Q�
�������$��Center=� �� Padding$ 5q� J� IsHitTestVisible$ False��$��2,0,0,0q�y��� *Text+ �� ElementName$ TextVisibilityForNameGift�� �� 	Converter# [  ����  �� 
TargetType" ��.���  �� Property � �� �� Value
 ���� ��  � ��$ 0q���  �@��CornerRadius$ 0�� �� Triggers ��  �� Binding �� *IsGiftNameValid+ �� Value	 False.a���  � ��
 �  ����  � ��$ 2q���  �@��CornerRadius$ 2����  �� *IsGiftNameValid+ True.a���  � �� �#707976��  � ��$ 2q���  �@��CornerRadius$ 2���� $ 2��$��25�����#707976$��2q�$��2��$��0��$
��Left=�$��0,5,0,0q�$	��255��._��� .u�� .+�� $	��255��$��30��$��Center=�$��-2,0,0,0q�.+��� -   $!	 TextVisibilityForSsylkaGift��$��12(�$��5q����#dbd8d4$

 Wrap=�$
 Auto=����� *Url+�� $1��+Ссылка на маркетплейс...��$	 0.5Q�
�������$��Center=�$ 5q�$ False��y��� *Text+$! TextVisibilityForSsylkaGift��# [  �� $ 2��$��55�����#707976$��2q�$��2��$��0��$
��Left=�$��0,5,0,0q�$	��255��._��� .u�� .+��� -   $"	 TextVisibilityForDescription��$

 Wrap=�$
 Auto=�$��12(�$��2q�$	��255�����#dbd8d4���� *Description+�� $��Описание...��$	 0.5Q�
�������$ 5q�$ False��$	��Top=�$��2,0,0,0q�y��� *Text+$" TextVisibilityForDescription��# [  �� $��1��$��0��$ Vertical=�.+��� 
�������$	��160��$��90��$��2q�$ 8�����#c5c2c2$��0,0,5,0q� J� 	AllowDrop$
 True��$��Right=�._��� ���� *OpenFileDialogForPicture+���� " ��.���  � �� ��  �� 
TargetType" ��.R�� .+���  ��Name$ Button_Border��$ 7��
������ ���� 
color1�� �� Color$ #b6b7ba���� $��Stretch=�$��Stretch=�$
��auto��$
��auto������ *	GiftPic+�� $��Center=�$��Center=� �� Triggers :�  :� RoutedEvent$ Border.MouseEnter��.[��� .���� .����  �� TargetProperty$ Color�  �� 
TargetName$  color1��! �� From! #b6b7ba	" �� To" #7e8080# g� Duration$# 0:0:0.2D�:� $ Border.MouseLeave��.[��� .���� .���� $ Color�$  color1��! #7e8080" #b6b7ba$# 0:0:0.3D�P� $ P� Property$ � ��% P� Value$
% True��. ��� & �� 
TargetName$& Button_Border�� � �� �#97999f�� $& Button_Border�� � ��
 ���� �� $& Button_Border�� � ��$ 2q��� $��30��$	��160��$��1�����#cacac8$ 5��$
��Left=�._�� $��10,0,0,0q�$��Center=�$
��Left=� �� $
��auto ��� $��* �.+��� $��	Цена:��$��14(�$��Center=�$��0���� $��12(�$��2q����#cacac8$��Center=�$��1��$	��100��$��5,0,0,0q����� *Price+�� $��30��$��1��$	��450�����#cacac8$ 5��._�� $��10,0,0,0q�$��Center=� �� $
��Auto ��� $��* �.+��� $��	Люди:��$��14(�$��Center=�$��0���� $��12(�$��2q�$	��390�����#cacac8$��Center=�$��1��$��0,0,0,0q�' �� DisplayMemberPath$' ContactName��( �� 
IsEditable$( False������ *
Contacts+) �� SelectedItem) �� *SelectedContact+{��� *HasContacts+�� $��30��$��2��$	��450�����#cacac8$ 5��._�� $��10,0,0,0q�$��Center=� �� $
��Auto ��� $��* �.+��� $��Событие:��$��14(�$��Center=�$��0���� $	��360��$��1�����#cacac8$' 	EventName��$( False������ *Events+) �� *SelectedEvent+{��� *	HasEvents+�� $��30��$	��450��$��4�����#cacac8$ 5��._�� $��10,0,0,0q�$��Center=� �� $
��Auto ��� $��* �.+��� $��Статус��$��14(�$��Center=�$��0���� $	��380��$��1�����#cacac8$' 
StatusName��$( False������ *
Statuses+) �� *SelectedStatus+�� $��2��$ 
Horizontal=�$��Bottom=�.+��� -   ���#2c2b2a$	��100��$��20��$��	10,0,0,10q����� " ��.���  � �� �� " ��.R��� $ Button_Border��$ 7��
������ ���� 
color1��$ #292a2c��._��� $��65��$��15��$��Center=�$��Center=�$��3,-2,0,0q� :� $ Border.MouseEnter��.[��� .���� .���� $ Color�$  color1��! #292a2c" #414b4d$# 0:0:0.2D�:� $ Border.MouseLeave��.[��� .���� .���� $ Color�$  color1��! #414b4d" #292a2c$# 0:0:0.3D�P� $ � ��$
% True��. ��� $& Button_Border�� � ��
 ������� $& Button_Border�� � �� �#121a1d�� $& Button_Border�� � ��$ 2q�.���� $��Отменить��$��65��$��14(�$
��Bold)����#e2ddd9�� ���#2c2b2a$��20��$	��100��$��
275,0,0,10q����#e2ddd9���� *AddGiftCommand+���� * �� RelativeSource* �� + �� AncestorType
+ Window���� " ��.���  � �� �� " ��.R��� $ Button_Border��$ 7��
������ ���� 
color1��$ #292a2c��._��� $��60��$��15��$��Center=�$��Center=�$��3,-2,0,0q� :� $ Border.MouseEnter��.[��� .���� .���� $ Color�$  color1��! #292a2c" #414b4d$# 0:0:0.2D�:� $ Border.MouseLeave��.[��� .���� .���� $ Color�$  color1��! #414b4d" #292a2c$# 0:0:0.3D�P� $ � ��$
% True��. ��� $& Button_Border�� � ��
 ������� $& Button_Border�� � �� �#121a1d�� $& Button_Border�� � ��$ 2q�.���� $��Center=�$��Готово��$��14(�$
��Bold)����#e2ddd9