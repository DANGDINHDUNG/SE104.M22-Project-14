   M S B A M L   `   `   `  ����>  :GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:QuanLyKhachSanQuanLyKhachSan  5   	   (    "QuanLyKhachSan.MVVM.View.ChiTietDT   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:QuanLyKhachSan     5   	     � Title$  LoginScreen��5   	   $	��680��6   $
��1024��6*    � AllowsTransparency$
 True��5	   	   
������  � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   .��5      �� -   5         ��Name$ 
MainBorder��5      ���#EEF0F5 �� CornerRadius$ 20��5      $��5q�5      $��0,0,243,244q�6!    J� Effect 5   
   3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$
 Gray��6   	   
BlurRadius$	 6Q�5      
   	Direction$	
 -90Q�5         RenderingBias$ Quality=�5         ShadowDepth$ 1Q�5      ._�5   
   � $��0,0,25,5q�6    � RowDefinitions 5      �� 5      $��60 �6    �� 5      .+�5!      � -   5        
������ .+�5%      �� $	��Top=�6   $��Right=�5&       �� Orientation$ 
Horizontal=�5'      $��0,0,0,0q�5(      .+�5*      �� -   5           WindowButtonTheme#��[  5*      .��5,      �� $��30��6    $��/Images/MinusButton.png��6,   5-      �� 5/      -   5        #��[  5/      .��51      �� -   5         ��Name$ MaximizeButton_Image��51       $��26��6>   $��/Images/QuadButton.png��6J   52      �� 54      -   5        #��[  54      .��56      �� $��30��6    $��/Images/XButton.png��6,   57      59      5;      &   System.Windows.Controls.DataGrid  5<      -   5          Name$ datagrid��5<      $��1��5=      $
��Left=�5>   N   $	��701��6i   $��	34,0,0,57q�6u      
IsReadOnly$
 True��6�   ��6   ��  �� Path$ DefaultView�6�   �� 5?      $��Center=�6   $��30(�5@      $��
20,10,0,10q�5A      $$��Chi tiết báo cáo doanh thu��5B      $
��Bold"�5C      ���#424F6B5D      �� 5E      -   5         ��Name$ 
hoanTatBtn��5E        WindowButtonTheme2#��[ 6)   $��Hoàn tất��6U   $
��Left=�6h   $��575,315,0,0q�6�   $��1��6�   $	��Top=�6�   $��37��6�   $	��160��6�   6�   �� 5F      -	   5        $ xuatExcelBtn��5F      #��[ 6+   $��Xuất Excel��6W   $
��Left=�6l   $��373,315,0,0q�6�   $��1��6�   $	��Top=�6�   $��37��6�   $	��160��6�   6�   5G      5H      5I      