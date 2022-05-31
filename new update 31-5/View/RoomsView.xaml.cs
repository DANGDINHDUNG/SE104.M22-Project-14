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
using System.Text.RegularExpressions;

namespace QuanLyKhachSan.MVVM.View
{
    /// <summary>
    /// Interaction logic for RoomsView.xaml
    /// </summary>
    public partial class RoomsView : UserControl
    {
        BUS_PHONG busPhong = new BUS_PHONG();
        

        public RoomsView()
        {
            InitializeComponent();
            RoomsLoad();
        }

        public void RoomsLoad()
        {
            int emptyRooms = 0;
            int rentedRooms = 0;
            List<string> listMaPhong = busPhong.TongHopMaPhong();

            for (int i = 0; i < listMaPhong.Count(); i++)
            {
                RadioButton roomRadioButton = new RadioButton();
                CreateRoomRdioButton(roomRadioButton, listMaPhong[i], ref emptyRooms, ref rentedRooms);  
                MainRoomsScreen.Children.Add(roomRadioButton);
                AmountButtonLoad(listMaPhong.Count(), emptyRooms, rentedRooms);
            }
        }

        private void searchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Search.Text == string.Empty)
            {
                MainRoomsScreen.Children.Clear();
                RoomsLoad();
                return;
            }

            if (busPhong.TimKiemPhong(int.Parse(Search.Text)))
            {
                int emptyRooms = 0;
                int rentedRooms = 0;
                RadioButton roomRadioButton = new RadioButton();
                MainRoomsScreen.Children.Clear();
                CreateRoomRdioButton(roomRadioButton, Search.Text, ref emptyRooms, ref rentedRooms);
                MainRoomsScreen.Children.Add(roomRadioButton);
                AmountButtonLoad(1, emptyRooms, rentedRooms);
            }
            else
            {
                MainRoomsScreen.Children.Clear();
                return;
            }
        }

        private void SearchTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }

        public void CreateRoomRdioButton(RadioButton roomRadioButton, string maPhong, ref int emptyRooms, ref int rentedRooms)
        {
            if (busPhong.CheckPhongDaThue(int.Parse(maPhong)))
            {
                roomRadioButton.Style = Application.Current.FindResource("OrderRoomButton") as Style;
                rentedRooms++;
            }
            else
            {
                roomRadioButton.Style = Application.Current.FindResource("EmptyRoomButton") as Style;
                emptyRooms++;
            }
            
            roomRadioButton.Content = maPhong;
        }
        
        public void AmountButtonLoad(int amount, int emptyRooms, int rentedRooms)
        {
            allRoomsRadioButton.Content = "Tất cả (" + amount.ToString() + ")";
            emptyRoomsRadioButton.Content = "Còn trống (" + emptyRooms.ToString() + ")";
            rentedRoomsRadioButton.Content = "Đã thuê (" + rentedRooms.ToString() + ")";
        }

        private void EmptyRoomsRadioButton_Click(object sender, RoutedEventArgs e)
        {
            HideSelectedStatusRooms(Application.Current.FindResource("EmptyRoomButton") as Style);
        }

        private void RentedRoomsRadioButton_Click(object sender, RoutedEventArgs e)
        {
            HideSelectedStatusRooms(Application.Current.FindResource("OrderRoomButton") as Style);
        }

        private void AllRoomsRadioButton_Click(object sender, RoutedEventArgs e)
        {
            MainRoomsScreen.Children.Clear();
            RoomsLoad();
        }

        public void HideSelectedStatusRooms(Style buttonStyle)
        {
            MainRoomsScreen.Children.Clear();
            RoomsLoad();
            for (int i = 0; i < MainRoomsScreen.Children.Count; i++)
            {
                RadioButton roomRadioButton = (RadioButton)MainRoomsScreen.Children[i];
                if (roomRadioButton.Style != buttonStyle)
                {
                    MainRoomsScreen.Children[i].Visibility = Visibility.Collapsed;
                }
            }
        }
    }
}