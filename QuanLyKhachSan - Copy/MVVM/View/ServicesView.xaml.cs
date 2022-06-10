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
            datagrid.DataContext = dv.getDichVu();
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            if(numTb.Text!="" && priceTb.Text!="" && nameTb.Text!="")
            {
                int i = Int32.Parse(numTb.Text);
                int money;
                int.TryParse(priceTb.Text, out money);
                DTO_DICHVU dto_dv = new DTO_DICHVU(i,nameTb.Text,money);
                dv.ThemDichVu(dto_dv);
                Load();
            }
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            if (numTb.Text != "" && priceTb.Text != "" && nameTb.Text != "")
            {
                int i = Int32.Parse(numTb.Text);
                int money;
                int.TryParse(priceTb.Text, out money);
                DTO_DICHVU dto_dv = new DTO_DICHVU(i, nameTb.Text, money);
                dv.SuaDichVu(dto_dv);
                Load();
            }
        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            if (numTb.Text != "" && priceTb.Text != "" && nameTb.Text != "")
            {
                int i = Int32.Parse(numTb.Text);
                dv.XoaDichVu(i);
                Load();
            }
        }

        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(datagrid.SelectedItem!=null)
            {
                DataRowView row = datagrid.SelectedItem as DataRowView;
                numTb.Text = row[0].ToString();
                nameTb.Text = row[1].ToString();
                priceTb.Text = row[2].ToString();
            }
        }
    }
}
