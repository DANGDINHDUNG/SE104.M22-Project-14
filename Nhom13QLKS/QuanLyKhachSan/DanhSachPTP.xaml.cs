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

namespace QuanLyKhachSan.MVVM.View
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class DanhSachPTP : Window
    {
        BUS_PHIEUTHUEPHONG ptp = new BUS_PHIEUTHUEPHONG();
        public DanhSachPTP()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
            {
                MaximizeButton_Image.Source = new BitmapImage(new Uri("/Images/DoubleQuadButton.png", UriKind.Relative));
                WindowState = WindowState.Maximized;

                MainBorder.CornerRadius = new CornerRadius(0);
                MainBorder.BorderThickness = new Thickness(0);
            }
            else
            {
                MaximizeButton_Image.Source = new BitmapImage(new Uri(@"/Images/QuadButton.png", UriKind.Relative));
                WindowState = WindowState.Normal;

                MainBorder.CornerRadius = new CornerRadius(20);
                MainBorder.BorderThickness = new Thickness(5);
            }
        }

        private void TitleBarThumb_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount != 2)
            {
                return;
            }

            if (WindowState == WindowState.Normal)
            {
                MaximizeButton_Image.Source = new BitmapImage(new Uri("/Images/DoubleQuadButton.png", UriKind.Relative));
                WindowState = WindowState.Maximized;

                MainBorder.CornerRadius = new CornerRadius(0);
                MainBorder.BorderThickness = new Thickness(0);
            }
            else
            {
                MaximizeButton_Image.Source = new BitmapImage(new Uri(@"/Images/QuadButton.png", UriKind.Relative));
                WindowState = WindowState.Normal;

                MainBorder.CornerRadius = new CornerRadius(20);
                MainBorder.BorderThickness = new Thickness(5);
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }

        }

        private void phieuThuePhongDtg_Load(object sender, RoutedEventArgs e)
        {
            phieuThuePhongDtg.DataContext = ptp.getDSPTPKemKhachHang();
        }

        private void phieuThuePhongDtg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView row = phieuThuePhongDtg.SelectedItem as DataRowView;
            maPTPTbl.Text = row[0].ToString();
            maPhongTbl.Text = row[1].ToString();
            ngayLapDpk.Text = row[2].ToString();
            soLuongTbl.Text = row[3].ToString();
            donGiaTbl.Text = row[4].ToString();
            tenKHTbl.Text = row[5].ToString();
            maKHTbl.Text = row[6].ToString();
        }

        private void xuatThongTinBtn_Click(object sender, RoutedEventArgs e)
        {
            if (maPTPTbl.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng chọn thông tin khách hàng muốn xuất!", "Thông báo");
            }
            else
            {
                this.Close();              
            }
        }

        private void thoatBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public string GetMaPTP()
        {
            return maPTPTbl.Text;
        }

        public string GetMaPhong()
        {
            return maPhongTbl.Text;
        }

        public string GetNgayLap()
        {
            return ngayLapDpk.Text;
        }

        public string GetSoLuong()
        {
            return soLuongTbl.Text;
        }

        public string GetDonGia()
        {
            return donGiaTbl.Text;
        }

        public string GetMaKH()
        {
            return maKHTbl.Text;
        }
    }
}