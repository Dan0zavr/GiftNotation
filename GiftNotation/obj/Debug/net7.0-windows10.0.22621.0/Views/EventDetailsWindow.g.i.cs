﻿#pragma checksum "..\..\..\..\Views\EventDetailsWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0035D8C7A974952E18E644B480D23DAA47919E9E"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

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
using виш_лист_попытка_33334;


namespace виш_лист_попытка_33334 {
    
    
    /// <summary>
    /// EventDetailsWindow
    /// </summary>
    public partial class EventDetailsWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\..\..\Views\EventDetailsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox VvodPogarkov;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\Views\EventDetailsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock EnterDate;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\Views\EventDetailsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Tip_prasdnicaa;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\..\Views\EventDetailsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel StackPanel_PeoplesAdd;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\..\Views\EventDetailsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Button_PlusPeople;
        
        #line default
        #line hidden
        
        
        #line 114 "..\..\..\..\Views\EventDetailsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel StackPanel_GifsAdd;
        
        #line default
        #line hidden
        
        
        #line 117 "..\..\..\..\Views\EventDetailsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Button_PlusGifts;
        
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
            System.Uri resourceLocater = new System.Uri("/GiftNotation;V1.0.0.0;component/views/eventdetailswindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\EventDetailsWindow.xaml"
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
            
            #line 11 "..\..\..\..\Views\EventDetailsWindow.xaml"
            ((виш_лист_попытка_33334.EventDetailsWindow)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.VvodPogarkov = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.EnterDate = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.Tip_prasdnicaa = ((System.Windows.Controls.ComboBox)(target));
            
            #line 39 "..\..\..\..\Views\EventDetailsWindow.xaml"
            this.Tip_prasdnicaa.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.StackPanel_PeoplesAdd = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 6:
            this.Button_PlusPeople = ((System.Windows.Controls.Button)(target));
            
            #line 52 "..\..\..\..\Views\EventDetailsWindow.xaml"
            this.Button_PlusPeople.Click += new System.Windows.RoutedEventHandler(this.Button_PlusPeople_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.StackPanel_GifsAdd = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 8:
            this.Button_PlusGifts = ((System.Windows.Controls.Button)(target));
            
            #line 117 "..\..\..\..\Views\EventDetailsWindow.xaml"
            this.Button_PlusGifts.Click += new System.Windows.RoutedEventHandler(this.Button_PlusGifts_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 187 "..\..\..\..\Views\EventDetailsWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
