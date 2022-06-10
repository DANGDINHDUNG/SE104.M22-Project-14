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
    /// Interaction logic for SettingRoomTypesView.xaml
    /// </summary>
    public partial class SettingRoomTypesView : UserControl
    {
        public BUS_LOAIPHONG busLoaiPhong = new BUS_LOAIPHONG();

        public SettingRoomTypesView()
        {
            InitializeComponent();
            DataGridLoad();
        }

        private void themBtn_capNhatBtn_Click(object sender, RoutedEventArgs e)
        {
            DTO_LOAIPHONG loaiPhong = new DTO_LOAIPHONG(maLoaiPhongTxb.Text, tenLoaiPhongTxb.Text, Decimal.Parse(donGiaTxb.Text));

            if (CheckExists())
            {
                busLoaiPhong.SuaLoaiPhong(loaiPhong);
            }
            else
            {
                busLoaiPhong.ThemLoaiPhong(loaiPhong);
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
            busLoaiPhong.XoaLoaiPhong(maLoaiPhongTxb.Text);
            DataGridLoad();
        }

        private void danhSachLoaiPhongDtg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (danhSachLoaiPhongDtg.SelectedItems.Count == 0) return;
            DataRowView row = danhSachLoaiPhongDtg.SelectedItem as DataRowView;
            if (row == null)
            {
                ClearTextBoxes();
                return;
            }
            maLoaiPhongTxb.Text = row[0].ToString();
            tenLoaiPhongTxb.Text = row[1].ToString();
            donGiaTxb.Text = row[2].ToString();
        }

        public void DataGridLoad()
        {
            danhSachLoaiPhongDtg.DataContext = busLoaiPhong.getDSLoaiPhong();
        }

        public void ClearTextBoxes()
        {
            maLoaiPhongTxb.Text = tenLoaiPhongTxb.Text = donGiaTxb.Text = string.Empty;
        }

        private bool CheckExists()
        {
            for (int i = 0; i < danhSachLoaiPhongDtg.Items.Count; i++)
            {
                DataRowView dataRowView = danhSachLoaiPhongDtg.Items[i] as DataRowView;
                if (dataRowView[1].ToString() == tenLoaiPhongTxb.Text || dataRowView[0].ToString() == maLoaiPhongTxb.Text)
                {
                    return true;
                }

            }
            return false;
        }
    }
}
