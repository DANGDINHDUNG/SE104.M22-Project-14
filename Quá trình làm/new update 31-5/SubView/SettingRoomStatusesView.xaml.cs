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
    /// Interaction logic for SettingRoomStatusesView.xaml
    /// </summary>
    public partial class SettingRoomStatusesView : UserControl
    {
        public BUS_PHONG busPhong = new BUS_PHONG();
        public BUS_LOAIPHONG busLoaiPhong = new BUS_LOAIPHONG();

        public SettingRoomStatusesView()
        {
            InitializeComponent();
            DataGridLoad();
        }

        private void AddButton_UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            string roomTypeCode = busLoaiPhong.TimKiemTheoTenLoaiPhong(roomTypeTextBox.Text);
            DTO_PHONG inputPhong = new DTO_PHONG();
            inputPhong._MALP = roomTypeCode;
            inputPhong._TENPHONG = roomNameTextBox.Text;
            inputPhong._TRANGTHAI = statusTextBox.Text;

            if (CheckExists())
            {
                busPhong.SuaPhong(inputPhong, int.Parse(roomCodeTextBox.Text));
            }
            else
            {
                busPhong.ThemPhong(inputPhong);
            }
            DataGridLoad();
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            ClearTextBoxes();
            DataGridLoad();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (roomCodeTextBox.Text == string.Empty) return;
            busPhong.XoaPhong(int.Parse(roomCodeTextBox.Text));
            DataGridLoad();
        }

        private void roomStatusDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (roomStatusDataGrid.SelectedItems.Count == 0) return;
            DataRowView row = roomStatusDataGrid.SelectedItem as DataRowView;
            if (row == null)
            {
                ClearTextBoxes();
                return;
            }
            roomCodeTextBox.Text = row[0].ToString();
            roomNameTextBox.Text = row[1].ToString();
            roomTypeTextBox.Text = row[2].ToString();
            priceTextBox.Text = row[3].ToString();
            statusTextBox.Text = row[4].ToString();
        }

        public void DataGridLoad()
        {
            roomStatusDataGrid.DataContext = busPhong.getDSPhongKemTrangThai();
        }

        public void ClearTextBoxes()
        {
            roomCodeTextBox.Text = roomNameTextBox.Text = roomTypeTextBox.Text = priceTextBox.Text = statusTextBox.Text = string.Empty;
        }

        private bool CheckExists()
        {
            for (int i = 0; i < roomStatusDataGrid.Items.Count - 1; i++)
            {
                DataRowView dataRowView = roomStatusDataGrid.Items[i] as DataRowView;
                if (dataRowView[1].ToString() == roomNameTextBox.Text || dataRowView[0].ToString() == roomCodeTextBox.Text)
                {
                    return true;
                }

            }
            return false;
        }
    }
}
