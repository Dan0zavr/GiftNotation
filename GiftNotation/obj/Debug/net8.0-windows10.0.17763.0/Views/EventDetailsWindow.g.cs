﻿#pragma checksum "..\..\..\..\Views\EventDetailsWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "D12B86BC74F8C2E41D805776A7FFBB1A2681FA38"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using GiftNotation.Converters;
using GiftNotation.Views;
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


namespace GiftNotation.Views {
    
    
    /// <summary>
    /// EventDetailsWindow
    /// </summary>
    public partial class EventDetailsWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 45 "..\..\..\..\Views\EventDetailsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextVisibilityForNameGift;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\..\..\Views\EventDetailsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock EnterDate;
        
        #line default
        #line hidden
        
        
        #line 99 "..\..\..\..\Views\EventDetailsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Tip_prasdnicaa;
        
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
            System.Uri resourceLocater = new System.Uri("/GiftNotation;component/views/eventdetailswindow.xaml", System.UriKind.Relative);
            
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
            
            #line 12 "..\..\..\..\Views\EventDetailsWindow.xaml"
            ((GiftNotation.Views.EventDetailsWindow)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TextVisibilityForNameGift = ((System.Windows.Controls.TextBox)(target));
            
            #line 47 "..\..\..\..\Views\EventDetailsWindow.xaml"
            this.TextVisibilityForNameGift.GotFocus += new System.Windows.RoutedEventHandler(this.GotFocus_Calendar);
            
            #line default
            #line hidden
            
            #line 48 "..\..\..\..\Views\EventDetailsWindow.xaml"
            this.TextVisibilityForNameGift.LostFocus += new System.Windows.RoutedEventHandler(this.LostFocus_Calendar);
            
            #line default
            #line hidden
            return;
            case 3:
            this.EnterDate = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.Tip_prasdnicaa = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            
            #line 272 "..\..\..\..\Views\EventDetailsWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

