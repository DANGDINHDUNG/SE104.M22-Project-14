using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using BUS;
using DTO;

namespace QuanLyKhachSan.MVVM.View
{
    /// <summary>
    /// Interaction logic for PaymentView.xaml
    /// </summary>
    public partial class PaymentView : UserControl
    {
        BUS_PHONG phong = new BUS_PHONG();
        BUS_DICHVU dv = new BUS_DICHVU();
        BUS_HOADON hd = new BUS_HOADON();
        BUS_LOAIHINHTHANHTOAN loaihinhtt = new BUS_LOAIHINHTHANHTOAN();
        BUS_THAMSO ts = new BUS_THAMSO();
        BUS_CHITIETHD cthd = new BUS_CHITIETHD();
        BUS_BAOCAODOANHTHU baocaodt = new BUS_BAOCAODOANHTHU();
        BUS_CTBAOCAODOANHTHU ctbcdt = new BUS_CTBAOCAODOANHTHU();
        BUS_LOAIPHONG lp = new BUS_LOAIPHONG();
        BUS_PHIEUTHUEPHONG ptp = new BUS_PHIEUTHUEPHONG();
        public PaymentView()
        {
            InitializeComponent();

            thang = Convert.ToInt32(ngayLapDpk.SelectedDate.Value.Month);
            nam = Convert.ToInt32(ngayLapDpk.SelectedDate.Value.Year);
        }

        double tylePhuThu;
        double hesoPhuThu;
        decimal tienDichVu;
        int soNgayThue;
        int tienle = 0;

        int thang, nam;


        private void xuatPTPBtn_Click(object sender, RoutedEventArgs e)
        {
            DanhSachPTP pTP = new DanhSachPTP();
            pTP.ShowDialog();

            maPTPTbl.Text = pTP.GetMaPTP();
            maPhongTbl.Text = pTP.GetMaPhong();
            ngayThueDpk.Text = pTP.GetNgayLap();
            soLuongTbl.Text = pTP.GetSoLuong();
            donGiaTbl.Text = pTP.GetDonGia();
            maKHTbl.Text = pTP.GetMaKH();

            if (maPTPTbl.Text == string.Empty)
            {
                return;
            }
            else
            {
                TinhSONGAYTHUE();
            }

            phongThueDtg_Load(this, e);
        }

        private void phongThueDtg_Load(object sender, RoutedEventArgs e)
        {
            if (maPTPTbl.Text == string.Empty)
            {
                return;
            }
            else
            {
                phongThueDtg.DataContext = phong.getDSPhongTheoPTP(int.Parse(maPTPTbl.Text));
            }
        }

        private void lapHDBtn_Click(object sender, RoutedEventArgs e)
        {
            if (maPTPTbl.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng chọn thông tin phiếu thuê phòng trước khi lập hóa đơn", "Thông báo");
            }
            else
            {
                int i = 0;

                DTO_HOADON dto_hd = new DTO_HOADON(i, maKHTbl.Text, ngayLapDpk.DisplayDate, i);
                hd.ThemHOADON(dto_hd);

                if (baocaodt.KiemTraTonTaiBaoCao(thang, nam) == false)
                {
                    string tenBCDT = "Báo cáo tháng " + ngayLapDpk.SelectedDate.Value.Month.ToString();
                    DTO_BAOCAODOANHTHU dto_bcdt = new DTO_BAOCAODOANHTHU(1, tenBCDT, ngayLapDpk.DisplayDate, thang, nam);
                    baocaodt.ThemBAOCAODOANHTHU(dto_bcdt);
                }

                ChiTietHD tinhTienHD = new ChiTietHD();
                tinhTienHD.maptp = maPTPTbl.Text;
                tinhTienHD.ShowDialog();

                tylePhuThu = tinhTienHD.TyLePhuThu() / 100;
                hesoPhuThu = tinhTienHD.HeSoPhuThu();
                tienDichVu = tinhTienHD.TienDichVu();
                soNgayThue = int.Parse(soNgayTbl.Text);
                maHDTbl.Text = tinhTienHD.MaHD();

                double phuThu = 0;

                if (tienDichVu == 0)
                {
                    dichVuTbl.Text = "0";
                }
                else
                {
                    dichVuTbl.Text = tienDichVu.ToString("###,###");
                }
                decimal donGia = decimal.Parse(donGiaTbl.Text);

                //((Đơn giá* tỉ lệ)+đơn giá)*hệ số - đơn giá
                phuThu = (((double)donGia * tylePhuThu) + (double)donGia) * hesoPhuThu - (double)donGia;
                phuThuTbl.Text = phuThu.ToString("###,###");

                tongTienTbl.Text = (((double)donGia * hesoPhuThu + phuThu) * (double)soNgayThue + (double)tienDichVu).ToString("###,###");
                thanhTienTxb.Text = tongTienTbl.Text;
            }

            huyBtn.IsEnabled = true;
        }

