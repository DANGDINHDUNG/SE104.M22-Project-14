using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using BUS;
using Microsoft.Win32;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;

namespace QuanLyKhachSan.MVVM.View
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class HoaDon : Window
    {
        
        public HoaDon()
        {
            InitializeComponent();
        }

        public string maHD;
        public string tenPhong;
        public string maPhong;
        public string maLP;
        public string soNguoi;
        public string donGia;
        public string tongTien;
        public string ngayLap;
        public string ngayThue;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.IsEnabled = false;
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(print, "invoice");
                }
            }
            finally
            {
                this.IsEnabled = true;
                this.Close();
            }
        }

        private void Loaded(object sender, RoutedEventArgs e)
        {
            maHDTbl.Text = maHD;
            tenPhongTbl.Text = tenPhong;
            maPhongTbl.Text = maPhong;
            maLPTbl.Text = maLP;
            donGiaTbl.Text = donGia;
            ngayLapTbl.Text = ngayLap;
            ngayThueTbl.Text = ngayThue;
            tongTienTbl.Text = tongTien;
            soLuongTbl.Text = soNguoi;
        }
    }
}