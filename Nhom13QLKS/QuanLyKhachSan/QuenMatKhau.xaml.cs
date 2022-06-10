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
using DTO;
using BUS;
namespace QuanLyKhachSan
{
    /// <summary>
    /// Interaction logic for ForgotPasswordScreen.xaml
    /// </summary>
    public partial class QuenMatKhau : Window
    {
        BUS_TAIKHOAN tk = new BUS_TAIKHOAN();
        public QuenMatKhau()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }

        }

        private void XacNhanBtn_Click(object sender, RoutedEventArgs e)
        {
            if (tenChuTKTbx.Text == null || taiKhoanTbx.Text != null && matKhauPwb.Password != null && nhapLaiMKPwb.Password != null)
            {
                DTO_TAIKHOAN dTO_TAIKHOAN = new DTO_TAIKHOAN();
                dTO_TAIKHOAN._TENDANGNHAP = taiKhoanTbx.Text.ToString();
                dTO_TAIKHOAN._TENCHUTAIKHOAN = tenChuTKTbx.Text.ToString();
                if (tk.KiemTraTonTai(dTO_TAIKHOAN))
                {
                    if (matKhauPwb.Password != nhapLaiMKPwb.Password)
                    {
                        MessageBox.Show("Mật khẩu và nhập lại mật khẩu không giống nhau!");
                    }
                    else
                    {

                        dTO_TAIKHOAN._MATKHAU = matKhauPwb.Password.ToString();
                        tk.SuaTaiKhoan(dTO_TAIKHOAN);
                        Close();
                    }
                }
                else
                {
                    MessageBox.Show("Tài khoản của bạn không có trong dữ liệu!");
                }
            }
            else MessageBox.Show("Hãy nhập đầy đủ thông tin!");
        }
    }
}
