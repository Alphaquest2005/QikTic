﻿#pragma checksum "..\..\SalesTaskPad.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "ADAE1040CBC4E3F55BF707C09E38AE19"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using BarCodes;
using Microsoft.Windows.Themes;
using RMSDataAccessLayer;
using SalesRegion;
using System;
using System.Data.Objects;
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


namespace SalesRegion {
    
    
    /// <summary>
    /// SalesTaskPad
    /// </summary>
    public partial class SalesTaskPad : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 487 "..\..\SalesTaskPad.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border SalesPad;
        
        #line default
        #line hidden
        
        
        #line 516 "..\..\SalesTaskPad.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ColumnDefinition EntryCol;
        
        #line default
        #line hidden
        
        
        #line 517 "..\..\SalesTaskPad.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ColumnDefinition TotalsCol;
        
        #line default
        #line hidden
        
        
        #line 518 "..\..\SalesTaskPad.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ColumnDefinition PaymentCol;
        
        #line default
        #line hidden
        
        
        #line 519 "..\..\SalesTaskPad.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ColumnDefinition ChangeCol;
        
        #line default
        #line hidden
        
        
        #line 520 "..\..\SalesTaskPad.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ColumnDefinition PrintCol;
        
        #line default
        #line hidden
        
        
        #line 521 "..\..\SalesTaskPad.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ColumnDefinition ReceiptCol;
        
        #line default
        #line hidden
        
        
        #line 523 "..\..\SalesTaskPad.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid TransactionGrd;
        
        #line default
        #line hidden
        
        
        #line 533 "..\..\SalesTaskPad.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal SalesRegion.FilterControl SearchBox;
        
        #line default
        #line hidden
        
        
        #line 546 "..\..\SalesTaskPad.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SearchBtn;
        
        #line default
        #line hidden
        
        
        #line 558 "..\..\SalesTaskPad.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ContentControl ItemEditor;
        
        #line default
        #line hidden
        
        
        #line 565 "..\..\SalesTaskPad.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TransStatusTxt;
        
        #line default
        #line hidden
        
        
        #line 580 "..\..\SalesTaskPad.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView SearchListCtl;
        
        #line default
        #line hidden
        
        
        #line 688 "..\..\SalesTaskPad.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas ReceiptCanvas;
        
        #line default
        #line hidden
        
        
        #line 689 "..\..\SalesTaskPad.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid ReceiptGrd;
        
        #line default
        #line hidden
        
        
        #line 1141 "..\..\SalesTaskPad.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid TotalsGrd;
        
        #line default
        #line hidden
        
        
        #line 1195 "..\..\SalesTaskPad.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TotalSalesTxt;
        
        #line default
        #line hidden
        
        
        #line 1246 "..\..\SalesTaskPad.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid TenderOptionsGrd;
        
        #line default
        #line hidden
        
        
        #line 1253 "..\..\SalesTaskPad.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CashTxt;
        
        #line default
        #line hidden
        
        
        #line 1282 "..\..\SalesTaskPad.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CheckTxt;
        
        #line default
        #line hidden
        
        
        #line 1312 "..\..\SalesTaskPad.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CreditTxt;
        
        #line default
        #line hidden
        
        
        #line 1341 "..\..\SalesTaskPad.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AccountTxt;
        
        #line default
        #line hidden
        
        
        #line 1370 "..\..\SalesTaskPad.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PaymentInfo;
        
        #line default
        #line hidden
        
        
        #line 1385 "..\..\SalesTaskPad.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid ChangeGrd;
        
        #line default
        #line hidden
        
        
        #line 1403 "..\..\SalesTaskPad.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TotalChangeTxt;
        
        #line default
        #line hidden
        
        
        #line 1426 "..\..\SalesTaskPad.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid PrintGrd;
        
        #line default
        #line hidden
        
        
        #line 1433 "..\..\SalesTaskPad.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button PrintBtn;
        
        #line default
        #line hidden
        
        
        #line 1445 "..\..\SalesTaskPad.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock NextBtn;
        
        #line default
        #line hidden
        
        
        #line 1469 "..\..\SalesTaskPad.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid InputBox;
        
