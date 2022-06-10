using System;
using System.Collections.Generic;
using System.Data;
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
namespace QuanLyKhachSan.MVVM.View
{
    /// <summary>
    /// Interaction logic for CustomersView.xaml
    /// </summary>
    public partial class CustomersView : UserControl
    {
        BUS_KHACHHANG kh = new BUS_KHACHHANG();
        public CustomersView()
        {
            InitializeComponent();
        }

        private void khDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (khDataGrid.SelectedItem != null)
            {
                DataRowView row = khDataGrid.SelectedItem as DataRowView;
                numTb.Text = row[0].ToString();
                numTypeTb.Text = row[1].ToString();
                nameTb.Text = row[2].ToString();
                cmndTb.Text = row[3].ToString();
                phoneTb.Text = row[4].ToString();
                sexTb.Text = row[5].ToString();
                ageTb.Text = row[6].ToString();
            }
        }
        public void Load()
        {
            khDataGrid.DataContext = kh.getKhachHang();
        }
        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            if(numTb.Text!=null)
            {
                kh.XoaKhachHang(numTb.Text.ToString());
            }
        }
        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            int x= khDataGrid.Items.Count;
            for(int i=0;i<khDataGrid.Items.Count;i++)
            {
                DataRowView row = khDataGrid.Items[i] as DataRowView;
                if (numTb.Text==row[0].ToString())
                {
                    x = i;
                    break;
                }
            }
            DTO_KHACHHANG dTO_KHACHHANG = new DTO_KHACHHANG();
            dTO_KHACHHANG.MAKH = Convert.ToInt32(numTb.Text);
            dTO_KHACHHANG.MALK = Convert.ToInt32(numTypeTb.Text);
            dTO_KHACHHANG.HOTEN = nameTb.Text;
            dTO_KHACHHANG.CMND = cmndTb.Text;
            dTO_KHACHHANG.GIOITINH = sexTb.Text;
            dTO_KHACHHANG.TUOI = Convert.ToInt32(ageTb.Text);
            dTO_KHACHHANG.SDT = phoneTb.Text;
            if (x == khDataGrid.Items.Count)
            {
                kh.SuaKhachHang(dTO_KHACHHANG);
            }
            else kh.ThemKhachHang(dTO_KHACHHANG);
        }
    }
}