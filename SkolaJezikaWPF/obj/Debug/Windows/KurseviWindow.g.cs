﻿#pragma checksum "..\..\..\Windows\KurseviWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "153D6B944B546480DA647D0005849F97"
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


namespace SkolaJezikaWPF.Windows {
    
    
    /// <summary>
    /// KurseviWindow
    /// </summary>
    public partial class KurseviWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 6 "..\..\..\Windows\KurseviWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgKursevi;
        
        #line default
        #line hidden
        
        
        #line 7 "..\..\..\Windows\KurseviWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bDodaj;
        
        #line default
        #line hidden
        
        
        #line 8 "..\..\..\Windows\KurseviWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bIzmeni;
        
        #line default
        #line hidden
        
        
        #line 9 "..\..\..\Windows\KurseviWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bObrisi;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\..\Windows\KurseviWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bZatvori;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\Windows\KurseviWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lbUcenici;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\Windows\KurseviWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbPretraga;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\Windows\KurseviWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbJezik;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Windows\KurseviWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbUcenik;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\Windows\KurseviWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbIme;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\Windows\KurseviWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbPrezime;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\Windows\KurseviWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbJMBG;
        
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
            System.Uri resourceLocater = new System.Uri("/SkolaJezikaWPF;component/windows/kurseviwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Windows\KurseviWindow.xaml"
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
            this.dgKursevi = ((System.Windows.Controls.DataGrid)(target));
            
            #line 6 "..\..\..\Windows\KurseviWindow.xaml"
            this.dgKursevi.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.dgKursevi_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.bDodaj = ((System.Windows.Controls.Button)(target));
            
            #line 7 "..\..\..\Windows\KurseviWindow.xaml"
            this.bDodaj.Click += new System.Windows.RoutedEventHandler(this.bDodaj_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.bIzmeni = ((System.Windows.Controls.Button)(target));
            
            #line 8 "..\..\..\Windows\KurseviWindow.xaml"
            this.bIzmeni.Click += new System.Windows.RoutedEventHandler(this.bIzmeni_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.bObrisi = ((System.Windows.Controls.Button)(target));
            
            #line 9 "..\..\..\Windows\KurseviWindow.xaml"
            this.bObrisi.Click += new System.Windows.RoutedEventHandler(this.bObrisi_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.bZatvori = ((System.Windows.Controls.Button)(target));
            
            #line 10 "..\..\..\Windows\KurseviWindow.xaml"
            this.bZatvori.Click += new System.Windows.RoutedEventHandler(this.bZatvori_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.lbUcenici = ((System.Windows.Controls.ListBox)(target));
            return;
            case 7:
            this.tbPretraga = ((System.Windows.Controls.TextBox)(target));
            
            #line 14 "..\..\..\Windows\KurseviWindow.xaml"
            this.tbPretraga.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.tbPretraga_TextChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.rbJezik = ((System.Windows.Controls.RadioButton)(target));
            
            #line 16 "..\..\..\Windows\KurseviWindow.xaml"
            this.rbJezik.Click += new System.Windows.RoutedEventHandler(this.tbPretraga_TextChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            this.rbUcenik = ((System.Windows.Controls.RadioButton)(target));
            
            #line 17 "..\..\..\Windows\KurseviWindow.xaml"
            this.rbUcenik.Click += new System.Windows.RoutedEventHandler(this.tbPretraga_TextChanged);
            
            #line default
            #line hidden
            return;
            case 10:
            this.rbIme = ((System.Windows.Controls.RadioButton)(target));
            
            #line 18 "..\..\..\Windows\KurseviWindow.xaml"
            this.rbIme.Click += new System.Windows.RoutedEventHandler(this.tbPretraga_TextChanged);
            
            #line default
            #line hidden
            return;
            case 11:
            this.rbPrezime = ((System.Windows.Controls.RadioButton)(target));
            
            #line 19 "..\..\..\Windows\KurseviWindow.xaml"
            this.rbPrezime.Click += new System.Windows.RoutedEventHandler(this.tbPretraga_TextChanged);
            
            #line default
            #line hidden
            return;
            case 12:
            this.rbJMBG = ((System.Windows.Controls.RadioButton)(target));
            
            #line 20 "..\..\..\Windows\KurseviWindow.xaml"
            this.rbJMBG.Click += new System.Windows.RoutedEventHandler(this.tbPretraga_TextChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

