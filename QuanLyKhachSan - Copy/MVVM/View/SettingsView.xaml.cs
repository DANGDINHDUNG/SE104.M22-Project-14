﻿using System;
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
using BUS;
namespace QuanLyKhachSan.MVVM.View
{
    /// <summary>
    /// Interaction logic for SettingsView.xaml
    /// </summary>
    public partial class SettingsView : UserControl
    {
        BUS_PHONG phong =new BUS_PHONG();
        public SettingsView()
        {
            InitializeComponent();
            Load();
        }
        public void Load()
        {
            room_.DataContext = phong.getDSPhong();
        }
    }
}