        public void TinhSONGAYTHUE()
        {
            DateTime end = ngayLapDpk.SelectedDate.Value.Date;
            DateTime start = ngayThueDpk.SelectedDate.Value.Date;
            TimeSpan difference = end.Subtract(start);
            soNgayTbl.Text = difference.TotalDays.ToString();
        }

        private void hinhThucTTCbx_Load(object sender, RoutedEventArgs e)
        {
            foreach (var payment in loaihinhtt.NhungLoaiHinhThanhToan())
            {
                hinhThucTTCbx.Items.Add(payment);
            }
        }

        private void hinhThucTTCbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            double khuyenmai;
            double thanhtien;
            if (thanhTienTxb.Text == string.Empty)
            {
                return;
            }
            else
            {
                if (hinhThucTTCbx.Text == "Tiền mặt")
                {
                    khuyenmai = (double)ts.KhuyenMai() / 100;
                    thanhtien = double.Parse(tongTienTbl.Text) - double.Parse(tongTienTbl.Text) * khuyenmai;
                    if (ngayLeCkb.IsChecked == true)
                    {
                        thanhtien += (double)tienle;
                    }
                    thanhTienTxb.Text = thanhtien.ToString("###,###");
                }
                else
                {
                    thanhtien = double.Parse(tongTienTbl.Text);
                    if (ngayLeCkb.IsChecked == true)
                    {
                        thanhtien += (double)tienle;
                    }
                    thanhTienTxb.Text = thanhtien.ToString("###,###");
                }
            }
        }

        private void ngayLeCkb_Click(object sender, RoutedEventArgs e)
        {
            tienle = ts.TienLe();
            double thanhtien;
            if (thanhTienTxb.Text == string.Empty)
            {
                return;
            }
            else
            {
                if (ngayLeCkb.IsChecked == true)
                {
                    thanhtien = double.Parse(thanhTienTxb.Text) + (double)tienle;
                    thanhTienTxb.Text = thanhtien.ToString("###,###");
                }
                else
                {
                    thanhtien = double.Parse(thanhTienTxb.Text) - (double)tienle;
                    thanhTienTxb.Text = thanhtien.ToString("###,###");
                }
            }
        }

