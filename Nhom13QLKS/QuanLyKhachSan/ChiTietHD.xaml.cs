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
    public partial class ChiTietHD : Window
    {
        BUS_DICHVU dv = new BUS_DICHVU();
        BUS_HOADON hd = new BUS_HOADON();
        BUS_CHITIETHD cthd = new BUS_CHITIETHD();
        BUS_KHACHHANG kh = new BUS_KHACHHANG();
        BUS_THAMSO ts = new BUS_THAMSO();
        public ChiTietHD()
        {
            InitializeComponent();
        }

        decimal tien = 0;
        public string maptp;
        int rowCount = 0;
        int tylePhuThu;
        double hesoPhuThu;


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


        private void thoatBtn_Click(object sender, RoutedEventArgs e)
        {
            int mahd = int.Parse(maHDTbl.Text);
            int maptp = int.Parse(maPTPTbl.Text);
            cthd.XoaCHITIETHD(mahd, maptp);
            hd.XoaHOADON(mahd);
            tien = 0;
            this.Close();
        }

        private void chonBtn_Click(object sender, RoutedEventArgs e)
        {


            DataRowView row = dichVuDtg.SelectedItem as DataRowView;

            DTO_DICHVU dto_dv = new DTO_DICHVU(Convert.ToInt32(row[0].ToString()), row[1].ToString(), decimal.Parse(row[2].ToString()));
            int i = 0;
            int code = Convert.ToInt32(maPTPTbl.Text);
            int bill = Convert.ToInt32(maHDTbl.Text);
            int service = Convert.ToInt32(row[0].ToString());

            chonDichVuDtg.Items.Add(dto_dv);

            DTO_CHITIETHD dto_cthd = new DTO_CHITIETHD(i, code, bill, service, i);
            cthd.ThemCHITIETHD(dto_cthd);

            tien += Convert.ToDecimal(row[2].ToString());
            tongTienDVTbl.Text = tien.ToString("###,###,###");
        }

        private void huyBtn_Click(object sender, RoutedEventArgs e)
        {
            DataRowView row = chonDichVuDtg.SelectedItem as DataRowView;
            DTO_DICHVU dTO_DICHVU = chonDichVuDtg.SelectedItem as DTO_DICHVU;
            int code = Convert.ToInt32(maPTPTbl.Text);
            int service = Convert.ToInt32(dTO_DICHVU.MADV.ToString());

            cthd.XoaCHITIETHDTheoDV(service, code);

            chonDichVuDtg.Items.Remove(chonDichVuDtg.SelectedItem);

            tien -= Convert.ToDecimal(dTO_DICHVU.DONGIA.ToString());
            tongTienDVTbl.Text = tien.ToString("###,###,###");
        }


        private void MaPTPTbl_Load(object sender, RoutedEventArgs e)
        {
            maPTPTbl.Text = maptp;
        }

        private void MaHDTbl_Load(object sender, RoutedEventArgs e)
        {
            maHDTbl.Text = hd.GetMaHD(maPTPTbl.Text);
        }

        private void dichVuDtg_Load(object sender, RoutedEventArgs e)
        {
            dichVuDtg.DataContext = dv.getDichVu();
        }

        private void khachHangDtg_Load(object sender, RoutedEventArgs e)
        {
            khachHangDtg.DataContext = kh.getKhachHangTrongPTP(Convert.ToInt32(maptp));
        }

        private void hoanThanhBtn_Click(object sender, RoutedEventArgs e)
        {
            if (soLuongTbl.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng kiểm tra số lượng khách trước khi ấn hoàn thành", "Thông báo");
            }
            else
            {
                if (nuocNgoaiRbtn.IsChecked == true)
                {
                    hesoPhuThu = ts.HeSoPhuThu();
                }
                else
                {
                    hesoPhuThu = 1;
                }

                if (kiemTraSoLuongTbl.Text == string.Empty)
                {
                    tylePhuThu = 0;
                }
                else
                {
                    tylePhuThu = ts.TyLePhuThu();
                }

                this.Close();
            }
        }

        private void kiemTraBtn_Click(object sender, RoutedEventArgs e)
        {
            KiemTraSoLuongKhachToiDa();
            if (KiemTraSoLuongKhachToiDa() == true)
            {
                soLuongTbl.Text = Convert.ToString(rowCount);
                kiemTraSoLuongTbl.Text = "Số lượng khách đã vượt quá số lượng tối đa trong 1 phòng";
            }
            else
            {
                soLuongTbl.Text = Convert.ToString(rowCount);
            }

            KiemTraLoaiKhach();
            if (KiemTraLoaiKhach() == true)
            {
                nuocNgoaiRbtn.IsChecked = true;
            }
            else
            {
                noiDiaRbtn.IsChecked = true;
            }
            
        }

        public bool KiemTraSoLuongKhachToiDa()
        {
            rowCount = khachHangDtg.Items.Count;
            if (rowCount >= ts.SoLuongToiDa())
            {
                return true;
            }
            return false;
        }

        public bool KiemTraLoaiKhach()
        {
            for (int i = 0; i < khachHangDtg.Items.Count; i++)
            {
                DataRowView row = khachHangDtg.Items[i] as DataRowView;
                if (row[1].ToString() == "NN")
                {
                    return true;
                }
            }
            return false;
        }

        public double TyLePhuThu()
        {
            return tylePhuThu;
        }

        public double HeSoPhuThu()
        {
            return hesoPhuThu;
        }

        public decimal TienDichVu()
        {
            return tien;
        }

        public string MaHD()
        {
            return maHDTbl.Text;
        }

    }
}