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
        BUS_LOAIPHONG lp = new BUS_LOAIPHONG();

        public RoomsView()
        {
            InitializeComponent();
            RoomsLoad();
        }

        private void timKiemTxb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (timKiemTxb.Text == string.Empty)
            {
                danhSachPhongWrp.Children.Clear();
                RoomsLoad();
                return;
            }

            if (busPhong.TimKiemPhong(int.Parse(timKiemTxb.Text)))
            {
                int emptyRooms = 0;
                int rentedRooms = 0;
                RadioButton roomRadioButton = new RadioButton();
                danhSachPhongWrp.Children.Clear();
                CreateRoomRdioButton(roomRadioButton, timKiemTxb.Text, lp.getLoaiPhongTheoMaPhong(timKiemTxb.Text), ref emptyRooms, ref rentedRooms);
                danhSachPhongWrp.Children.Add(roomRadioButton);
                AmountButtonLoad(1, emptyRooms, rentedRooms);
            }
            else
            {
                danhSachPhongWrp.Children.Clear();
                return;
            }
        }

        private void timKiemTxb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }
        
        private void conTrongRbn_Click(object sender, RoutedEventArgs e)
        {
            HideSelectedStatusRooms(Application.Current.FindResource("EmptyRoomButton") as Style);
        }

        private void daThueRbn_Click(object sender, RoutedEventArgs e)
        {
            HideSelectedStatusRooms(Application.Current.FindResource("OrderRoomButton") as Style);
        }

        private void tatCaRbn_Click(object sender, RoutedEventArgs e)
        {
            danhSachPhongWrp.Children.Clear();
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
                CreateRoomRdioButton(roomRadioButton, listMaPhong[i], lp.getLoaiPhongTheoMaPhong(listMaPhong[i]), ref emptyRooms, ref rentedRooms);
                danhSachPhongWrp.Children.Add(roomRadioButton);
                AmountButtonLoad(listMaPhong.Count(), emptyRooms, rentedRooms);
            }
        }

        public void AmountButtonLoad(int amount, int emptyRooms, int rentedRooms)
        {
            tatCaRbn.Content = "Tất cả (" + amount.ToString() + ")";
            conTrongRbn.Content = "Còn trống (" + emptyRooms.ToString() + ")";
            daThueRbn.Content = "Đã thuê (" + rentedRooms.ToString() + ")";
        }

        public void CreateRoomRdioButton(RadioButton roomRadioButton, string maPhong, string maLP, ref int emptyRooms, ref int rentedRooms)
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

            roomRadioButton.Content = maPhong + "-" + maLP;
        }

        public void HideSelectedStatusRooms(Style buttonStyle)
        {
            danhSachPhongWrp.Children.Clear();
            RoomsLoad();
            for (int i = 0; i < danhSachPhongWrp.Children.Count; i++)
            {
                RadioButton roomRadioButton = (RadioButton)danhSachPhongWrp.Children[i];
                if (roomRadioButton.Style != buttonStyle)
                {
                    danhSachPhongWrp.Children[i].Visibility = Visibility.Collapsed;
                }
            }
        }
    }
}