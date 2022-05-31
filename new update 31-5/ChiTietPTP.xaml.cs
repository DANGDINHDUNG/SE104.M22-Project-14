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

        private void ChooseButton_Click(object sender, RoutedEventArgs e)
        {
            DataRowView row = guestDataGrid.SelectedItem as DataRowView;
            if (row == null)
                return;
            DTO_KHACHHANG dtoKhachHang = new DTO_KHACHHANG(Convert.ToInt32(row[0].ToString()), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString());
            ThemKhachThue(dtoKhachHang);
            chosenGuestsList.Add(dtoKhachHang);
        }



        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            DTO_KHACHHANG dtoKhachHang = (DTO_KHACHHANG)chosenGuestsDataGrid.SelectedItem;
            chosenGuestsList.Remove(dtoKhachHang);
            chosenGuestsDataGrid.Items.Remove(chosenGuestsDataGrid.SelectedItem);

            guestAmountTextBox.Text = chosenGuestsDataGrid.Items.Count.ToString();
        }

        private void CompleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (chosenGuestsDataGrid.Items.Count == 0)
            {
                MessageBox.Show("Khách thuê không thể bỏ trống, vui lòng kiểm tra lại.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (formDataGrid.SelectedItem == null)
            {
                MessageBox.Show("Phiếu thuê phòng không thể bỏ trống, vui lòng kiểm tra lại.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (chosenGuestsDataGrid.Items.Count > busThamSo.SoLuongToiDa() + 1)
            {
                MessageBox.Show("Số lượng khách đã quá quy định, vui lòng kiểm tra lại.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            DataRowView chosenFormRow = formDataGrid.SelectedItem as DataRowView;

            if (guestAmountTextBox.Text != chosenFormRow[3].ToString())
            {
                var result = MessageBox.Show("Số lượng khách đã chọn không khớp với số lượng khách ở phiếu thuê phòng, có chắc chắn muốn lập phiếu thuê phòng không?", "Lỗi", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.No)
                {
                    return;
                }
            }

            for (int i = 0; i < chosenGuestsDataGrid.Items.Count; i++)
            {
                busCTPTP.ThemChiTietPTP(chosenFormRow[0].ToString(), chosenGuestsList[i].MAKH.ToString());
            }

            MessageBox.Show("Phiếu thuê phòng được lập thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DatagridLoad()
        {
            guestDataGrid.DataContext = busKhachHang.getKhachHang();
            formDataGrid.DataContext = busPTP.getDSPTP();
        }

        private void formCodeTextBoxLoad(object sender, RoutedEventArgs e)
        {
            formCodeTextBox.Text = maPTP;
        }

        public void ThemKhachThue(DTO_KHACHHANG dtoKhachHang)
        {
            chosenGuestsDataGrid.Items.Add(dtoKhachHang);
            guestAmountTextBox.Text = chosenGuestsDataGrid.Items.Count.ToString();
        }
    }
}