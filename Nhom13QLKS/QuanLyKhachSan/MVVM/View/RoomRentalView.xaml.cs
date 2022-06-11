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
using System.Text.RegularExpressions;

namespace QuanLyKhachSan.MVVM.View
{
    /// <summary>
    /// Interaction logic for RoomRentalView.xaml
    /// </summary>
    public partial class RoomRentalView : UserControl
    {
        BUS_PHIEUTHUEPHONG busPTP = new BUS_PHIEUTHUEPHONG();
        BUS_CHITIETPTP busCtPTP = new BUS_CHITIETPTP();
        BUS_KHACHHANG kh = new BUS_KHACHHANG();
        BUS_LOAIKHACH lk = new BUS_LOAIKHACH();
        BUS_PHONG busPHONG = new BUS_PHONG();
        public string formCode;

        public RoomRentalView()
        {
            InitializeComponent();
            DateTime now = DateTime.Now;
            ngayLapTxb.Text = now.ToString("dd/MM/yyyy");
            DataGridLoad();
            LoadKh();
        }

        private void maPhongTxb_TextChanged(object sender, TextChangedEventArgs e)
        {
            BUS_PHONG busPhong = new BUS_PHONG();

            if (maPhongTxb.Text == string.Empty)
            {
                donGiaTxb.Text = string.Empty;
                return;
            }

            if (busPhong.TimKiemPhong(int.Parse(maPhongTxb.Text)))
            {
                donGiaTxb.Text = busPhong.GetDonGiaTheoMaPhong(maPhongTxb.Text);
            }
            else
            {
                donGiaTxb.Text = string.Empty;
                return;
            }
        }

        private void kiemTraNhapLieuSo_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }

