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
using BUS;
using DTO;

namespace QuanLyKhachSan
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LogInScreen : Window
    {
        BUS_TAIKHOAN tk = new BUS_TAIKHOAN();
        public LogInScreen()
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

        private void DangNhapBtn_Click(object sender, RoutedEventArgs e)
        {

            DTO_TAIKHOAN dTO_TaiKhoan = new DTO_TAIKHOAN();
            dTO_TaiKhoan._TENDANGNHAP = taiKhoanTbx.Text.ToString();
            dTO_TaiKhoan._MATKHAU = matKhauPwb.Password.ToString();
            if (tk.KiemTraTaiKhoan(dTO_TaiKhoan) == true)
            {
                TrangChu dashboard = new(dTO_TaiKhoan);
                if (WindowState == WindowState.Maximized)
                {
                    dashboard.MaximizeButton_Image.Source = new BitmapImage(new Uri(@"/Images/DoubleQuadButton.png", UriKind.Relative));
                    dashboard.WindowState = WindowState.Maximized;

                    dashboard.MainBorder.CornerRadius = new CornerRadius(0);
                    dashboard.MainBorder.BorderThickness = new Thickness(0);
                }

                dashboard.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Sai tên hoặc mật khẩu", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void QuenMKBtn_Click(object sender, RoutedEventArgs e)
        {
            QuenMatKhau forgotpassword_window = new QuenMatKhau();
            forgotpassword_window.Owner = this;
            forgotpassword_window.ShowDialog();
        }
    }
}