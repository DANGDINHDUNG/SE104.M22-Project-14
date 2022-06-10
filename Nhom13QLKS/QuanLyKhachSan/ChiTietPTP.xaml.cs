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
using DTO;

namespace QuanLyKhachSan.MVVM.View
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class ChiTietPTP : Window
    {
        BUS_KHACHHANG busKhachHang = new BUS_KHACHHANG();
        BUS_PHIEUTHUEPHONG busPTP = new BUS_PHIEUTHUEPHONG();
        BUS_CHITIETPTP busCTPTP = new BUS_CHITIETPTP();
        BUS_THAMSO busThamSo = new BUS_THAMSO();

        public string maPTP;
        public List<DTO_KHACHHANG> chosenGuestsList = new List<DTO_KHACHHANG>();

        public ChiTietPTP()
        {
            InitializeComponent();
            DatagridLoad();
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

        private void chonKHBtn_Click(object sender, RoutedEventArgs e)
        {
            DataRowView row = khachHangDtg.SelectedItem as DataRowView;
            if (row == null)
                return;
            DTO_KHACHHANG dtoKhachHang = new DTO_KHACHHANG(Convert.ToInt32(row[0].ToString()), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString());
            ThemKhachThue(dtoKhachHang);
            chosenGuestsList.Add(dtoKhachHang);
        }

        private void huyKHBtn_Click(object sender, RoutedEventArgs e)
        {
            DTO_KHACHHANG dtoKhachHang = (DTO_KHACHHANG)khachDaChonDtg.SelectedItem;
            chosenGuestsList.Remove(dtoKhachHang);
            khachDaChonDtg.Items.Remove(khachDaChonDtg.SelectedItem);

            guestAmountTextBox.Text = khachDaChonDtg.Items.Count.ToString();
        }

        private void hoanThanhBtn_Click(object sender, RoutedEventArgs e)
        {
            if (khachDaChonDtg.Items.Count == 0)
            {
                MessageBox.Show("Khách thuê không thể bỏ trống, vui lòng kiểm tra lại.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (ptpDtg.SelectedItem == null)
            {
                MessageBox.Show("Phiếu thuê phòng không thể bỏ trống, vui lòng kiểm tra lại.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (khachDaChonDtg.Items.Count > busThamSo.SoLuongToiDa() + 1)
            {
                MessageBox.Show("Số lượng khách đã quá quy định, vui lòng kiểm tra lại.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            DataRowView chosenFormRow = ptpDtg.SelectedItem as DataRowView;

            if (guestAmountTextBox.Text != chosenFormRow[3].ToString())
            {
                var result = MessageBox.Show("Số lượng khách đã chọn không khớp với số lượng khách ở phiếu thuê phòng, có chắc chắn muốn lập phiếu thuê phòng không?", "Lỗi", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.No)
                {
                    return;
                }
            }

            for (int i = 0; i < khachDaChonDtg.Items.Count; i++)
            {
                busCTPTP.ThemChiTietPTP(chosenFormRow[0].ToString(), chosenGuestsList[i].MAKH.ToString());
            }

            MessageBox.Show("Phiếu thuê phòng được lập thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }

        private void huyBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DatagridLoad()
        {
            khachHangDtg.DataContext = busKhachHang.getKhachHang();
            ptpDtg.DataContext = busPTP.getDSPTP();
        }

        private void maPTPTbl_Load(object sender, RoutedEventArgs e)
        {
            maPTPTbl.Text = maPTP;
        }

        public void ThemKhachThue(DTO_KHACHHANG dtoKhachHang)
        {
            khachDaChonDtg.Items.Add(dtoKhachHang);
            guestAmountTextBox.Text = khachDaChonDtg.Items.Count.ToString();
        }
    }
}