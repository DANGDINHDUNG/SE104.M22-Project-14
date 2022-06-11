using LiveCharts;
using LiveCharts.Helpers;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using BUS;
using DTO;

namespace QuanLyKhachSan.MVVM.View
{
    /// <summary>
    /// Interaction logic for ReportationView.xaml
    /// </summary>
    public partial class ReportationView : UserControl, INotifyPropertyChanged
    {
        BUS_BAOCAODOANHTHU bcdt = new BUS_BAOCAODOANHTHU();
        BUS_CTBAOCAODOANHTHU ctbcdt = new BUS_CTBAOCAODOANHTHU();
        BUS_LOAIPHONG lp = new BUS_LOAIPHONG();

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ReportationView()
        {
            InitializeComponent();

            for (int i = 1; i <= 12; i++)
            {
                thangCbx.Items.Add(i);
            }


            thangCbx.Text = myDateTime.Month.ToString();

            SeriesCollection = new SeriesCollection();        
        }

        DateTime myDateTime = DateTime.Now;
        int year;
        string maBCDT;


        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }

        private void chiTietDTBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (namNayRbtn.IsChecked == true)
                {
                    year = myDateTime.Year;
                }
                else
                {
                    year = myDateTime.Year - 1;
                }

                maBCDT = bcdt.GetMaBCDT(Convert.ToInt32(thangCbx.Text), year);
                ChiTietDT chiTietDT = new ChiTietDT();
                chiTietDT.mabcdt = Convert.ToInt32(maBCDT);
                chiTietDT.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Tháng đã chọn hiện chưa có báo cáo", "Thông báo");
            }
        }

        private void taoBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                hinhNenTbl.Visibility = Visibility.Hidden;
                if (namNayRbtn.IsChecked == true)
                {
                    year = myDateTime.Year;
                }
                else
                {
                    year = myDateTime.Year - 1;
                }

                maBCDT = bcdt.GetMaBCDT(Convert.ToInt32(thangCbx.Text), year);

                foreach (string code in lp.TongHopMaLoaiPhong())
                {
                    List<double> listdoanhthu = new List<double>();

                    double doanhthu = Convert.ToDouble(ctbcdt.GetDoanhThu(code, maBCDT));
                    listdoanhthu.Add(doanhthu);
                    ColumnSeries column = new ColumnSeries();

                    string title = code;
                    column.Title = title;
                    column.Values = listdoanhthu.AsChartValues();
                    SeriesCollection.Add(column);
                }

                tblTongDoanhThu.Text = ctbcdt.GetTongDoanhThuTrongThang(maBCDT);
                chiTietDTBtn.IsEnabled = true;

            }
            catch
            {
                MessageBox.Show("Tháng đã chọn hiện chưa có báo cáo", "Thông báo");
            }

            taoBtn.IsEnabled = false;
            DataContext = this;
        }

        private void huyBtn_Click(object sender, RoutedEventArgs e)
        {
            SeriesCollection.Clear();
            taoBtn.IsEnabled = true;
            chiTietDTBtn.IsEnabled = false;
            tblTongDoanhThu.Text = string.Empty;
        }
    }
}
