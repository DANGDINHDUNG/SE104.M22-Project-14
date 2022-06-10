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
    public partial class ForgotPasswordScreen : Window
    {
        BUS_TAIKHOAN tk = new BUS_TAIKHOAN();
        public ForgotPasswordScreen()
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

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            if (Account.Text != null && Name.Text != null && New_Password.Password != null && Re_Password.Password != null)
            {
                DTO_TAIKHOAN dTO_TAIKHOAN = new DTO_TAIKHOAN();
                dTO_TAIKHOAN._TENCHUTAIKHOAN = Name.Text.ToString();
                dTO_TAIKHOAN._TENDANGNHAP = Account.Text.ToString();
                if (tk.KiemTraTonTai(dTO_TAIKHOAN))
                {
                    if (New_Password.Password != Re_Password.Password)
                    {
                        MessageBox.Show("Mật khẩu và nhập lại mật khẩu không giống nhau!");
                    }
                    else
                    {

                        dTO_TAIKHOAN._MATKHAU = New_Password.Password.ToString();
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
