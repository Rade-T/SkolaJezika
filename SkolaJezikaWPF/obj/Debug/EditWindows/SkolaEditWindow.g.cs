﻿#pragma checksum "..\..\..\EditWindows\SkolaEditWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "8A8331A89C71DCA95CC06BE897FEC6BB"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
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


namespace SkolaJezikaWPF.EditWindows {
    
    
    /// <summary>
    /// SkolaEditWindow
    /// </summary>
    public partial class SkolaEditWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\..\EditWindows\SkolaEditWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbNaziv;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\EditWindows\SkolaEditWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbAdresa;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\EditWindows\SkolaEditWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bSacuvaj;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\EditWindows\SkolaEditWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bOdustani;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\EditWindows\SkolaEditWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbInternetAdresa;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\EditWindows\SkolaEditWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Email;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\EditWindows\SkolaEditWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Telefon;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\EditWindows\SkolaEditWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbZiroRacun;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\EditWindows\SkolaEditWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbMaticniBroj;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\EditWindows\SkolaEditWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbPIB;
        
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
            System.Uri resourceLocater = new System.Uri("/SkolaJezikaWPF;component/editwindows/skolaeditwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\EditWindows\SkolaEditWindow.xaml"
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
            this.tbNaziv = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.tbAdresa = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.bSacuvaj = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\EditWindows\SkolaEditWindow.xaml"
            this.bSacuvaj.Click += new System.Windows.RoutedEventHandler(this.bSacuvaj_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.bOdustani = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\EditWindows\SkolaEditWindow.xaml"
            this.bOdustani.Click += new System.Windows.RoutedEventHandler(this.bOdustani_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.tbInternetAdresa = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.Email = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.Telefon = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.tbZiroRacun = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.tbMaticniBroj = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.tbPIB = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