        private void lapPhieuBtn_Click(object sender, RoutedEventArgs e)
        {
            if (danhSachPTPDtg.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một phiếu thuê phòng", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            DataRowView row = danhSachPTPDtg.SelectedItem as DataRowView;
            if (row == null)
            {
                ClearTextBoxes();
                return;
            }
            
            ChiTietPTP chiTietPTP = new ChiTietPTP();
            chiTietPTP.maPTP = formCode;
            chiTietPTP.ShowDialog();
            formCode = string.Empty;
        }

        private void themSuaPTPBtn_Click(object sender, RoutedEventArgs e)
        {
            DTO_PHIEUTHUEPHONG inputPTP = new DTO_PHIEUTHUEPHONG();
            BUS_THAMSO busThamSo = new BUS_THAMSO();

            try
            {
                if (maPhongTxb.Text == string.Empty || soKhachTxb.Text == string.Empty)
                {
                    return;
                }
                else
                {
                    if (int.Parse(soKhachTxb.Text) > busThamSo.SoLuongToiDa())
                    {
                        MessageBox.Show("Số lượng khách hàng vượt quá quy định, vui lòng kiểm tra lại.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    inputPTP._MAPHONG = int.Parse(maPhongTxb.Text);
                    inputPTP._NGAYLAP = DateTime.ParseExact(ngayLapTxb.Text, "dd/MM/yyyy", null);
                    inputPTP._SOLUONG = int.Parse(soKhachTxb.Text);
                    inputPTP._DONGIA = decimal.Parse(donGiaTxb.Text);
                    inputPTP._TINHTRANG = "Chưa thanh toán";
                }

                if (busPHONG.CheckPhongDaThue(inputPTP._MAPHONG))
                {
                    MessageBox.Show("Phòng đã chọn đang được thuê, vui lòng kiểm tra lại.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (CheckExists())
                {
                    busPTP.SuaPhieuThuePhong(inputPTP);
                }
                else
                {
                    busPTP.ThemPhieuThuePhong(inputPTP);
                    busPHONG.SuaTrangThaiPhong("Đã thuê", inputPTP._MAPHONG.ToString());
                }
                DataGridLoad();
                formCode = string.Empty;
            }
            catch
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng ngày tháng (dd/MM/yyyy)", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            
        }

        private void xoaPTPBtn_Click(object sender, RoutedEventArgs e)
        {
            if (formCode == string.Empty) return;
            var result = MessageBox.Show("Bạn muốn xóa không?", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Information);
            if (result == MessageBoxResult.No)
                return;
            busPHONG.SuaTrangThaiPhong("Trống", formCode);
            busCtPTP.XoaChiTietPTP(formCode);

            busPTP.XoaPhieuThuePhong(formCode);
            busPHONG.SuaTrangThaiPhong("Trống", maPhongTxb.Text);
            ClearTextBoxes();
            DataGridLoad();
            formCode = string.Empty;
        }

        private void lamMoiDSPTPBtn_Click(object sender, RoutedEventArgs e)
        {
            formCode = string.Empty;
            ClearTextBoxes();
            DataGridLoad();
        }

        private void danhSachPTPDtg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (danhSachPTPDtg.SelectedItems.Count == 0) return;
            DataRowView row = danhSachPTPDtg.SelectedItem as DataRowView;
            if (row == null)
            {
                ClearTextBoxes();
                return;
            }
            formCode = row[0].ToString();
            maPhongTxb.Text = row[1].ToString();
            ngayLapTxb.Text = row[2].ToString();
            soKhachTxb.Text = row[3].ToString();
            donGiaTxb.Text = row[4].ToString();
        }

        private void themKHBtn_Click(object sender, RoutedEventArgs e)
        {
            DTO_KHACHHANG dTO_KHACHHANG = new DTO_KHACHHANG();
            dTO_KHACHHANG.MALK = lk.getMaLK(loaiKHCbx.Text.ToString());
            dTO_KHACHHANG.TENKH = tenKHTxb.Text;
            dTO_KHACHHANG.CMND = cmndTxb.Text;
            dTO_KHACHHANG.DIACHI = diaChiTxb.Text;
            kh.ThemKhachHang(dTO_KHACHHANG);
            LoadKh();
        }

        private void danhSachKHDtg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (danhSachKHDtg.SelectedItem != null)
            {
                DataRowView row = danhSachKHDtg.SelectedItem as DataRowView;
                loaiKHCbx.Text = row[5].ToString();
                tenKHTxb.Text = row[2].ToString();
                cmndTxb.Text = row[3].ToString();
                diaChiTxb.Text = row[4].ToString();
            }
        }

        private void capNhatKHBtn_Click(object sender, RoutedEventArgs e)
        {
            if (danhSachKHDtg.SelectedItem != null)
            {
                DataRowView row = danhSachKHDtg.SelectedItem as DataRowView;
                DTO_KHACHHANG dTO_KHACHHANG = new DTO_KHACHHANG();
                dTO_KHACHHANG.MAKH = Convert.ToInt32(row[0].ToString());
                dTO_KHACHHANG.MALK = lk.getMaLK(loaiKHCbx.Text.ToString());
                dTO_KHACHHANG.TENKH = tenKHTxb.Text;
                dTO_KHACHHANG.CMND = cmndTxb.Text;
                dTO_KHACHHANG.DIACHI = diaChiTxb.Text;
                kh.SuaKhachHang(dTO_KHACHHANG);
                LoadKh();
            }
        }

        private void xoaKHBtn_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Bạn muốn xóa không?", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Information);
            if (result == MessageBoxResult.No)
                return;
            
            try
            {
                if (danhSachKHDtg.SelectedItem != null)
                {
                    DataRowView row = danhSachKHDtg.SelectedItem as DataRowView;
                    kh.XoaKhachHang(Convert.ToInt32(row[0].ToString()));
                    LoadKh();

                }
            }
            catch
            {
                MessageBox.Show("Khách hàng đã được sử dụng trong phiếu thuê phòng. Không thể xóa!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
        }

        private void lamMoiDSKHBtn_Click(object sender, RoutedEventArgs e)
        {
            tenKHTxb.Text = cmndTxb.Text = diaChiTxb.Text = loaiKHCbx.Text = "";
            LoadKh();
        }

        public void DataGridLoad()
        {
            danhSachPTPDtg.DataContext = busPTP.getDSPTP();
        }

        public void LoadKh()
        {
            danhSachKHDtg.DataContext = kh.getLoaiKhachHang();
        }

        public void ClearTextBoxes()
        {
            maPhongTxb.Text = soKhachTxb.Text = donGiaTxb.Text = string.Empty;
        }

        private bool CheckExists()
        {
            for (int i = 0; i < danhSachPTPDtg.Items.Count; i++)
            {
                DataRowView dataRowView = danhSachPTPDtg.Items[i] as DataRowView;
                if (dataRowView[0].ToString() == formCode)
                {
                    return true;
                }

            }
            return false;
        }

        private void loaiKHCbx_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var loaiKhach in lk.NhungLoaiKhach())
            {
                loaiKHCbx.Items.Add(loaiKhach);
            }
        }

        private void cmndTxb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }
    }
}
