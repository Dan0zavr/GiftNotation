   M S B A M L   `   `   `  ����G  CGiftNotation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:GiftNotation.ConvertersGiftNotation.Converters  5   	   !    GiftNotation.Views.AddGifts   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <
converters%clr-namespace:GiftNotation.Converters     5   	   -   5          � Title$  Подарок��5   	   $	��350��6   $	��500��6&    � WindowStyle$
 None=�5	   	    � AllowsTransparency$
 True��5
   	   
������  � 	Resources 5      9   3GiftNotation.Converters.StringToVisibilityConverter   StringToVisibilityConverter��%   &	          5   
   61   5      .��5      ��  �� CornerRadius$ 20��6   ���#afb3b7$��3q�65   ���#666562._�5   
   � .+�5      �� $��0��6   $��ДОБАВЛЕНИЕ��6%   $��18(�67   $��25��6E   $
��Bold"�6Q   $��Center=�6c   $	��Top=�6�   $��0,10,0,0q�6�   � 5      $��	0,40,0,40q�6    � RowDefinitions 5      �� 5      $��* �6$   �� 5      $��45 �6$   �� 5      $��45 �6$   �� 5      $��45 �6$   .+�5       �� .+�5!      �� $��0��6   $	��130��6*   $	��450��67   ���#cacac8$ 5��6X   ._�5"      � $��10,0,0,0q�6    $��Center=�62    � ColumnDefinitions 5#      �� 5$   "   $��* �63   �� 5%   "   $
��auto �63   .+�5'      �� $��0��6)   $��0��66    �� Orientation$ Vertical=�6F   .+�5(   "   ��  � Cursor$ Arrow��6)   $ 2��68   $��25��6I   ���#707976$��2q�6k   $��0��6   $��0��6�   $
��Left=�6�   $��0,0,0,0q�6�   ._�5*   &   �� .u�5+   *   � .+�5-   .   �� -   5        	 ��Name$	 TextVisibilityForNameGift��5-   6   $��12(�5.   *   $��2q�68   $	��250��6D   ���#dbd8d4��50   H   �� *
GiftName+�� 52   .   $0��*Наименование подарка...��68   
 J� Opacity$	
 0.5Q�54   ,   
�������$��Center=�6L    �� Padding$ 5q�6g    J� IsHitTestVisible$ False��55   ,   y�53   ,   �� *Text+ �� ElementName$ TextVisibilityForNameGift�� �� 	Converter# [  55   ,   57   +   5:   '   5<   #   �� 5>   "   $ 2��6)   $��25��6:   ���#707976$��2q�6\   $��2��6p   $��0��6}   $
��Left=�6�   $��0,5,0,0q�6�   ._�5?   &   �� .u�5@   *   � .+�5B   .   �� -   5        $!	 TextVisibilityForSsylkaGift��5B   6   $��12(�5C   *   $��2q�68   $	��250��6D   ���#dbd8d4��5D   d   �� *Url+�� 5F   .   $1��+Ссылка на маркетплейс...��68   $	
 0.5Q�5H   ,   
�������$��Center=�6L   $ 5q�6g   $ False��5I   ,   y�5G   ,   �� *Text+$! TextVisibilityForSsylkaGift��# [  5I   ,   5L   +   5O   '   5P   #   �� 5Q   "   $ 2��6)   $��55��6:   ���#707976$��2q�6\   $��2��6p   $��0��6}   $
��Left=�6�   $��0,5,0,0q�6�   ._�5R   &   �� .u�5S   *   � .+�5U   .   �� -   5        $"	 TextVisibilityForDescription��5U   6   $��12(�5V   6   $��2q�6D   $	��250��6P   ���#dbd8d4��5W   p   �� *Description+�� 5Y   .   $��Описание...��68   $	
 0.5Q�5[   8   
�������$ 5q�6X   $ False��5\   8   $	��Top=�6Q   y�5Z   8   �� *Text+$" TextVisibilityForDescription��# [  5\   Q   5_   +   5b   '   5c   #   5d      �� 5f      $��1��6)   $��0��69   $ Vertical=�6F   .+�5g   "   �� 
�������$	��160��6<   $��90��6H   $��2q�6T   $ 8��6h   ���#c5c2c2$��0,0,5,0q�5h       J� 	AllowDrop$
 True��6/   $��Right=�6@   ._�5i   &   �� ��6-   �� *OpenFileDialogForPicture+.��5k   *   �� $��Stretch=�5l   ,   $��Stretch=�5m   ,   $
��auto��5n   ,   $��50��5o   ,   ��5k   0   �� *	GiftPic+5o   ,   ��5q   *   �� 5r   .    �� 
TargetType" ��64   .�5s   2   ��  �� Property � �� �� Value 5t   6   �� 5u   :    �� 
TargetType" ��6J   .R�5v   >   ��  ��Name$ Button_Border��6E   $ 7��6\   
������ ��5w   B   �� 5x   F   
color1�� �� Color$ Transparent��6f   ._�5z   B   �� $��Center=�6S   $��Center=�6p   5{   ?    �� Triggers 5}   >   :� 5~   B    :� RoutedEvent$ Border.MouseEnter��6O   .[�5   F   �� .��5�   J   �� .��5�   N   ��  �� TargetProperty$ Color�6]    �� 
TargetName$ color1��6    �� From #292a2c5�   =   	 �� To #414b4d6L    g� Duration$ 0:0:0.2D�6Y   5�   K   5�   G   5�   C   :� 5�   B   $ Border.MouseLeave��6O   .[�5�   F   �� .��5�   J   �� .��5�   N   �� $ Color�6]   $ color1��6    #414b4d5�   =    #292a2c6L   $ 0:0:0.3D�6Y   5�   K   5�   G   5�   C   P� 5�   B    P� Property � �� P� Value$
 True��6_   . �5�   F   ��  �� 
TargetName$ Button_Border��6M    � ��
 ���� 6~   �� 5�   F   $ Button_Border��6M    � ��
 ���� 6   �� 5�   F   $ Button_Border��6M    � ��$ 2q�6�   5�   C   5�   ;   5�   3   5�   /   5�   '   5�   #   �� 5�   "   $��30��6)   $	��160��65   $��1��6A   ���#cacac8$ 5��6c   $
��Left=�6t   ._�5�   &   � $��10,0,0,0q�6+   $��Center=�6=   $
��Left=�6X    5�   *   �� 5�   .   $
��auto �6?   �� 5�   .   $��* �6?   .+�5�   *   �� $��	Цена:��64   $��14(�6A   $��Center=�6O   $��0��6j   �� 5�   *   $��12(�62   $��2q�6@   ���#cacac8$��Center=�6a   $��1��6|   $	��100��6�   $��5,0,0,0q�6�   ��6�   �� *Price+5�   '   5�   #   5�      5�      5�      5�      �� 5�      $��30��6   $��1��6%   $	��450��62   ���#cacac8$ 5��6S   ._�5�      � $��10,0,0,0q�6   $��Center=�6-    5�      �� 5�      $
��Auto �6/   �� 5�      $��* �6/   .+�5�      �� $��	Люди:��6$   $��14(�61   $��Center=�6?   $��0��6Z   �� 5�      $��12(�6#   $��2q�61   $	��390��6=   ���#cacac8$��Center=�6^   $��1��6y   $��0,0,0,0q�6�     �� DisplayMemberPath$  ContactName��5�      ! �� 
IsEditable$! False��5�      ��5�   �   �� *
Contacts+" �� SelectedItem" 5�      �� *SelectedContact+5�      5�      5�      �� 5�      $��30��6   $��2��6%   $	��450��62   ���#cacac8$ 5��6S   ._�5�      � $��10,0,0,0q�6   $��Center=�6-    5�      �� 5�      $
��Auto �6/   �� 5�      $��* �6/   .+�5�      �� $��Событие:��6$   $��14(�64   $��Center=�6B   $��0��6]   �� 5�      $	��360��6#   $��1��6/   ���#cacac8$  	EventName��5�      $! False��5�      ��5�   T   �� *Events+" 5�      �� *SelectedEvent+5�      5�      5�      �� 5�      $��30��6   $	��450��6%   $��4��61   ���#cacac8$ 5��6S   ._�5�      � $��10,0,0,0q�6   $��Center=�6-    5�      �� 5�      $
��Auto �6/   �� 5�      $��* �6/   .+�5�      �� $��Статус��6$   $��14(�62   $��Center=�6@   $��0��6[   �� 5�      $	��380��6#   $��1��6/   ���#cacac8$  
StatusName��5�      $! False��5�      ��5�   T   �� *
Statuses+" 5�      �� *SelectedStatus+5�      5�      5�      5�      �� 5�      $��2��6   $ 
Horizontal=�6&   $��Bottom=�6?   .+�5�      �� -   5        ���#2c2b2a$	��100��5�   .   $��20��6:   $��	10,0,0,10q�6F   ��5�      �� 5�      " ��6    .�5�      ��  � �� 5�   "   �� 5�   &   " ��66   .R�5�   *   �� $ Button_Border��61   $ 7��6H   
������ ��5�   .   �� 5�   2   
color1��$ #292a2c��6R   ._�5�   .   �� $��65��6?   $��15��6J   $��Center=�6V   $��Center=�6s   $��3,-2,0,0q�6�   5�   +    5�   *   :� 5�   .   $ Border.MouseEnter��6;   .[�5�   2   �� .��5�   6   �� .��5�   :   �� $ Color�6I   $ color1��6k    #292a2c5�   I    #414b4d6X   $ 0:0:0.2D�6e   5�   7   5�   3   5�   /   :� 5  .   $ Border.MouseLeave��6;   .[�5  2   �� .��5  6   �� .��5  :   �� $ Color�6I   $ color1��6k    #414b4d5  I    #292a2c6X   $ 0:0:0.3D�6e   5  7   5  3   5  /   P� 5
  .    � ��$
 True��6K   . �5  2   �� $ Button_Border��69    � ��
 �����6j   �� 5  2   $ Button_Border��69    � �� �#121a1d6k   �� 5  2   $ Button_Border��69    � ��$ 2q�6o   5  /   5  '   5     5     .��5     �� $��Отменить��6    $��65��60   $��14(�6;   $
��Bold)�6I   ���#e2ddd96[   5     �� 5!     ���#2c2b2a$��20��6.   $	��100��6:   $��
275,0,0,10q�6F   ���#e2ddd9��6o   �� *AddGiftCommand+��6�   �� # �� RelativeSource# �� $ �� AncestorType
$ Window��5$     �� 5%     " ��6    .�5&     ��  � �� 5'  "   �� 5(  &   " ��66   .R�5)  *   �� $ Button_Border��61   $ 7��6H   
������ ��5*  .   �� 5+  2   
color1��$ #292a2c��6R   ._�5.  .   �� $��60��6?   $��15��6J   $��Center=�6V   $��Center=�6s   $��3,-2,0,0q�6�   50  +    54  *   :� 55  .   $ Border.MouseEnter��6;   .[�56  2   �� .��57  6   �� .��58  :   �� $ Color�6I   $ color1��6k    #292a2c59  )    #414b4d68   $ 0:0:0.2D�6E   5:  7   5;  3   5<  /   :� 5>  .   $ Border.MouseLeave��6;   .[�5?  2   �� .��5@  6   �� .��5A  :   �� $ Color�6I   $ color1��6k    #414b4d5B  )    #292a2c68   $ 0:0:0.3D�6E   5C  7   5D  3   5E  /   P� 5G  .    � ��$
 True��6K   . �5H  2   �� $ Button_Border��69    � ��
 �����6j   �� 5I  2   $ Button_Border��69    � �� �#121a1d6k   �� 5J  2   $ Button_Border��69    � ��$ 2q�6o   5K  /   5S  '   5U     5V     .��5Z     �� $��Center=�6    $��Готово��6=   $��14(�6K   $
��Bold)�6Y   ���#e2ddd96k   5[     5]     5_     5`     5a     