        #line default
        #line hidden
        
        
        #line 1485 "..\..\SalesTaskPad.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NameTxt;
        
        #line default
        #line hidden
        
        
        #line 1492 "..\..\SalesTaskPad.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PriceTxt;
        
        #line default
        #line hidden
        
        
        #line 1499 "..\..\SalesTaskPad.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button YesButton;
        
        #line default
        #line hidden
        
        
        #line 1504 "..\..\SalesTaskPad.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button NoButton;
        
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
            System.Uri resourceLocater = new System.Uri("/SalesRegion;component/salestaskpad.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\SalesTaskPad.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            case 4:
            this.SalesPad = ((System.Windows.Controls.Border)(target));
            
            #line 502 "..\..\SalesTaskPad.xaml"
            this.SalesPad.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.SalesPad_PreviewKeyDown_1);
            
            #line default
            #line hidden
            return;
            case 5:
            this.EntryCol = ((System.Windows.Controls.ColumnDefinition)(target));
            return;
            case 6:
            this.TotalsCol = ((System.Windows.Controls.ColumnDefinition)(target));
            return;
            case 7:
            this.PaymentCol = ((System.Windows.Controls.ColumnDefinition)(target));
            return;
            case 8:
            this.ChangeCol = ((System.Windows.Controls.ColumnDefinition)(target));
            return;
            case 9:
            this.PrintCol = ((System.Windows.Controls.ColumnDefinition)(target));
            return;
            case 10:
            this.ReceiptCol = ((System.Windows.Controls.ColumnDefinition)(target));
            return;
            case 11:
            this.TransactionGrd = ((System.Windows.Controls.Grid)(target));
            return;
            case 12:
            this.SearchBox = ((SalesRegion.FilterControl)(target));
            return;
            case 13:
            this.SearchBtn = ((System.Windows.Controls.Button)(target));
            
            #line 552 "..\..\SalesTaskPad.xaml"
            this.SearchBtn.Click += new System.Windows.RoutedEventHandler(this.SearchBtn_Click);
            
            #line default
            #line hidden
            return;
            case 14:
            this.ItemEditor = ((System.Windows.Controls.ContentControl)(target));
            return;
            case 15:
            this.TransStatusTxt = ((System.Windows.Controls.TextBlock)(target));
            
            #line 575 "..\..\SalesTaskPad.xaml"
            this.TransStatusTxt.LostFocus += new System.Windows.RoutedEventHandler(this.TransStatusTxt_LostFocus_1);
            
            #line default
            #line hidden
            return;
            case 16:
            this.SearchListCtl = ((System.Windows.Controls.ListView)(target));
            
