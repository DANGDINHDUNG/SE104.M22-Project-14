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
    /// Interaction logic for SettingRoomTypesView.xaml
    /// </summary>
    public partial class SettingRoomTypesView : UserControl
    {
        public BUS_LOAIPHONG busLoaiPhong = new BUS_LOAIPHONG();

        public SettingRoomTypesView()
        {
            InitializeComponent();
            DataGridLoad();
        }

        private void AddButton_UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            DTO_LOAIPHONG loaiPhong = new DTO_LOAIPHONG(roomTypeCodeTextBox.Text, roomTypeNameTextBox.Text, Decimal.Parse(priceTextBox.Text));

            if (CheckExists())
            {
                busLoaiPhong.SuaLoaiPhong(loaiPhong);
            }
            else
            {
                busLoaiPhong.ThemLoaiPhong(loaiPhong);
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
            busLoaiPhong.XoaLoaiPhong(roomTypeCodeTextBox.Text);
            DataGridLoad();
        }

        private void RoomTypeListDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (roomTypeListDataGrid.SelectedItems.Count == 0) return;
            DataRowView row = roomTypeListDataGrid.SelectedItem as DataRowView;
            if (row == null)
            {
                ClearTextBoxes();
                return;
            }
            roomTypeCodeTextBox.Text = row[0].ToString();
            roomTypeNameTextBox.Text = row[1].ToString();
            priceTextBox.Text = row[2].ToString();
        }

        public void DataGridLoad()
        {
            roomTypeListDataGrid.DataContext = busLoaiPhong.getDSLoaiPhong();
        }

        public void ClearTextBoxes()
        {
            roomTypeCodeTextBox.Text = roomTypeNameTextBox.Text = priceTextBox.Text = string.Empty;
        }

        private bool CheckExists()
        {
            for (int i = 0; i < roomTypeListDataGrid.Items.Count - 1; i++)
            {
                DataRowView dataRowView = roomTypeListDataGrid.Items[i] as DataRowView;
                if (dataRowView[1].ToString() == roomTypeNameTextBox.Text || dataRowView[0].ToString() == roomTypeCodeTextBox.Text)
                {
                    return true;
                }

            }
            return false;
        }
    }
}
