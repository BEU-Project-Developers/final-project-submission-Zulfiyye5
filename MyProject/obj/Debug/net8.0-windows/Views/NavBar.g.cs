﻿#pragma checksum "..\..\..\..\Views\NavBar.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "781F7C6E00367B1C5654CEEA2522E0F87AE104BC"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MyProject;
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


namespace MyProject {
    
    
    /// <summary>
    /// NavBar
    /// </summary>
    public partial class NavBar : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\..\Views\NavBar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock FavoritesText;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\Views\NavBar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock WatchListText;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\Views\NavBar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock WatchedText;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\Views\NavBar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SearchBoxTextBox;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\..\Views\NavBar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AccountButton;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\..\Views\NavBar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.Popup AccountPopup;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/MyProject;component/views/navbar.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\NavBar.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 12 "..\..\..\..\Views\NavBar.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.GoToMovies);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 18 "..\..\..\..\Views\NavBar.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.GoToFavorities);
            
            #line default
            #line hidden
            return;
            case 3:
            this.FavoritesText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            
            #line 23 "..\..\..\..\Views\NavBar.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.GoToWatchList);
            
            #line default
            #line hidden
            return;
            case 5:
            this.WatchListText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            
            #line 28 "..\..\..\..\Views\NavBar.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.GoToWatched);
            
            #line default
            #line hidden
            return;
            case 7:
            this.WatchedText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.SearchBoxTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 40 "..\..\..\..\Views\NavBar.xaml"
            this.SearchBoxTextBox.GotFocus += new System.Windows.RoutedEventHandler(this.SearchBoxFocus);
            
            #line default
            #line hidden
            
            #line 40 "..\..\..\..\Views\NavBar.xaml"
            this.SearchBoxTextBox.KeyDown += new System.Windows.Input.KeyEventHandler(this.SearchBoxTextBox_KeyDown);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 43 "..\..\..\..\Views\NavBar.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SearchMoviesClick);
            
            #line default
            #line hidden
            return;
            case 10:
            this.AccountButton = ((System.Windows.Controls.Button)(target));
            
            #line 48 "..\..\..\..\Views\NavBar.xaml"
            this.AccountButton.Click += new System.Windows.RoutedEventHandler(this.AccountButton_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.AccountPopup = ((System.Windows.Controls.Primitives.Popup)(target));
            return;
            case 12:
            
            #line 58 "..\..\..\..\Views\NavBar.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SignOutClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