            #line 587 "..\..\SalesTaskPad.xaml"
            this.SearchListCtl.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.SearchListCtl_MouseLeftButtonUp_1);
            
            #line default
            #line hidden
            return;
            case 17:
            
            #line 606 "..\..\SalesTaskPad.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.NewLostTicket);
            
            #line default
            #line hidden
            return;
            case 18:
            
            #line 622 "..\..\SalesTaskPad.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.NewSpecialTicket);
            
            #line default
            #line hidden
            return;
            case 19:
            
            #line 639 "..\..\SalesTaskPad.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.NewTicket);
            
            #line default
            #line hidden
            return;
            case 20:
            
            #line 652 "..\..\SalesTaskPad.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.NewTaxi);
            
            #line default
            #line hidden
            return;
            case 21:
            
            #line 669 "..\..\SalesTaskPad.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.NewDelivery);
            
            #line default
            #line hidden
            return;
            case 22:
            this.ReceiptCanvas = ((System.Windows.Controls.Canvas)(target));
            return;
            case 23:
            this.ReceiptGrd = ((System.Windows.Controls.Grid)(target));
            return;
            case 24:
            this.TotalsGrd = ((System.Windows.Controls.Grid)(target));
            return;
            case 25:
            this.TotalSalesTxt = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 26:
            this.TenderOptionsGrd = ((System.Windows.Controls.Grid)(target));
            return;
            case 27:
            this.CashTxt = ((System.Windows.Controls.TextBox)(target));
            
            #line 1265 "..\..\SalesTaskPad.xaml"
            this.CashTxt.GotKeyboardFocus += new System.Windows.Input.KeyboardFocusChangedEventHandler(this.TextBox_GotKeyboardFocus_1);
            
            #line default
            #line hidden
            return;
            case 28:
            this.CheckTxt = ((System.Windows.Controls.TextBox)(target));
            
            #line 1294 "..\..\SalesTaskPad.xaml"
            this.CheckTxt.GotKeyboardFocus += new System.Windows.Input.KeyboardFocusChangedEventHandler(this.TextBox_GotKeyboardFocus_1);
            
            #line default
            #line hidden
            
            #line 1299 "..\..\SalesTaskPad.xaml"
            this.CheckTxt.TextInput += new System.Windows.Input.TextCompositionEventHandler(this.CheckTxt_TextInput_1);
            
            #line default
            #line hidden
            return;
            case 29:
            this.CreditTxt = ((System.Windows.Controls.TextBox)(target));
            
            #line 1324 "..\..\SalesTaskPad.xaml"
            this.CreditTxt.GotKeyboardFocus += new System.Windows.Input.KeyboardFocusChangedEventHandler(this.TextBox_GotKeyboardFocus_1);
            
            #line default
            #line hidden
            return;
            case 30:
            this.AccountTxt = ((System.Windows.Controls.TextBox)(target));
            
            #line 1353 "..\..\SalesTaskPad.xaml"
            this.AccountTxt.GotKeyboardFocus += new System.Windows.Input.KeyboardFocusChangedEventHandler(this.TextBox_GotKeyboardFocus_1);
            
            #line default
            #line hidden
            return;
            case 31:
            this.PaymentInfo = ((System.Windows.Controls.TextBox)(target));
            
            #line 1382 "..\..\SalesTaskPad.xaml"
            this.PaymentInfo.GotKeyboardFocus += new System.Windows.Input.KeyboardFocusChangedEventHandler(this.TextBox_GotKeyboardFocus_1);
            
            #line default
            #line hidden
            return;
            case 32:
            this.ChangeGrd = ((System.Windows.Controls.Grid)(target));
            return;
            case 33:
            this.TotalChangeTxt = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 34:
            this.PrintGrd = ((System.Windows.Controls.Grid)(target));
            return;
            case 35:
            this.PrintBtn = ((System.Windows.Controls.Button)(target));
            
            #line 1439 "..\..\SalesTaskPad.xaml"
            this.PrintBtn.Click += new System.Windows.RoutedEventHandler(this.PrintBtn_Click_1);
            
            #line default
            #line hidden
            return;
            case 36:
            this.NextBtn = ((System.Windows.Controls.TextBlock)(target));
            
            #line 1453 "..\..\SalesTaskPad.xaml"
            this.NextBtn.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.NextBtn_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 37:
            this.InputBox = ((System.Windows.Controls.Grid)(target));
            return;
            case 38:
            this.NameTxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 39:
            this.PriceTxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 40:
            this.YesButton = ((System.Windows.Controls.Button)(target));
            
            #line 1502 "..\..\SalesTaskPad.xaml"
            this.YesButton.Click += new System.Windows.RoutedEventHandler(this.YesButton_Click);
            
            #line default
            #line hidden
            return;
            case 41:
            this.NoButton = ((System.Windows.Controls.Button)(target));
            
            #line 1507 "..\..\SalesTaskPad.xaml"
            this.NoButton.Click += new System.Windows.RoutedEventHandler(this.NoButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 262 "..\..\SalesTaskPad.xaml"
            ((System.Windows.Controls.Grid)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Grid_MouseDown_1);
            
            #line default
            #line hidden
            break;
            case 2:
            
            #line 332 "..\..\SalesTaskPad.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CloseTick_Click_1);
            
            #line default
            #line hidden
            break;
            case 3:
            
            #line 350 "..\..\SalesTaskPad.xaml"
            ((System.Windows.Controls.Grid)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Grid_MouseDown_1);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

