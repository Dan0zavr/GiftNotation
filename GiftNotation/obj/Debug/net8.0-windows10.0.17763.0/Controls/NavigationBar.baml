   M S B A M L   `   `   `  ����G  CGiftNotation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:GiftNotation.ControlsGiftNotation.Controls  5      M+clr-namespace:GiftNotation.State.NavigatorsGiftNotation.State.Navigators  5      )    #GiftNotation.Controls.NavigationBar   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:GiftNotation.Controls     5      B
navigation+clr-namespace:GiftNotation.State.Navigators     5      .��5"      ��   �� CornerRadius$  	20,20,0,0��6   ���#2c2b2a$��35��6;   $	��Top=�6G   ._�5#   
   �� $	��Top=�6   $	��700��6-   $��0,0,0,0q�69    �� Orientation$ 
Horizontal=�6J   $��0��6c   $��2��6s   $��Stretch=�6�   $��35��6�   .+�5%      �� -   5        $��25��5%       � Cursor$
 Hand��6    $��23��6/   ���#B6b7ba$��10,0,5,0q�6P   ��5'      �� 5(       �� 
TargetType" ��6   .�5)      ��  �� Property � �� �� Value 5*      �� 5+   "    �� 
TargetType" ��62   .R�5,   &   ��  ��Name$ Button_Border��6-   $  5��6D   
������ ��5-   *   �� 5.   .   
color1�� �� Color$ #B6b7ba��6N   ._�51   *   �� $��15��6;   $��15��6F   $��Center=�6R   $��Center=�6o   $��3,-2,0,0q�6�   53   '   	 �� Triggers	 57   &   :� 58   *   
 :� RoutedEvent$
 Border.MouseEnter��67   .[�59   .   �� .��5:   2   �� .��5;   6   ��  �� TargetProperty$ Color�6E    �� 
TargetName$ color1��6g    �� From #B6b7ba5<   E   	 �� To Gray6T    g� Duration$ 0:0:0.2D�6^   5=   3   5>   /   5?   +   :� 5A   *   $
 Border.MouseLeave��67   .[�5B   .   �� .��5C   2   �� .��5D   6   �� $ Color�6E   $ color1��6g    Gray5E   E    #B6b7ba6Q   $ 0:0:0.3D�6^   5F   3   5G   /   5H   +   P� 5J   *    P� Property � �� P� Value$
 True��6G   . �5K   .   ��  �� 
TargetName$ Button_Border��65    � ��
 �����6f   �� 5L   .   $ Button_Border��65    � �� �#121a1d6g   �� 5M   .   $ Button_Border��65    � ��$ 2q�6k   5N   +   5V   #   5X      5Y      .��5]      �� $��X��6   $��18(�6%   $��Heavy"�63   5_      �� 5a      -   5        $��25��5a      $
 Hand��6    $��23��6/   ���#B6b7ba$��2,0,15,0q�6P   ��5c      �� 5d      " ��6   .�5e      ��  � �� 5f      �� 5g   "   " ��62   .R�5h   &   �� $ Button_Border��6-   $  5��6D   
������ ��5i   *   �� 5j   .   
color1��$ #B6b7ba��6N   ._�5m   *   �� $��25��6;   $��25��6F   $��Center=�6R   $��Center=�6o   $��0,-2,0,0q�6�   5o   '   	 5s   &   :� 5t   *   $
 Border.MouseEnter��67   .[�5u   .   �� .��5v   2   �� .��5w   6   �� $ Color�6E   $ color1��6g    #B6b7ba5x   9    Gray6H   $ 0:0:0.2D�6R   5y   3   5z   /   5{   +   :� 5}   *   $
 Border.MouseLeave��67   .[�5~   .   �� .��5   2   �� .��5�   6   �� $ Color�6E   $ color1��6g    Gray5�   9    #B6b7ba6E   $ 0:0:0.3D�6R   5�   3   5�   /   5�   +   P� 5�   *    � ��$
 True��6G   . �5�   .   �� $ Button_Border��65    � ��
 �����6f   �� 5�   .   $ Button_Border��65    � �� �#121a1d6g   �� 5�   .   $ Button_Border��65    � ��$ 2q�6k   5�   +   5�   #   5�      5�      .��5�      �� $��-��6   $��30(�6%    �� TextAlignment$ Center=�63   $��Heavy"�6J   $��0,-6,0,0q�6]   $��36��6o   $	��Top=�6{   5�      �� 5�      $��5,0,20,0q�6   $
 Hand��6'   ���#B6b7ba$	��130��6K   $��Center=�6W   $��23��6t   ,   &GiftNotation.State.Navigators.ViewType   Calendar#��Z 6�   ��6�   �� *UpdateCurrentVMCommand+��5�      �� 5�      " ��6   .�5�      ��  � �� 5�      �� 5�   "   " ��62   .R�5�   &   �� $ Button_Border��6-   $  5��6D   
������ ��5�   *   �� 5�   .   
color1��$ #B6b7ba��6N   ._�5�   *   �� $��75��6;   $��15��6F   $��Center=�6R   $��Center=�6o   5�   '   	 5�   &   :� 5�   *   $
 Border.MouseEnter��67   .[�5�   .   �� .��5�   2   �� .��5�   6   �� $ Color�6E   $ color1��6g    #B6b7ba5�   E    Gray6T   $ 0:0:0.2D�6^   5�   3   5�   /   5�   +   :� 5�   *   $
 Border.MouseLeave��67   .[�5�   .   �� .��5�   2   �� .��5�   6   �� $ Color�6E   $ color1��6g    Gray5�   E    #B6b7ba6Q   $ 0:0:0.3D�6^   5�   3   5�   /   5�   +   P� 5�   *    � ��$
 True��6G   . �5�   .   �� $ Button_Border��65    � ��
 �����6f   �� 5�   .   $ Button_Border��65    � �� �#121a1d6g   �� 5�   .   $ Button_Border��65    � ��$ 2q�6k   5�   +   5�   #   5�      5�      .��5�      �� $��Medium"�6   $��КАЛЕНДАРЬ��60   $
��Left=�6A   $��75��6\   5�      �� 5�      $��5,0,20,0q�6   $
 Hand��6'   ���#B6b7ba$	��130��6K   $��Center=�6W   $��23��6t      Events#��Z 6�   ��6�   �� *UpdateCurrentVMCommand+��5�      �� 5�      " ��6   .�5�      ��  � �� 5�      �� 5�   "   " ��62   .R�5�   &   �� $ Button_Border��6-   $  5��6D   
������ ��5�   *   �� 5�   .   
color1��$ #B6b7ba��6N   ._�5�   *   �� $��75��6;   $��15��6F   $��Center=�6R   $��Center=�6o   5�   '   	 5�   &   :� 5�   *   $
 Border.MouseEnter��67   .[�5�   .   �� .��5�   2   �� .��5�   6   �� $ Color�6E   $ color1��6g    #B6b7ba5�   9    Gray6H   $ 0:0:0.2D�6R   5�   3   5�   /   5�   +   :� 5�   *   $
 Border.MouseLeave��67   .[�5�   .   �� .��5�   2   �� .��5�   6   �� $ Color�6E   $ color1��6g    Gray5�   9    #B6b7ba6E   $ 0:0:0.3D�6R   5�   3   5�   /   5�   +   P� 5�   *    � ��$
 True��6G   . �5�   .   �� $ Button_Border��65    � ��
 �����6f   �� 5�   .   $ Button_Border��65    � �� �#121a1d6g   �� 5�   .   $ Button_Border��65    � ��$ 2q�6k   5�   +   5�   #   5     5     .��5     �� $��Medium"�6   $��СОБЫТИЯ��60   $��Center=�6?   5     �� 5	     $��3,0,20,0q�6   $��23��6'   $
 Hand��63   ���#B6b7ba$	��130��5
  *      Gifts#��Z 6a   ��66   �� *UpdateCurrentVMCommand+��5     �� 5     " ��6   .�5     ��  � �� 5     �� 5  "   " ��62   .R�5  &   �� $ Button_Border��6-   $  5��6D   
������ ��5  *   �� 5  .   
color1��$ #B6b7ba��6N   ._�5  *   �� $��60��6;   $��15��6F   $��Center=�6R   $��Center=�6o   5  '   	 5  &   :� 5  *   $
 Border.MouseEnter��67   .[�5  .   �� .��5  2   �� .��5  6   �� $ Color�6E   $ color1��6g    #B6b7ba5  E    Gray6T   $ 0:0:0.2D�6^   5   3   5!  /   5"  +   :� 5$  *   $
 Border.MouseLeave��67   .[�5%  .   �� .��5&  2   �� .��5'  6   �� $ Color�6E   $ color1��6g    Gray5(  E    #B6b7ba6Q   $ 0:0:0.3D�6^   5)  3   5*  /   5+  +   P� 5-  *    � ��$
 True��6G   . �5.  .   �� $ Button_Border��65    � ��
 �����6f   �� 5/  .   $ Button_Border��65    � �� �#121a1d6g   �� 50  .   $ Button_Border��65    � ��$ 2q�6k   51  +   57  #   59     5:     .��5=     �� $��Medium"�6   $��ПОДАРОК��60   5>     �� 5@     -   5        $��	peoplebtn��5@     $��3,0,28,0q�5A     $	��130��6#   $��23��6/   $
 Hand��6;      Contacts#��Z 5B     ���#B6b7ba��5A  I   �� *UpdateCurrentVMCommand+��5D     �� 5E     " ��6   .�5F     ��  � �� 5G     �� 5H  "   " ��62   .R�5I  &   �� $��Button_Border��6-   $  5��6B   ��5J  *   �� 5K  .   xz��$ #B6b7ba��6J   ._�5N  *   �� $��45��6;   $��15��6F   $��Center=�6R   $��Center=�6o   5O  '   	 5R  &   :� 5U  *   $
 Border.MouseEnter��67   .[�5V  .   �� .��5W  2   �� .��5X  6   �� $ Color�6E   $ xz��5Y  E    #B6b7ba5Z  E    Gray6T   $ 0:0:0.2D�6^   5\  3   5]  /   5^  +   :� 5_  *   $
 Border.MouseLeave��67   .[�5`  .   �� .��5a  2   �� .��5b  6   �� $ Color�6E   $ xz��5c  E    Gray5d  E    #B6b7ba6Q   $ 0:0:0.3D�6^   5e  3   5f  /   5g  +   P� 5i  *    � ��$
 True��6G   . �5j  .   �� $ Button_Border��65    � ��
 �����6f   �� 5k  .   $ Button_Border��65    � �� �#121a1d6g   �� 5l  .   $ Button_Border��65    � ��$ 2q�6k   5m  +   5p  #   5r     5s     .��5w     �� $��Medium"�6   $��ЛЮДИ��60   5x     5z     5{     5     