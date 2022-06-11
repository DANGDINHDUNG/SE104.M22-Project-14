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
    /// Interaction logic for SettingRoomsView.xaml
    /// </summary>
    public partial class SettingRoomsView : UserControl
    {
        //public bool existsRoomCode = false;
        public BUS_PHONG busPhong = new BUS_PHONG();
        public BUS_LOAIPHONG busLoaiPhong = new BUS_LOAIPHONG();

        public SettingRoomsView()
        {
            InitializeComponent();
            DataGridLoad();
            //RoomValuesLLoad();
        }

        private void themBtn_capNhatBtn_Click(object sender, RoutedEventArgs e)
        {
            string roomTypeCode = busLoaiPhong.TimKiemTheoTenLoaiPhong(loaiPhongCbx.Text);
            DTO_PHONG inputPhong = new DTO_PHONG();
            inputPhong._MALP = roomTypeCode;
            inputPhong._TENPHONG = tenPhongTxb.Text;
            inputPhong._GHICHU = ghiChuTxb.Text;
            inputPhong._TRANGTHAI = "Trống";

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
            ClearTextBoxes();
            danhSachPhongDtg.SelectedItems.Clear();
        }

        private void danhSachPhongDtg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (danhSachPhongDtg.SelectedItems.Count == 0) return;
            DataRowView row = danhSachPhongDtg.SelectedItem as DataRowView;
            if (row == null)
            {
                ClearTextBoxes();
                return;
            }
            maPhongTxb.Text = row[0].ToString();
            tenPhongTxb.Text = row[1].ToString();
            loaiPhongCbx.Text = row[2].ToString();
            donGiaTxb.Text = row[3].ToString();
            ghiChuTxb.Text = row[4].ToString();
        }

        public void DataGridLoad()
        {
            danhSachPhongDtg.DataContext = busPhong.getDSPhong();
        }

        /*public void RoomValuesLLoad()
        {
            List<string> dsTenLoaiPhong = busLoaiPhong.TongHopLoaiPhong();

            for (int i = 0; i < dsTenLoaiPhong.Count; i++)
            {
                loaiPhongCbx.Items.Add(dsTenLoaiPhong[i]);
            }

            donGiaTxb.Text = busLoaiPhong.LoadGiaTheoLoaiPhong(loaiPhongCbx.Text);
        
        }*/

        public void ClearTextBoxes()
        {
            maPhongTxb.Text = loaiPhongCbx.Text = tenPhongTxb.Text = donGiaTxb.Text = ghiChuTxb.Text = string.Empty;
        }

        private bool CheckExists()
        {
            for (int i = 0; i < danhSachPhongDtg.Items.Count; i++)
            {
                DataRowView dataRowView = danhSachPhongDtg.Items[i] as DataRowView;
                if (dataRowView[2].ToString() == tenPhongTxb.Text || dataRowView[0].ToString() == maPhongTxb.Text)
                {
                    return true; 
                }    
                
            }
            return false;
        }

        private void loaiPhongCbx_Load(object sender, RoutedEventArgs e)
        {
            foreach (var tenLoaiPhong in busLoaiPhong.TongHopLoaiPhong())
            {
                loaiPhongCbx.Items.Add(tenLoaiPhong);
            }
        }

        private void loaiPhongCbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(loaiPhongCbx.Text == string.Empty)
            {
                donGiaTxb.Text = string.Empty;
            }
            else
            {
                donGiaTxb.Text = busLoaiPhong.LoadGiaTheoLoaiPhong(loaiPhongCbx.SelectedItem.ToString());
            }
        }

        private void thaotacExcelBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
