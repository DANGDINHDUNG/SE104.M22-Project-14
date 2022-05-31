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

namespace QuanLyKhachSan.MVVM.View
{
    /// <summary>
    /// Interaction logic for RoomRentalView.xaml
    /// </summary>
    public partial class RoomRentalView : UserControl
    {
        BUS_PHIEUTHUEPHONG busPTP = new BUS_PHIEUTHUEPHONG();
        BUS_KHACHHANG kh = new BUS_KHACHHANG();
        BUS_LOAIKHACH lk = new BUS_LOAIKHACH();
        public string formCode;

        public RoomRentalView()
        {
            InitializeComponent();
            DataGridLoad();
            LoadKh();
        }

        private void CreateRentalDetailFormButton_Click(object sender, RoutedEventArgs e)
        {
            if (roomRentalFormListDataGrid.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một phiếu thuê phòng", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            DataRowView row = roomRentalFormListDataGrid.SelectedItem as DataRowView;
            if (row == null)
            {
                ClearTextBoxes();
                return;
            }
            
            ChiTietPTP chiTietPTP = new ChiTietPTP();
            chiTietPTP.maPTP = formCode;
            chiTietPTP.ShowDialog();
        }

        private void Create_UpdateRentalFormButton_Click(object sender, RoutedEventArgs e)
        {
            DTO_PHIEUTHUEPHONG inputPTP = new DTO_PHIEUTHUEPHONG();
            inputPTP._MAPHONG = int.Parse(roomCodeTextBox.Text);
            inputPTP._NGAYLAP = DateTime.ParseExact(startTimeTextbox.Text, "dd/MM/yyyy", null);
            inputPTP._SOLUONG = int.Parse(guestAmountTextBox.Text);
            inputPTP._DONGIA = long.Parse(priceTextBox.Text);

            if (CheckExists())
            {
                busPTP.SuaPhieuThuePhong(inputPTP);
            }
            else
            {
                busPTP.ThemPhieuThuePhong(inputPTP);
            }
            DataGridLoad();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (formCode == string.Empty) return;
            busPTP.XoaPhieuThuePhong(formCode);
            ClearTextBoxes();
            DataGridLoad();
            formCode = string.Empty;
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            formCode = string.Empty;
            ClearTextBoxes();
            DataGridLoad();
        }

        private void RoomRentalFormListDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (roomRentalFormListDataGrid.SelectedItems.Count == 0) return;
            DataRowView row = roomRentalFormListDataGrid.SelectedItem as DataRowView;
            if (row == null)
            {
                ClearTextBoxes();
                return;
            }
            formCode = row[0].ToString();
            roomCodeTextBox.Text = row[1].ToString();
            startTimeTextbox.Text = row[2].ToString();
            guestAmountTextBox.Text = row[3].ToString();
            priceTextBox.Text = row[4].ToString();
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            DTO_KHACHHANG dTO_KHACHHANG = new DTO_KHACHHANG();
            dTO_KHACHHANG.MALK = lk.getMaLK(typeTb.Text.ToString());
            dTO_KHACHHANG.TENKH = nameTb.Text;
            dTO_KHACHHANG.CMND = cmndTb.Text;
            dTO_KHACHHANG.DIACHI = addressTb.Text;
            kh.ThemKhachHang(dTO_KHACHHANG);
            LoadKh();
        }

        private void khDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (khDataGrid.SelectedItem != null)
            {
                DataRowView row = khDataGrid.SelectedItem as DataRowView;
                typeTb.Text = row[5].ToString();
                nameTb.Text = row[2].ToString();
                cmndTb.Text = row[3].ToString();
                addressTb.Text = row[4].ToString();
            }
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            if (khDataGrid.SelectedItem != null)
            {
                DataRowView row = khDataGrid.SelectedItem as DataRowView;
                DTO_KHACHHANG dTO_KHACHHANG = new DTO_KHACHHANG();
                dTO_KHACHHANG.MAKH = Convert.ToInt32(row[0].ToString());
                dTO_KHACHHANG.MALK = lk.getMaLK(typeTb.Text.ToString());
                dTO_KHACHHANG.TENKH = nameTb.Text;
                dTO_KHACHHANG.CMND = cmndTb.Text;
                dTO_KHACHHANG.DIACHI = addressTb.Text;
                kh.SuaKhachHang(dTO_KHACHHANG);
                LoadKh();
            }
        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            if (khDataGrid.SelectedItem != null)
            {
                DataRowView row = khDataGrid.SelectedItem as DataRowView;
                kh.XoaKhachHang(Convert.ToInt32(row[0].ToString()));
            }
            LoadKh();
        }

        private void newBtn_Click(object sender, RoutedEventArgs e)
        {
            nameTb.Text = cmndTb.Text = addressTb.Text = typeTb.Text = "";
            LoadKh();
        }

        public void DataGridLoad()
        {
            roomRentalFormListDataGrid.DataContext = busPTP.getDSPTP();
        }

        public void LoadKh()
        {
            khDataGrid.DataContext = kh.getLoaiKhachHang();
        }


        public void ClearTextBoxes()
        {
            roomCodeTextBox.Text = guestAmountTextBox.Text = startTimeTextbox.Text = priceTextBox.Text = string.Empty;
        }

        private bool CheckExists()
        {
            for (int i = 0; i < roomRentalFormListDataGrid.Items.Count - 1; i++)
            {
                DataRowView dataRowView = roomRentalFormListDataGrid.Items[i] as DataRowView;
                if (dataRowView[0].ToString() == formCode)
                {
                    return true;
                }

            }
            return false;
        }    
    }
}
