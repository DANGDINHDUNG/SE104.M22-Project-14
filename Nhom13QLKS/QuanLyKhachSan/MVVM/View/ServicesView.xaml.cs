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
using System.Data;
using BUS;
using DTO;
using System.Text.RegularExpressions;

namespace QuanLyKhachSan.MVVM.View
{
    /// <summary>
    /// Interaction logic for ServicesView.xaml
    /// </summary>
    public partial class ServicesView : UserControl
    {
        BUS_DICHVU dv = new BUS_DICHVU();
        public ServicesView()
        {
            InitializeComponent();
            Load();
        }
        public void Load()
        {
            dvDtg.DataContext = dv.getDichVu();
        }

        private void ThemBtn_Click(object sender, RoutedEventArgs e)
        {
            if (donGiaTbx.Text != "" && tendvTbx.Text != "")
            {
                int i = 0;
                decimal money;
                decimal.TryParse(donGiaTbx.Text, out money);
                DTO_DICHVU dto_dv = new DTO_DICHVU(i, tendvTbx.Text, money);
                dv.ThemDichVu(dto_dv);
                Load();
            }
        }

        private void SuaBtn_Click(object sender, RoutedEventArgs e)
        {
            if (madvTbx.Text != "" && donGiaTbx.Text != "" && tendvTbx.Text != "")
            {
                int i = Int32.Parse(madvTbx.Text);
                int money;
                int.TryParse(donGiaTbx.Text, out money);
                DTO_DICHVU dto_dv = new DTO_DICHVU(i, tendvTbx.Text, money);
                dv.SuaDichVu(dto_dv);
                Load();
            }
        }

        private void XoaBtn_Click(object sender, RoutedEventArgs e)
        {
            var result= MessageBox.Show("Bạn muốn xóa không?","Thông báo", MessageBoxButton.YesNo,MessageBoxImage.Information);
            if (result == MessageBoxResult.No)
                return;
            if (madvTbx.Text != "" && donGiaTbx.Text != "" && tendvTbx.Text != "")
            {
                int i = Int32.Parse(madvTbx.Text);
                dv.XoaDichVu(i);
                Load();
                madvTbx.Text = donGiaTbx.Text = tendvTbx.Text = "";
            }
        }

        private void DvDtg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dvDtg.SelectedItem != null)
            {
                DataRowView row = dvDtg.SelectedItem as DataRowView;
                madvTbx.Text = row[0].ToString();
                tendvTbx.Text = row[1].ToString();
                donGiaTbx.Text = row[2].ToString();
            }
        }

        private void donGiaTbx_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }
    }
}
