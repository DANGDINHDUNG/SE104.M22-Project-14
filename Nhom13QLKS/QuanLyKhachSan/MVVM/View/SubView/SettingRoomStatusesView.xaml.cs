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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DTO;
using BUS;
using System.Data;

namespace QuanLyKhachSan.MVVM.View.SubView
{
    /// <summary>
    /// Interaction logic for SettingRoomStatusesView.xaml
    /// </summary>
    public partial class SettingRoomStatusesView : UserControl
    {
        public BUS_PHONG busPhong = new BUS_PHONG();
        public BUS_LOAIPHONG busLoaiPhong = new BUS_LOAIPHONG();

        public SettingRoomStatusesView()
        {
            InitializeComponent();
            DataGridLoad();
        }

        private void themBtn_capNhatBtn_Click(object sender, RoutedEventArgs e)
        {
            string roomTypeCode = busLoaiPhong.TimKiemTheoTenLoaiPhong(loaiPhongTxb.Text);
            DTO_PHONG inputPhong = new DTO_PHONG();
            inputPhong._MALP = roomTypeCode;
            inputPhong._TENPHONG = tenPhongTxb.Text;
            inputPhong._TRANGTHAI = trangThaiTxb.Text;

            if (CheckExists())
            {
                busPhong.SuaPhong(inputPhong, int.Parse(maPhongTxb.Text));
            }
            else
            {
                busPhong.ThemPhong(inputPhong);
            }
            DataGridLoad();
        }

        private void lamMoiBtn_Click(object sender, RoutedEventArgs e)
        {
            ClearTextBoxes();
            DataGridLoad();
        }

        private void xoaBtn_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Bạn muốn xóa không?", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Information);
            if (result == MessageBoxResult.No)
                return;
            if (maPhongTxb.Text == string.Empty) return;
            busPhong.XoaPhong(int.Parse(maPhongTxb.Text));
            DataGridLoad();
        }

        private void danhSachTrangThaiPhongDtg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (danhSachTrangThaiPhongDtg.SelectedItems.Count == 0) return;
            DataRowView row = danhSachTrangThaiPhongDtg.SelectedItem as DataRowView;
            if (row == null)
            {
                ClearTextBoxes();
                return;
            }
            maPhongTxb.Text = row[0].ToString();
            tenPhongTxb.Text = row[1].ToString();
            loaiPhongTxb.Text = row[2].ToString();
            donGiaTxb.Text = row[3].ToString();
            trangThaiTxb.Text = row[4].ToString();
        }

        public void DataGridLoad()
        {
            danhSachTrangThaiPhongDtg.DataContext = busPhong.getDSPhongKemTrangThai();
        }

        public void ClearTextBoxes()
        {
            maPhongTxb.Text = tenPhongTxb.Text = loaiPhongTxb.Text = donGiaTxb.Text = trangThaiTxb.Text = string.Empty;
        }

        private bool CheckExists()
        {
            for (int i = 0; i < danhSachTrangThaiPhongDtg.Items.Count; i++)
            {
                DataRowView dataRowView = danhSachTrangThaiPhongDtg.Items[i] as DataRowView;
                if (dataRowView[1].ToString() == tenPhongTxb.Text || dataRowView[0].ToString() == maPhongTxb.Text)
                {
                    return true;
                }

            }
            return false;
        }
    }
}
