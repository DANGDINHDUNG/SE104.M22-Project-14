using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DTO;
using BUS;
using System.Text.RegularExpressions;

namespace QuanLyKhachSan.MVVM.View
{
    /// <summary>
    /// Interaction logic for CustomersView.xaml
    /// </summary>
    public partial class CustomersView : UserControl
    {
        BUS_KHACHHANG kh = new BUS_KHACHHANG();
        BUS_LOAIKHACH lk = new BUS_LOAIKHACH();
        public CustomersView()
        {
            InitializeComponent();
            Load();
        }

        private void KhDtg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (khDtg.SelectedItem != null)
            {
                DataRowView row = khDtg.SelectedItem as DataRowView;
                makhTbx.Text = row[0].ToString();
                hotenTbx.Text = row[2].ToString();
                cmndTbx.Text = row[3].ToString();
                diaChiTbx.Text = row[4].ToString();
                malkCbx.Text = row[1].ToString();
            }
        }
        public void Load()
        {
            khDtg.DataContext = kh.getKhachHang();
        }
        private void XoaBtn_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Bạn muốn xóa không?", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Information);
            if (result == MessageBoxResult.No)
                return;
            if (makhTbx.Text != null)
            {
                kh.XoaKhachHang(Convert.ToInt32(makhTbx.Text.ToString()));
            }
            Load();
        }
        private void SuaBtn_Click(object sender, RoutedEventArgs e)
        {
            int x = khDtg.Items.Count;
            DTO_KHACHHANG dTO_KHACHHANG = new DTO_KHACHHANG();
            if (makhTbx.Text != null)
                dTO_KHACHHANG.MAKH = Convert.ToInt32(makhTbx.Text);
            dTO_KHACHHANG.MALK = malkCbx.Text;
            dTO_KHACHHANG.TENKH = hotenTbx.Text;
            dTO_KHACHHANG.CMND = cmndTbx.Text;
            dTO_KHACHHANG.DIACHI = diaChiTbx.Text;
            for (int i = 0; i < khDtg.Items.Count - 1; i++)
            {
                DataRowView row = khDtg.Items[i] as DataRowView;
                if (makhTbx.Text == row[0].ToString())
                {
                    x = i;
                    kh.SuaKhachHang(dTO_KHACHHANG);
                    break;
                }
            }

            if (x == khDtg.Items.Count)
            {
                kh.ThemKhachHang(dTO_KHACHHANG);
            }
            Load();
        }

        private void TimKiemTbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            khDtg.DataContext = kh.TimKiemKhachHang(timKiemTbx.Text.ToString());
        }

        private void ThemBtn_Click(object sender, RoutedEventArgs e)
        {
            DTO_KHACHHANG dTO_KHACHHANG = new DTO_KHACHHANG();
            dTO_KHACHHANG.MALK = malkCbx.Text;
            dTO_KHACHHANG.TENKH = hotenTbx.Text;
            dTO_KHACHHANG.CMND = cmndTbx.Text;
            dTO_KHACHHANG.DIACHI = diaChiTbx.Text;
            kh.ThemKhachHang(dTO_KHACHHANG);
            Load();
        }

        private void malkCbx_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var malk in lk.NhungMaLoaiKhach())
            {
                malkCbx.Items.Add(malk);
            }
        }

        private void cmndTbx_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }
    }
}