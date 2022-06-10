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
using BUS;
using DTO;

namespace QuanLyKhachSan.MVVM.View.SubView
{
    /// <summary>
    /// Interaction logic for SettingRulesView.xaml
    /// </summary>
    public partial class SettingRulesView : UserControl
    {
        BUS_THAMSO ts = new BUS_THAMSO();
        public SettingRulesView()
        {
            InitializeComponent();
        }

        private void Load(object sender, RoutedEventArgs e)
        {
            soNguoiTxb.Text = ts.SoLuongToiDa().ToString();
            tyLePhuThuTxb.Text = ts.TyLePhuThu().ToString();
            heSoPhuThuTxb.Text = ts.HeSoPhuThu().ToString();
            phuThuNgayLeTxb.Text = ts.TienLe().ToString("###,###");
            khuyenMaiTxb.Text = ts.KhuyenMai().ToString();
        }

        private void capNhatBtn_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Bạn muốn cập nhật không?", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Information);
            if (result == MessageBoxResult.No)
                return;
            ts.SuaTHAMSO(Convert.ToDouble(soNguoiTxb.Text), "TS1");
            ts.SuaTHAMSO(Convert.ToDouble(tyLePhuThuTxb.Text), "TS3");
            ts.SuaTHAMSO(Convert.ToDouble(heSoPhuThuTxb.Text), "TS2");
            ts.SuaTHAMSO(Convert.ToDouble(phuThuNgayLeTxb.Text), "TS4");
            ts.SuaTHAMSO(Convert.ToDouble(khuyenMaiTxb.Text), "TS5");

            MessageBox.Show("Thay đổi thành công quy định khách sạn", "Thông báo");
        }
    }
}
