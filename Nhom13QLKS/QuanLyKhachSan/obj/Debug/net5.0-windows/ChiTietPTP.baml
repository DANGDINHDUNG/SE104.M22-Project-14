   M S B A M L   `   `   `  ����>  :GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:QuanLyKhachSanQuanLyKhachSan  5   	   )    #QuanLyKhachSan.MVVM.View.ChiTietPTP   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:QuanLyKhachSan     5   	     � Title$  LoginScreen��5   	   $	��635��6   $
��1024��6*    � AllowsTransparency$
 True��5	   	   
������  � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   .��5      �� -   5         ��Name$ 
MainBorder��5      ���#EEF0F5 �� CornerRadius$ 20��5      $��5q�5      $��0,0,0,10q�6!    J� Effect 5   
   3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$
 Gray��6   	   
BlurRadius$	 6Q�5      
   	Direction$	
 -90Q�5         RenderingBias$ Quality=�5         ShadowDepth$ 1Q�5      ._�5   
   � $��	-5,0,10,0q�6   $	��605��6"   $��Center=�6/    � RowDefinitions 5      �� 5      $��60 �6    �� 5      .+�5!      � -   5        
������ .+�5%      �� $	��Top=�6   $��Right=�5&       �� Orientation$ 
Horizontal=�5'      $��0,0,0,0q�5(      .+�5*      �� -   5           WindowButtonTheme#��[  5*      .��5,      �� $��30��6    $��/Images/MinusButton.png��6,   5-      �� 5/      -   5        #��[  5/      .��51      �� -   5         ��Name$ MaximizeButton_Image��51       $��26��6>   $��/Images/QuadButton.png��6J   52      �� 54      -   5        #��[  54      .��56      �� $��30��6    $��/Images/XButton.png��6,   57      59      5;      &   System.Windows.Controls.DataGrid  5<      -   5          Name$ khachHangDtg��5<      $��1��5=      $
��Left=�5>   @   $	��424��6[   $��58,47,0,306q�6g      
IsReadOnly$
 True��6|   ��6   ��  �� Path$ DefaultView�6|   �� 5?      $��Center=�6   $��30(�5@      $��	0,10,0,10q�5A      $,��&Thông tin Phiếu thuê phòng số: ��5B      $
��Bold"�5C      ���#424F6B5D        5E      -   5        $ khachDaChonDtg��5E      $
��Left=�5F   3   $	��375��6N   $��589,47,0,306q�6Z   $��1��6p   ��6   �� $
 User� �� SelectedItem 6}   �� $ SelectedUser� �� Mode$ TwoWay=�   Columns 5G      0  *System.Windows.Controls.DataGridTextColumn  5H      ,  &System.Windows.Controls.DataGridColumn   Header$
 MAKH��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *MAKH+  5I      $
 MALK��6)    67   �� *MALK+  5J      $ TENKH��6)    68   �� *TENKH+  5K      $
 CMND��6)    67   �� *CMND+  5L      $ DIACHI��6)    69   �� *DIACHI+5N      �� 5O      $
��Left=�6   $��	58,10,0,0q�63   $��1��6F   $��Chọn khách hàng��6S   $
��Wrap=�6j   $	��Top=�6~   $��18(�6�   �� 5P      -	   5         ��Name$ 	chonKHBtn��5P      $��Chọn��6(   $
��Left=�67   $��
504,78,0,0q�6R   $��1��6f   $	��Top=�6s   $��46��6�   $��14(�6�   $��66��6�     WindowButtonTheme2#��[ 6�   6�   �� 5Q      -
   5        $ huyKHBtn��5Q      $��Hủy��6'   $
��Left=�65   $��504,168,0,0q�6P   $��1��6e   $	��Top=�6r   $��43��6�   $��14(�6�   $��66��6�   #��[ 6�   6�   �� 5R      $
��Left=�6   $��
547,10,0,0q�63   $��1��6G   $��Khách hàng đã chọn��6T   $
��Wrap=�6n   $	��Top=�6�   $��18(�6�   �� 5S      -   5         ��Name$ guestAmountTextBox��5S      $
��Left=�64   $��	762,0,0,0q�6O   $��1��6b   $
��Wrap=�6o   $��Center=�6�   $��18(�6�   $	��136��6�   �� 5T      -   5        $ maPTPTbl��5T      $
��Left=�6*   $��
736,13,0,0q�6E   $
��Wrap=�6Y   $	��Top=�6m   $��28(�6�   $��76��6�   $
��Bold"�6�   ���#424F6B6�     5U      -   5        $ ptpDtg��5U      $��1��5V      $
��Left=�5W   5   $	��690��6P   $��58,309,0,15q�6\   $
 True��6q   ��6   �� *DefaultView+6q   �� 5X      $
��Left=�6   $��
58,255,0,0q�63   $��1��6G   $%��Thông tin phiếu thuê phòng��6T   $
��Wrap=�6v   $	��Top=�6�   $��18(�6�   �� 5Y      $
��Left=�6   $��	547,0,0,0q�63   $��1��6F   $'��!Kiểm tra số lượng khách: ��6S   $
��Wrap=�6t   $��Center=�6�   $��18(�6�   �� 5Z      -   5        $ soLuong��5Z      $
��Left=�6)   $��756,310,0,0q�6D   $��1��6Y   $
��Wrap=�6f   $	��Top=�6z   $��18(�6�   $��36��6�   $
��Bold"�6�   $��27��6�   �� 5[      -   5        $ kiemTraSoLuong��5[      $
��Left=�60   $��547,344,0,0q�6K   $��1��6`   $
��Wrap=�6m   $	��Top=�6�   $��14(�6�   $	��431��6�   $��Regular"�6�   $��27��6�   ���	#FFEA16166�   �� 5\      -   5        $ hoanThanhBtn��5\      $��Hoàn thành��6+   $
��Left=�6@   $��818,368,0,0q�6[   $��1��6p   $	��Top=�6}   $��32��6�   $��14(�6�   $	��146��6�   #��[ 6�   6�   �� 5]      -   5        $ huyBtn��5]      $��Hủy��6%   $
��Left=�63   $��818,418,0,0q�6N   $��1��6c   $	��Top=�6p   $��32��6�   $��14(�6�   $	��146��6�   #��[ 6�   6�   5^      5_      5`      