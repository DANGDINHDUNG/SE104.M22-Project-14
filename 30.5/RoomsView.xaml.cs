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

namespace QuanLyKhachSan.MVVM.View
{
    /// <summary>
    /// Interaction logic for RoomsView.xaml
    /// </summary>
    public partial class RoomsView : UserControl
    {
        public RoomsView()
        {
            InitializeComponent();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton Room = new RadioButton();
            Room.Style = Application.Current.FindResource("OrderRoomButton") as Style;
            Room.Content = "New";
            MainRoomsScreen.Children.Add(Room);
        }
    }
}
