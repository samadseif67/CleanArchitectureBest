   M S B A M L   `   `   `  ����I  EWpfOnelineShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:WpfOnelineShopWpfOnelineShop  5   	       WpfOnelineShop.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:WpfOnelineShop     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��auto �6   6.   �� 5      $��* �6   6+   .+�5   
   �� $��0��6   $	��250��6!   
������$��2q�6A   $��2,2,2,2q�6U   
�������$��Center=�6y   ._�5      �� .+�5      �� -   5        $��BtnHome��5   h   $��40��6   $��10,20q�6%   
���   �
�������$��18(�6Z   .��6�   Home6�   �� 5      -   5        $��	BtnPerson��5   h   $��40��6   $��10,20q�6%   
���   �
�������$��18(�6Z   .��6�   Person6�   �� 5      -   5        $��
BtnProduct��5   h   $��40��6   $��10,20q�6%   
���   �
�������$��18(�6Z   .��6�   	Product6�   �� 5      $	��100��6   $��10,20q�6%   $��Images/Capture20.PNG��64   5      5      �� 5   
   -   5        $��	HomePanel��5   �   $��1��6   
����  �$��2q�65   $��2,2,2,2q�6I   
�������$��Stretch=�6m   ._�5      �� $��Stretch=�6   .+�5      �� $��Heavy"�6   $��Center=�6+   $��30q�6H   .��6T   hello6[   �� 5      $��Images/car1.jpg��6   $��Stretch=�61   $��Stretch=�6O   $��10q�6m   5      5      �� 5   
   -   5        $��PersonPanel��5   �   $��1��6   $y�	Collapsed=�6!   
����  �$��2q�6K   $��2,2,2,2q�6_   
�������$��Stretch=�6�   ._�5       �� $��Stretch=�6   .+�5!      &   System.Windows.Controls.DataGrid  -   5        $��
PersonGrid��5!         CanUserAddRows .     CanUserResizeColumns .    CanUserResizeRows . $��Stretch=�6y      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6�      MinColumnWidth$	 100Q�6�   6�   � 5"      $��Stretch=�6   .+�5#      �� .��6   Details Info:6+   �� 5$      -   5        $��DetailsInfoPerson��5$      $	��---��65   6E   5%      ]� 5&      $��Center=�6   .+�5'      �� -   5        $��BtnAddPerson��5'   H   $	��100��6   $��60��6)   
��� � �.��6x   Add6}   �� 5(      -	   5        $��BtnEditPerson��5(   I   $	��100��6   $��60��6)   
��� ���.��6{   Edit6�   �� 5)      -
   5        $��BtnDeletePerson��5)   F   $	��100��6   $��60��6)   
���  ��.��6|   Delete6�   5*      5+      5.      �� 5/   
   -   5        $��ProductPanel��5/   �   $��1��6   $y�	Collapsed=�6!   
����  �$��2q�6K   $��2,2,2,2q�6_   
�������$��Stretch=�6�   ._�50      �� .��6   	product6   51      53      54      