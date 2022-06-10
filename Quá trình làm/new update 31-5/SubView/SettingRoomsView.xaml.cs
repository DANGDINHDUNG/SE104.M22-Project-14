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
    /// Interaction logic for SettingRoomsView.xaml
    /// </summary>
    public partial class SettingRoomsView : UserControl
    {
        //public bool existsRoomCode = false;
        public BUS_PHONG busPhong = new BUS_PHONG();
        public BUS_LOAIPHONG busLoaiPhong = new BUS_LOAIPHONG();

        public SettingRoomsView()
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
            inputPhong._GHICHU = noteTextBox.Text;

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
            ClearTextBoxes();
        }

        private void RoomListDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (roomListDataGrid.SelectedItems.Count == 0) return;
            DataRowView row = roomListDataGrid.SelectedItem as DataRowView;
            if (row == null)
            {
                ClearTextBoxes();
                return;
            }
            roomCodeTextBox.Text = row[0].ToString();
            roomNameTextBox.Text = row[1].ToString();
            roomTypeTextBox.Text = row[2].ToString();
            priceTextBox.Text = row[3].ToString();
            noteTextBox.Text = row[4].ToString();
        }

        public void DataGridLoad()
        {
            roomListDataGrid.DataContext = busPhong.getDSPhong();
        }

        public void ClearTextBoxes()
        {
            roomCodeTextBox.Text = roomTypeTextBox.Text = roomNameTextBox.Text = priceTextBox.Text = noteTextBox.Text = string.Empty;
        }

        private bool CheckExists()
        {
            for (int i = 0; i < roomListDataGrid.Items.Count - 1; i++)
            {
                DataRowView dataRowView = roomListDataGrid.Items[i] as DataRowView;
                if (dataRowView[2].ToString() == roomNameTextBox.Text || dataRowView[0].ToString() == roomCodeTextBox.Text)
                {
                    return true; 
                }    
                
            }
            return false;
        }
    }
}
