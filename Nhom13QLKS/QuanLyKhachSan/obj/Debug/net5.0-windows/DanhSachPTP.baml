   M S B A M L   `   `   `  ����>  :GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:QuanLyKhachSanQuanLyKhachSan  5   	   *    $QuanLyKhachSan.MVVM.View.DanhSachPTP   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:QuanLyKhachSan     5   	     � Title$  LoginScreen��5   	   $	��680��6   $
��1024��6*    � AllowsTransparency$
 True��5	   	   
������  � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   .��5      �� -   5         ��Name$ 
MainBorder��5      ���#EEF0F5 �� CornerRadius$ 20��5      $��5q�5      $��
0,0,10,127q�6!    J� Effect 5   
   3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$
 Gray��6   	   
BlurRadius$	 6Q�5      
   	Direction$	
 -90Q�5         RenderingBias$ Quality=�5         ShadowDepth$ 1Q�5      ._�5   
   � $��	0,0,25,33q�6    � RowDefinitions 5      �� 5      $��60 �6    �� 5      .+�5!      � -   5        
������ .+�5%      �� $	��Top=�6   $��Right=�5&       �� Orientation$ 
Horizontal=�5'      $��0,0,0,0q�5(      .+�5*      �� -   5           WindowButtonTheme#��[  5*      .��5,      �� $��30��6    $��/Images/MinusButton.png��6,   5-      �� 5/      -   5        #��[  5/      .��51      �� -   5         ��Name$ MaximizeButton_Image��51       $��26��6>   $��/Images/QuadButton.png��6J   52      �� 54      -   5        #��[  54      .��56      �� $��30��6    $��/Images/XButton.png��6,   57      59      5;      &   System.Windows.Controls.DataGrid  5<      -   5          Name$ phieuThuePhongDtg��5<      $��1��5=      $
��Left=�5>   `   $	��510��6{   $��
34,0,0,108q�6�      
IsReadOnly$
 True��6�   ��6   ��  �� Path$ DefaultView�6�   �� 5?      $��Center=�6   $��30(�5@      $��
20,10,0,10q�5A      $��Phiếu thuê phòng��5B      $
��Bold"�5C      ���#424F6B5D      � 5E      $��579,6,15,128q�6   $��1��6)    � ColumnDefinitions 5F      �� 5G      $	��63* �6'   �� 5H      $	��61* �6'    5J      �� 5K      �� 5L      �� 5M      �� 5N      �� 5O      �� 5P      �� 5Q      �� 5R      �� 5S      .+�5V      �� $��Mã phiếu thuê phòng��6   $��18(�67   $��	0,0,12,43q�6E   $��2��6X   �� 5W      $��1��6   $��
Mã phòng��6)   $��18(�69   $��	0,0,12,43q�6G   $��2��6Z   �� 5X      $��2��6   $��Ngày lập��6)   $��18(�69   $��	0,0,12,43q�6G   $��2��6Z   �� 5Y      $��3��6   $��Số lượng��6)   $��18(�69   $��	0,0,12,42q�6G   $��2��6Z   �� 5Z      $��4��6   $��
Đơn giá��6)   $��18(�68   $��0,0,12,0q�6F   �� 5[      $��4��6   $��Tên khách hàng��6)   $��18(�6?   $��	0,42,12,0q�6M   $��2��6`   �� 5]      -   5         ��Name$ maPTPTbl��5]      $��1��6/   $��0,0,0,43q�6?   $��2��6Q   $��18(�6b   �� 5^      -	   5        $ 
maPhongTbl��5^      $��1��60   $��1��6@   $��0,0,0,43q�6M   $��2��6_   $��18(�6p   (  "System.Windows.Controls.DatePicker  5_      -
   5          Name$ 
ngayLapDpk��5_      $��1��61   $��1��6A   $y�Visible=�6N   ${�False��6c   $��0,35,0,8q�6u   $��2��6�   $��18(�6�   �� 5`      -   5        $ 
soLuongTbl��5`      $��1��60   $��3��6@   $��0,0,0,42q�6M   $��2��6_   $��18(�6p   ]� 5b      $��1��6   $��4��6,   $
��True��6:    � 	Resources 5c       �� 
TargetType  WindowButtonTheme2 �� BasedOn �� Property �� Value��%�   '��       7  �� 5d      " ��6    8   .�5f      ��  � ��$	 2,0q�67   �� 5g       � ��$ 26��67   �� 5h       � ��$ 26��66   �� 5i       � ��$ 8(�69   �� 5j       � ��$
 Bold"�6;   5k      5l      .+�5m      �� -   5        $ 	donGiaTbl��5m       $	��188��63   $��18(�6?   5n      �� 5o      -   5        $ tenKHTbl��5o      $��5��6.   $��0,6,0,35q�6;   $��2��6M   $��1��6^   $��18(�6n   �� 5p      $��6��6   $��Mã khách hàng��6)   $��18(�6>   $��0,4,12,3q�6L   �� 5q      -   5        $ maKHTbl��5q      $��6��6-   $��0,3,0,3q�6:   $��1��6K   $��18(�6[   5r      �� 5s      -   5         ��Name$ xuatThongTinBtn��5s      #��[ 6.   $��Xuất thông tin��6Z   $
��Left=�6s   $��575,371,0,0q�6�   $��1��6�   $	��Top=�6�   $��37��6�   $	��160��6�   6�   �� 5t      -   5        $ thoatBtn��5t      #��[ 6'   $��Thoát��6S   $
��Left=�6c   $��790,372,0,0q�6~   $��1��6�   $	��Top=�6�   $��37��6�   $	��160��6�   6�   5u      5v      5w      