        private void khachTraTxb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }

        private void khachTraTxb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (thanhTienTxb.Text == string.Empty)
            {
                ngayLeCkb.IsEnabled = true;
                hinhThucTTCbx.IsEnabled = true;
            }
            else
            {
                if (khachTraTxb.Text == string.Empty)
                {
                    ngayLeCkb.IsEnabled = true;
                    hinhThucTTCbx.IsEnabled = true;
                    return;
                }
                else
                {
                    ngayLeCkb.IsEnabled = false;
                    hinhThucTTCbx.IsEnabled = false;
                    double tiendu = double.Parse(khachTraTxb.Text) - double.Parse(thanhTienTxb.Text);
                    tienThuaTxb.Text = tiendu.ToString("###,###");
                }
            }
        }

        private void luuHDBtn_Click(object sender, RoutedEventArgs e)
        {
            if (thanhTienTxb.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng tạo hóa đơn thanh toán trước khi xác nhận lưu hóa đơn", "Thông báo");
            }
            else
            {
                decimal thanhtien = decimal.Parse(thanhTienTxb.Text);
                int mahd = int.Parse(maHDTbl.Text);
                hd.SuaHOADON((int)thanhtien, mahd);

                string maBCDT = baocaodt.GetMaBCDT(thang, nam);

                DataRowView row = phongThueDtg.Items[0] as DataRowView;

                MessageBox.Show("Đã lưu hóa đơn thanh toán số " + maHDTbl.Text + " thành công!", "Thông báo");

                if (ctbcdt.KiemTraTonTaiCTBaoCao(maBCDT) == false)
                {
                    for (int i = 0; i < lp.TongHopMaLoaiPhong().Count; i++)
                    {
                        DTO_CTBAOCAODOANHTHU dto_ctbcdt = new DTO_CTBAOCAODOANHTHU(1, lp.TongHopMaLoaiPhong()[i], Convert.ToInt32(maBCDT), 0, 0);
                        ctbcdt.ThemCTBAOCAODOANHTHU(dto_ctbcdt);
                        double doanhthu = Convert.ToDouble(ctbcdt.GetDoanhThu(lp.TongHopMaLoaiPhong()[i], maBCDT)) + Convert.ToDouble(thanhTienTxb.Text);

                        if (lp.TongHopMaLoaiPhong()[i] == row[2].ToString())
                        {

                            ctbcdt.SuaCTBAOCAODOANHTHUDT((int)doanhthu, row[2].ToString(), maBCDT);

                            
                        }

                    }
                }
                else
                {
                    for (int i = 0; i < lp.TongHopMaLoaiPhong().Count; i++)
                    {
                        double doanhthu = Convert.ToDouble(ctbcdt.GetDoanhThu(lp.TongHopMaLoaiPhong()[i], maBCDT)) + Convert.ToDouble(thanhTienTxb.Text);

                        if (lp.TongHopMaLoaiPhong()[i] == row[2].ToString())
                        {

                            ctbcdt.SuaCTBAOCAODOANHTHUDT((int)doanhthu, row[2].ToString(), maBCDT);


                        }
                    }
                }

                for (int i = 0; i < lp.TongHopMaLoaiPhong().Count; i++)
                {
                    double doanhthu = Convert.ToDouble(ctbcdt.GetDoanhThu(lp.TongHopMaLoaiPhong()[i], maBCDT));

                    string tongdoanhthu = ctbcdt.GetTongDoanhThuTrongThang(maBCDT);

                    double tyle = (doanhthu / double.Parse(tongdoanhthu)) * 100;
                    ctbcdt.SuaCTBAOCAODOANHTHUTL(tyle, lp.TongHopMaLoaiPhong()[i], maBCDT);
                }

                phong.SuaTrangThaiPhong("Trống", maPhongTbl.Text);
                ptp.SuaTinhTrangPTP(maPTPTbl.Text);
                huyBtn.IsEnabled = true;
                LamMoiDuLieu();
                maPhongTbl.Text = maHDTbl.Text = string.Empty;
            }
        }

        private void huyBtn_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Bạn muốn xóa không?", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Information);
            if (result == MessageBoxResult.No)
                return;
            LamMoiDuLieu();

            int mahd = Convert.ToInt32(maHDTbl.Text);
            int maptp = Convert.ToInt32(maPTPTbl.Text);
            cthd.XoaCHITIETHD(mahd, maptp);
            hd.XoaHOADON(mahd);

            MessageBox.Show("Đã hủy hóa đơn thanh toán số " + maHDTbl.Text + " thành công!", "Thông báo");
            maHDTbl.Text = string.Empty;
            maPTPTbl.Text = string.Empty;

            huyBtn.IsEnabled = false;

        }

        private void LamMoiDuLieu()
        {
            maPhongTbl.Text = maKHTbl.Text = donGiaTbl.Text = soLuongTbl.Text = string.Empty;
            ngayThueDpk.Text = dichVuTbl.Text = phuThuTbl.Text = tongTienTbl.Text = string.Empty;
            thanhTienTxb.Text = khachTraTxb.Text = tienThuaTxb.Text = soNgayTbl.Text = string.Empty;
        }
    }
}
