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
using System.Windows.Shapes;
using System.Data;
using BUS;
using Microsoft.Win32;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;

namespace QuanLyKhachSan.MVVM.View
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class ChiTietDT : Window
    {
        BUS_CTBAOCAODOANHTHU ctbcdt = new BUS_CTBAOCAODOANHTHU();

        public int mabcdt;
        public ChiTietDT()
        {
            InitializeComponent();
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
            }
            else
            {
                MaximizeButton_Image.Source = new BitmapImage(new Uri(@"/Images/QuadButton.png", UriKind.Relative));
                WindowState = WindowState.Normal;

                MainBorder.CornerRadius = new CornerRadius(20);
                MainBorder.BorderThickness = new Thickness(5);
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
            }
            else
            {
                MaximizeButton_Image.Source = new BitmapImage(new Uri(@"/Images/QuadButton.png", UriKind.Relative));
                WindowState = WindowState.Normal;

                MainBorder.CornerRadius = new CornerRadius(20);
                MainBorder.BorderThickness = new Thickness(5);
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }

        }

        private void Load(object sender, RoutedEventArgs e)
        {
            datagrid.DataContext = ctbcdt.getDSctBAOCAODOANHTHU(mabcdt);
        }
        
        private void hoanTatBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void xuatExcelBtn_Click(object sender, RoutedEventArgs e)
        {
            string filePath = "";

            SaveFileDialog dialog = new SaveFileDialog();

            dialog.Filter = "Excel |*.xlsx"; 

            if (dialog.ShowDialog() == true)
            {
                filePath = dialog.FileName;
            }

            if (string.IsNullOrEmpty(filePath))
            {
                MessageBox.Show("Đường dẫn không hợp lệ!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            try
            {
                using (ExcelPackage p = new ExcelPackage())
                {
                    p.Workbook.Properties.Author = "Nhóm 13_CNPM";
                    p.Workbook.Properties.Title = "Báo cáo doanh thu";
                    p.Workbook.Worksheets.Add("Sheet 1");

                    ExcelWorksheet ws = p.Workbook.Worksheets[0];
                    ws.Name = "Test sheet";
                    ws.Cells.Style.Font.Size = 14;
                    ws.Cells.Style.Font.Name = "Consolas";

                    string[] arrColumnHeader = { "Mã CTBCDT", "Mã loại phòng", "Mã BCDT", "Doanh thu (VND)", "Tỷ lệ (%)" };

                    var countColHeader = arrColumnHeader.Count();

                    ws.Cells[1, 1].Value = "Báo cáo doanh thu";
                    ws.Cells[1, 1, 1, countColHeader].Merge = true;
                    ws.Cells[1, 1, 1, countColHeader].Style.Font.Bold = true;
                    ws.Cells[1, 1, 1, countColHeader].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    int colIndex = 1;
                    int rowIndex = 2;

                    foreach(var item in arrColumnHeader)
                    {
                        var cell = ws.Cells[rowIndex, colIndex];

                        var fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);

                        var border = cell.Style.Border;
                        border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                        cell.Value = item;
                        colIndex++;
                    }
                    DataTable dt = new DataTable();
                    dt = ctbcdt.getDSctBAOCAODOANHTHU(mabcdt);

                    foreach (DataRow dr in dt.Rows)
                    {
                        colIndex = 1;
                        rowIndex++;

                        ws.Cells[rowIndex, colIndex++].Value = dr["MACTBCDT"].ToString();
                        ws.Cells[rowIndex, colIndex++].Value = dr["MALP"].ToString();
                        ws.Cells[rowIndex, colIndex++].Value = dr["MABCDT"].ToString();
                        ws.Cells[rowIndex, colIndex++].Value = dr["DOANHTHU"].ToString();
                        ws.Cells[rowIndex, colIndex++].Value = dr["TYLE"].ToString();

                    }

                    Byte[] bin = p.GetAsByteArray();
                    File.WriteAllBytes(filePath, bin);

                }
                MessageBox.Show("Xuất excel thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {
                MessageBox.Show("Đã xảy ra lỗi khi lưu file!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}