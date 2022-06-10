using System.Data.SqlClient;
using System.Configuration;

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
using System.Windows.Threading;
using BUS;
using DTO;
namespace QuanLyKhachSan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(DTO_TAIKHOAN tk)
        {
            InitializeComponent();
            AccountButton.Content = tk._TENCHUTAIKHOAN;
            if(tk._MALOAITK!=1)
            {
                SignUp.Visibility = Visibility.Hidden;
            }
            StartClock();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal) 
            {
                MaximizeButton_Image.Source = new BitmapImage(new Uri("/Images/DoubleQuadButton.png", UriKind.Relative));
                WindowState = WindowState.Maximized;

                MainBorder.CornerRadius = new CornerRadius(0);
                MainBorder.BorderThickness = new Thickness(0);

                TopBorder_Max.Visibility = Visibility.Visible;
                BotBorder_Max.Visibility = Visibility.Visible;
                BotBorder2_Max.Visibility = Visibility.Visible;
                TopBorder.Visibility = Visibility.Collapsed;
                BotBorder.Visibility = Visibility.Collapsed;
                BotBorder2.Visibility = Visibility.Collapsed;
            }
            else
            {
                MaximizeButton_Image.Source = new BitmapImage(new Uri(@"/Images/QuadButton.png", UriKind.Relative));
                WindowState = WindowState.Normal;

                MainBorder.CornerRadius = new CornerRadius(20);
                MainBorder.BorderThickness = new Thickness(5);

                TopBorder_Max.Visibility = Visibility.Collapsed;
                BotBorder_Max.Visibility = Visibility.Collapsed;
                BotBorder2_Max.Visibility = Visibility.Collapsed;
                TopBorder.Visibility = Visibility.Visible;
                BotBorder.Visibility = Visibility.Visible;
                BotBorder2.Visibility = Visibility.Visible;
            } 
        }

        private void TitleBarThumb_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount != 2)
            {
                return;
            }

            if (WindowState == WindowState.Normal)
            {
                MaximizeButton_Image.Source = new BitmapImage(new Uri("/Images/DoubleQuadButton.png", UriKind.Relative));
                WindowState = WindowState.Maximized;

                MainBorder.CornerRadius = new CornerRadius(0);
                MainBorder.BorderThickness = new Thickness(0);

                TopBorder_Max.Visibility = Visibility.Visible;
                BotBorder_Max.Visibility = Visibility.Visible;
                BotBorder2_Max.Visibility = Visibility.Visible;
                TopBorder.Visibility = Visibility.Collapsed;
                BotBorder.Visibility = Visibility.Collapsed;
                BotBorder2.Visibility = Visibility.Collapsed;
            }
            else
            {
                MaximizeButton_Image.Source = new BitmapImage(new Uri(@"/Images/QuadButton.png", UriKind.Relative));
                WindowState = WindowState.Normal;

                MainBorder.CornerRadius = new CornerRadius(20);
                MainBorder.BorderThickness = new Thickness(5);

                TopBorder_Max.Visibility = Visibility.Collapsed;
                BotBorder_Max.Visibility = Visibility.Collapsed;
                BotBorder2_Max.Visibility = Visibility.Collapsed;
                TopBorder.Visibility = Visibility.Visible;
                BotBorder.Visibility = Visibility.Visible;
                BotBorder2.Visibility = Visibility.Visible;
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }

        }

        private void LogoutButton_Clicked(object sender, RoutedEventArgs e)
        {
            LoginScreen dashboard = new LoginScreen();
            
            dashboard.Show();
            Close();
        }

        private void StartClock()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += TickEvent;
            timer.Start();
        }

        private void TickEvent(object sender, EventArgs e)
        {
            Timer.Text = DateTime.Now.ToString();
        }

        private void SignUpButton_Clicked(object sender, RoutedEventArgs e)
        {
            SignUp screen = new() { Owner = this };
            screen.ShowDialog();
        }
    }
}
