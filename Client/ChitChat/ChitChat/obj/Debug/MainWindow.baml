   M S B A M L   `   `   `  ����C  ?ChitChat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:ChitChatChitChat  5   	       ChitChat.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:ChitChat     5   	   -   5        $��myChitChatWindow��5   	     � Title$  
MainWindow��6!   $	��700��64   $
��1040��6A   .��5      � -   5        $��myGrid��5       � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5       $��* �6   �� 5!      $��* �6   �� 5"      $��* �6   .+�5$   
   �� -   5         ��Name$
 Logo��5$      $��6��6   $��2��63    J� RenderTransformOrigin$ 0.5,0.5&�6D   z�5%      V� 5&      .~�5'      �� �� 5(      �� 5)      T� 5*      5+      .+�5-      �� $
��Chit��6   $��NoWrap=�6$   ���	#FFC4CFD6$	��140(�6Q    J� Opacity$
 0.85Q�6`    �� Left$ 0��6o   
 �� Top$ 5��6   $��Stretch=�6�   $��Stretch=�6�    �� TextAlignment$
 Left=�6�   $
��Bold"�6�   $	��200��6�   $	��525��6�   �� 5.      $��Chat ��6   $��NoWrap=�6%   ���	#FFC4CFD6$	��140(�6R   $
 0.85Q�6a   $
 Left=�6p   $��Normal"�6�   $	 280��6�   $ 5��6�   $��Stretch=�6�   $	��525��6�   $	��200��6�   �� 5/      $!��Powered by Purdue Knowledge��6   $��NoWrap=�6;   
������$��30(�6i   $
 0.85Q�6w   $
 Left=�6�   $��Normal"�6�   $	 170��6�   $	 150��6�   	 �� Bottom$	 5��6�   $��Bottom=�6�   $	��425��6�   50      (� 51   
   $��0��6   $��2��6"   $��2��6/   $��Center=�6C   $��Center=�6`   .��52      �� -   5        $��
tbUsername��52      $��10q�6+   $��Username��67   ��53      �� 54      
 �� 
TargetType"
 ��6    �� Triggers 55      �� 56       �� Binding 6*   ��  �� ElementName$ txtUsername�� �� Path$ 	IsFocused� �� Value True6f   .a�57   "   ��  �� Property � �� �� Value$ Medium"�6?   58      5:      5<      5=      (� 5>   
   $��2��6   $��2��6"   $��2��6/   $��Center=�6C   $��Center=�6`    J� OpacityMask
 �   �.��5?      �� -   5        $��txtUsername��5?      $	��150��6)   .��65   ��5@      �� 5A      "
 ��6    5B      P� 5C       P� Property �@J�	IsFocused P� Value . . �5D   "   ��  � �� �	#FFC7FACC6?   5E      5G      .��5H   !    � 	Resources 5I      ��%^   '��       �� 5J      "
 ��6   .�5K      ��  �@��CornerRadius$ 4��69   5L      5M      .��6%   5N      5O      (� 5P   
   $��0��6   $��3��6"   $��2��6/   $��Center=�6C   $��Center=�6`   .��5Q      �� -   5        $��
tbPassword��5Q      $��10q�6*   $��Password��66   ��5R      �� 5S      "
 ��6    5T      �� 5U       6*   �� $ txtPassword��$ 	IsFocused� True6f   .a�5V   "   ��  � ��$ Medium"�6?   5W      5Y      5[      5\      (� 5]   
   $��2��6   $��3��6"   $��2��6/   .��5^      �� -   5        $��txtPassword��5^      $	��150��6)   .��65   ��5_      �� 5`      "
 ��6    5a      P� 5b       �@J�	IsFocused . . �5c   "   ��  � �� �	#FFC7FACC6?   5d      5f      .��5g   !    5h      ��%^   '��       �� 5i      "
 ��6   .�5j      ��  �@��CornerRadius$ 4��69   5k      5l      .��6%   5m      5n      (� 5o   
   $��2��6   $��4��6"   $��2��6/   $��5q�6C    (� Stretch$ Uniform=�6N   $��Center=�6`   $��Center=�6}   .��5p      �� -   5        $��btnLogin��5p   -   $��30��6   $	��200��6!   $��LOG IN��6=   $��Center=�6N   $��Center=�6k   ��5q      �� 5r      "
 ��6   .�5s      ��  �@��TextAlignment$ Center=�6D   �� 5t       � �� 5u      �� 5v   "    �� 
TargetType" ��62   .R�5w   &   ��  �� CornerRadius$ 4��6-   
������
���   �$��1q�6j   ._�5x   *   ��  ��Name$ contentPresenter��6;   #��z��6U   #��z��6�   #��z��6�   #��z��6�   #��z��6  5y   '   5z   #   5|       5}      P� 5~       �@J�IsMouseOver . . �5   "   ��  � ��$
 Bold"�6?   5�      5�      5�      5�      (� 5�   
   $��4��6   $��2��6"   $��2��6/   $��Center=�6C   $��Center=�6`   $ Uniform=�6{   $��10q�6�   .��5�      �� -	   5        $��lblUsernameLoginError��5�      
���  ��65   5�      (� 5�   
   $��4��6   $��3��6"   $��2��6/   $��Center=�6C   $��Center=�6`   $ Uniform=�6{   $��10q�6�   .��5�      �� -
   5        $��lblPasswordLoginError��5�      
���  ��65   5�      (� 5�   
   $��2��6   $��5��6"   $��2��6/   $��5q�6C   $ Uniform=�6N   $��Center=�6`   $��Center=�6}   .��5�      �� -   5        $��	btnSignUp��5�   -   $��30��6   $	��200��6!   $��Sign Up��6>   $��Center=�6P   $��Center=�6m   ��5�      �� 5�      "
 ��6   .�5�      ��  �@��TextAlignment$ Center=�6D   �� 5�       � �� 5�      �� 5�   "   " ��62   .R�5�   &   �� $ 4��6-   
������
���   �$��1q�6j   ._�5�   *   �� $ contentPresenter��6;   #��z��6U   #��z��6�   #��z��6�   #��z��6�   #��z��6  5�   '   5�   #   5�       5�      P� 5�       �@J�IsMouseOver . . �5�   "   ��  � ��$
 Bold"�6?   5�      5�      5�      5�      5�      5�      