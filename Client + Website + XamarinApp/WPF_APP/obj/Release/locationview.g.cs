﻿#pragma checksum "..\..\locationview.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "30CC8F47142A92175F1BFAF87AFD124227001855FE384D8E0BF4650EDD048FD6"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
using WpfApp6;


namespace WpfApp6 {
    
    
    /// <summary>
    /// locationview
    /// </summary>
    public partial class locationview : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\locationview.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button b1;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\locationview.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button b4;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\locationview.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button b2;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\locationview.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button b3;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\locationview.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button b7;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\locationview.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame frame;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WpfApp6;component/locationview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\locationview.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.b1 = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\locationview.xaml"
            this.b1.Click += new System.Windows.RoutedEventHandler(this.Button_ChangeView);
            
            #line default
            #line hidden
            return;
            case 2:
            this.b4 = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\locationview.xaml"
            this.b4.Click += new System.Windows.RoutedEventHandler(this.Back_admin);
            
            #line default
            #line hidden
            return;
            case 3:
            this.b2 = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\locationview.xaml"
            this.b2.Click += new System.Windows.RoutedEventHandler(this.Button_MyCom);
            
            #line default
            #line hidden
            return;
            case 4:
            this.b3 = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\locationview.xaml"
            this.b3.Click += new System.Windows.RoutedEventHandler(this.Button_InsertLocation);
            
            #line default
            #line hidden
            return;
            case 5:
            this.b7 = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\locationview.xaml"
            this.b7.Click += new System.Windows.RoutedEventHandler(this.logout);
            
            #line default
            #line hidden
            return;
            case 6:
            this.frame = ((System.Windows.Controls.Frame)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
