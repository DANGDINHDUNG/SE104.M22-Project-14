﻿#pragma checksum "..\..\..\ForgotPasswordScreen.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "EEFC2A380B4D8617C2427E93D9C255E3C3532DC4"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using QuanLyKhachSan;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace QuanLyKhachSan {
    
    
    /// <summary>
    /// ForgotPasswordScreen
    /// </summary>
    public partial class ForgotPasswordScreen : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 66 "..\..\..\ForgotPasswordScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox taiKhoanTbx;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\..\ForgotPasswordScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tenChuTKTbx;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\..\ForgotPasswordScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox matKhauPwb;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\..\ForgotPasswordScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox nhapLaiMKPwb;
        
        #line default
        #line hidden
        
        
        #line 95 "..\..\..\ForgotPasswordScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button xacNhanBtn;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.5.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/GUI;component/forgotpasswordscreen.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\ForgotPasswordScreen.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 35 "..\..\..\ForgotPasswordScreen.xaml"
            ((System.Windows.Controls.Grid)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 41 "..\..\..\ForgotPasswordScreen.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CloseButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.taiKhoanTbx = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.tenChuTKTbx = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.matKhauPwb = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 6:
            this.nhapLaiMKPwb = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 7:
            this.xacNhanBtn = ((System.Windows.Controls.Button)(target));
            
            #line 96 "..\..\..\ForgotPasswordScreen.xaml"
            this.xacNhanBtn.Click += new System.Windows.RoutedEventHandler(this.XacNhanBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

