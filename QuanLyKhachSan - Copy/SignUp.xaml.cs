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
using BUS;
using DTO;
namespace QuanLyKhachSan
{
    /// <summary>
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        BUS_TAIKHOAN tk = new BUS_TAIKHOAN();
        public SignUp()
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

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            if (Account.Text != null && Name.Text != null && Password.Password != null && Re_Password.Password != null)
            {
                if (Password.Password != Re_Password.Password)
                {
                    MessageBox.Show("Mật khẩu và nhập lại mật khẩu không giống nhau!");
                }
                else
                {
                    DTO_TAIKHOAN dTO_TAIKHOAN = new DTO_TAIKHOAN();
                    dTO_TAIKHOAN._MALOAITK = 2;
                    dTO_TAIKHOAN._TENCHUTAIKHOAN = Name.Text.ToString();
                    dTO_TAIKHOAN._TENDANGNHAP = Account.Text.ToString();
                    dTO_TAIKHOAN._MATKHAU = Password.Password.ToString();
                    tk.ThemTaiKhoan(dTO_TAIKHOAN);
                    Close();
                }
            }
            else MessageBox.Show("Hãy nhập đầy đủ thông tin!");
        }
    }
}