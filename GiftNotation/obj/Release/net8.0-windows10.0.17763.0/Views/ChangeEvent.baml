   M S B A M L   `   `   `  ���� G  CGiftNotation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:GiftNotation.ViewsGiftNotation.Views  Y1clr-namespace:GiftNotation.Commands.EventCommands#GiftNotation.Commands.EventCommands  $    GiftNotation.Views.ChangeEvent   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     2local clr-namespace:GiftNotation.Views     Fcommands1clr-namespace:GiftNotation.Commands.EventCommands     -     � Title$  ChangeEvent��$	��350��$	��500�� � AllowsTransparency$
 True�� � WindowStyle$
 None=�
������  � 	Resources 2   ,GiftNotation.Views.DateTimeToStringConverter   DateTimeToStringConverter��%   &	          .����  �� CornerRadius$ 20�����#afb3b7$��3q����#7e8080._�� .+��� $"��РЕДАКТИРОВАНИЕ��$��18(�$��25��$
��Bold"�$��0��$��Center=�$	��Top=�$��0,10,0,0q��� $��	0,30,0,40q�.+��� $��30��$	��450�����#cacac8$ 5��$��10, 10, 10, 10q�._�� $��10,0,0,0q�$��Center=� � ColumnDefinitions �� $
��Auto ��� $��* �.+��� $&�� Название события:��$��14(�$��Center=�$��0���� $	��290��$��14(����#cacac8$��Center=�$��1��$��10,0,0,0q����� *	EventName+ �� UpdateSourceTrigger$ PropertyChanged=�.������  �� 
TargetType" �� �� Triggers �� 	 �� Binding	 �� *IsEventNameValid+
 �� Value	
 False.a���  �� Property � �� �� Value
 �  ����  � ��$ 1q��� 	 �� *IsEventNameValid+
 True.a���  � ��
 �������  � ��$ 1q�.���� $��30��$	��450�����#cacac8$ 5��$��10, 0, 10, 10q�._�� $��10,0,0,0q�$��Center=� �� $
��Auto ��� $��* �.+��� $"��Дата праздника:��$��14(�$��Center=�$��0���� $	��310��$��14(����#cacac8$��Center=�$��1��$��10,0,0,0q����� *RawEventDateInput+$ PropertyChanged=�.������ " �� �� 	 �� *IsEventDateValid+	
 False.a���  � ��
 �  ����  � ��$ 1q��� 	 �� *IsEventDateValid+
 True.a���  � ��
 �������  � ��$ 1q�.���� $��30��$	��450�����#cacac8$ 5��$��10, 0, 10, 10q�._�� $��10,0,0,0q�$��Center=� �� $
��Auto ��� $��* �.+��� $ ��Тип праздника:��$��14(�$��Center=�$��0���� $��14(����#cacac8$��Center=�$��1��$��10,0,0,0q� �� DisplayMemberPath$ EventTypeName�� �� SelectedValuePath$ EventTypeName�� �� 
IsEditable$ False��$	��317������ *
EventTypes+ �� SelectedItem �� *SelectedEventType+ �� SelectedValue �� *SelectedEventTypeName+�� $	��135��$	��450�����#cacac8$ 5��._�� $��	10,0,10,0q� �� $��* ��� $
��auto ��� $��* �.+��� $��0��$	��120��.+��� $	��130��$ 5��$��2q�
�������._�� .+��� $��5,5,0,0q�$��	Люди:��$��14(�$
��Bold)�$	��Top=��� $��90��$	��165��$ ContactName�����#cacac8$��0,10,0,0q����� *
Contacts+ �� *SelectedContact+�� $��1��$��Center=�.+��� $��Добавить>��$��Center=�$��Center=����#292a2c$��12(�$
��Bold)�$��18��$��3q����� *" AddContactOnEventOnChangeCommand+���� " ��.���  � �� ��  �� 
TargetType" ��.R���  ��Name$ Button_Border��$ 7��
������ ���� 
color1�� �� Color$
 Gray��._��� $��65��$��15��$��Center=�$��Center=�$��3,-2,0,0q� �� Triggers :�  :� RoutedEvent$ Border.MouseEnter��.[��� .���� .����  �� TargetProperty$ Color� �� 
TargetName$ color1�� �� From Gray	 �� To #5d5b59 g� Duration$ 0:0:0.2D�:� $ Border.MouseLeave��.[��� .���� .���� $ Color�$ color1�� #5d5b59 Gray$ 0:0:0.3D�P�  P� Property � �� P� Value$
 True��. ���  �� 
TargetName$ Button_Border�� � �� �#7e7d7b�� $ Button_Border�� � ��$ 2q��� $��<Удалить��$��Center=�$��Center=����#292a2c$��3q�$��18��$��12(�$
��Bold)����� *'%DeleteContactFromEventOnChangeCommand+���� " ��.���  � �� �� " ��.R��� $ Button_Border��$ 7��
������ ���� 
color1��$
 Gray��._��� $��65��$��15��$��Center=�$��Center=�$��3,-2,0,0q� :� $ Border.MouseEnter��.[��� .���� .���� $ Color�$ color1�� Gray #5d5b59$ 0:0:0.2D�:� $ Border.MouseLeave��.[��� .���� .���� $ Color�$ color1�� #5d5b59 Gray$ 0:0:0.3D�P�  � ��$
 True��. ��� $ Button_Border�� � �� �#7e7d7b�� $ Button_Border�� � ��$ 2q��� $��2��$	��120��.+��� 
�������$��2q�$ 5��$	��130��._�� .+��� $��5,5,0,0q�$��На празднике:��$��14(�$
��Bold)�$	��Top=��� $��90��$	��165��$ ContactName��$��0,10,0,0q����#cacac8���� *ContactsOnEvent+ �� *SelectedContactOnEvent+��  �� Orientation$ 
Horizontal=�$��Bottom=�.+��� -   $	��100��$��20��$��	10,0,0,10q����#292a2c���� " ��.���  � �� �� " ��.R��� $ Button_Border��$ 7��
������ ���� 
color1��$ #292a2c��._��� $��65��$��15��$��Center=�$��Center=�$��3,-2,0,0q� :� $ Border.MouseEnter��.[��� .���� .���� $ Color�$ color1�� #292a2c #414b4d$ 0:0:0.2D�:� $ Border.MouseLeave��.[��� .���� .���� $ Color�$ color1�� #414b4d #292a2c$ 0:0:0.3D�P�  � ��$
 True��. ��� $ Button_Border�� � ��
 ������� $ Button_Border�� � �� �#121a1d�� $ Button_Border�� � ��$ 2q�.���� $��Отменить��$��65�����	#FFF0F0F0$��14(�$
��Bold)��� $	��100��$��20��$��
280,0,0,10q����#292a2c���� *ChangeEventCommand+����   �� RelativeSource  �� ! �� AncestorType
! Window���� " ��.���  � �� �� " ��.R��� $ Button_Border��$ 7��
������ ���� 
color1��$ #292a2c��._��� $��60��$��15��$��Center=�$��Center=�$��3,-2,0,0q� :� $ Border.MouseEnter��.[��� .���� .���� $ Color�$ color1�� #292a2c #414b4d$ 0:0:0.2D�:� $ Border.MouseLeave��.[��� .���� .���� $ Color�$ color1�� #414b4d #292a2c$ 0:0:0.3D�P�  � ��$
 True��. ��� $ Button_Border�� � ��
 ������� $ Button_Border�� � �� �#121a1d�� $ Button_Border�� � ��$ 2q�.���� $��Готово�����	#FFF0F0F0$��45��$��14(�$
��Bold)