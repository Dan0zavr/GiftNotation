   M S B A M L   `   `   `  ���� G  CGiftNotation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:GiftNotation.ViewsGiftNotation.Views       GiftNotation.Views.Filters   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     2local clr-namespace:GiftNotation.Views     -   $	��220��$	��350��  � WindowStyle$
  None=� � Topmost$
 True�� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ Manual=� � Left$	 100��
 � Top$	 100�� � AllowsTransparency$
 True��
������ y��� *IsFiltersWindowVisible+ � 	Resources 2   ,GiftNotation.Views.BoolToVisibilityConverter   BoolToVisibilityConverter��%   &	          .���� ���#afb3b7 �� CornerRadius$ 20��$��3q�._�� .+��� $��ФИЛЬТРЫ��$��Center=�$	��Top=�$��0,5,0,0q�$��16(�$
��Bold"��� $	��150��$	��Top=�$��0,35,0,0q�.+��� $��0,0,0,0q�$	��300��$ 10��$��30�����#636b6b._�� $��0, 0, 10, 0q�$��Center=�	 � ColumnDefinitions	 �� $
��auto ��� $��* �.+��� $/��)Укажите месяц события ��
�������$��Center=�$��14(�
 �� Padding$
 5q�$��0���� $��1��$��
0, 0, 5, 0q�$��20������ *Month+ �� SelectedItem �� *SelectedMonth+�� $��0,20,0,0q�$	��300��$ 10��$��30�����#636b6b._�� $��0, 0, 10, 0q�	 �� $
��auto ��� $��* �.+��� $��Тип события ��
�������$��Center=�$��14(�$
 5q�$��0���� $��1��$��
0, 0, 5, 0q� �� DisplayMemberPath$ EventTypeName��$��20������ *
EventTypes+ �� *SelectedEventType+�� $��0,20,0,0q�$	��300��$ 10��$��30�����#636b6b._�� $��0, 0, 10, 0q�	 �� $
��auto ��� $��* �.+��� $*��$Категория контакта ��
�������$��Center=�$��14(�$
 5q�$��0���� $��1��$��
0, 0, 5, 0q�$ RelpTypeName��$��20������ *	RelpTypes+ �� *SelectedRelpType+�� $��25��$��Bottom=�.+��� -   $	��100��$��18��$��
-200,0,0,0q����#253336����  �� 
TargetType" ��.���  �� Property � �� �� Value ��  �� 
TargetType" ��.R���  ��Name$ Button_Border��$ 7��
������ ���� 
color1�� �� Color$ #253336��._��� $��65��$��15��$��Center=�$��Center=�$��3,-2,0,0q� �� Triggers :�  :� RoutedEvent$ Border.MouseEnter��.[��� .���� .����  �� TargetProperty$ Color� �� 
TargetName$ color1�� �� From #253336	 �� To #121a1d g� Duration$ 0:0:0.2D�:� $ Border.MouseLeave��.[��� .���� .���� $ Color�$ color1�� #121a1d #253336$ 0:0:0.3D�P�  P� Property � �� P� Value$
 True��. ���  �� 
TargetName$ Button_Border�� � �� �#414b4d�� $ Button_Border�� � ��$ 2q�.���� $��Отменить��$��65�����	#FFF0F0F0$��14(�$
��Bold)�$��15��$	��Top=��� $	��100��$��18��$��200,-22,0,0q����#253336���� *FilterCommand+���� " ��.���  � �� �� " ��.R��� $ Button_Border��$ 7��
������ ���� 
color1��$ #253336��._��� $��65��$��15��$��Center=�$��Center=�$��0,0,0,0q� :� $ Border.MouseEnter��.[��� .���� .���� $ Color�$ color1�� #253336 #121a1d$ 0:0:0.2D�:� $ Border.MouseLeave��.[��� .���� .���� $ Color�$ color1�� #121a1d #253336$ 0:0:0.3D�P�  � ��$
 True��. ��� $ Button_Border�� � �� �#414b4d�� $ Button_Border�� � ��$ 2q�.���� $��
Поиск��$��45�����	#FFF0F0F0$��14(�$
��Bold)