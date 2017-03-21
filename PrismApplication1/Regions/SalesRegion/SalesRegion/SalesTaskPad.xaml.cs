using RMSDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Entity;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Objects.DataClasses;
using System.Drawing.Printing;
using System.Printing;
using System.Windows.Xps;
using SUT.PrintEngine;
using SUT.PrintEngine.Utils;
using System.IO;
using NSubstitute;


namespace SalesRegion
{

    /// <summary>
    /// Interaction logic for SalesTaskPad.xaml
    /// </summary>
    public partial class SalesTaskPad : UserControl
    {
        public SalesTaskPad()
        {
            InitializeComponent();
            this.DataContextChanged += SalesTaskPad_DataContextChanged;
            SearchBox.Focus();
          
        }

        //void SalesLst_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    ReBindItemEditor();
        //    SearchBox.Focus();
        //}

                 
        void SalesTaskPad_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            SearchBox.Focus();
            ReBindTranStatusTxt();
        }

        private void ReBindTranStatusTxt()
        {
            Binding myBinding = new Binding("Status");
            myBinding.Source = SalesVM.TransactionData;
            var TransStatusTxt = (FrameworkElement)SalesPad.FindName("TransStatusTxt");
            if (TransStatusTxt != null)
                TransStatusTxt.SetBinding(TextBlock.TextProperty, myBinding);
        }



        private void SalesPad_PreviewKeyDown_1(object sender, KeyEventArgs e)
        {

            var uie = e.OriginalSource as Control;

            if (uie == null) uie = SearchBox as Control;
            if (uie.Name == "PART_FilterBox")
            {
               

                if (e.Key == Key.Enter) //pkey == Key.Enter &&
                {
                    SearchBox.RaiseFilterEvent();
                    if (SearchListCtl.Items.Count == 1)
                        SearchListCtl.SelectedIndex = 0;
                    if (SearchListCtl.SelectedItem == null && SearchBox.FilterText != "")
                    {
                        SalesVM.GotoTransaction(SearchBox.FilterText);
                    }
                    (uie as TextBox).Text = "";
                    //e.Handled = true;
                    MoveToNextControl(uie);
                }

                return;
            }

            if (e.Key == Key.Enter)
            {
                // e.Handled = true;
                MoveToNextControl(uie);

                if (pkey == Key.Enter)
                {
                    SalesView.GotoNextSalesStep(Key.Right);
                    pkey = Key.None;
                }
            }

            pkey = e.Key;
        }

        public static void MoveToNextControl(object sender)
        {
            UIElement uie = sender as UIElement;
            uie.MoveFocus(
            new TraversalRequest(
            FocusNavigationDirection.Next));
        }

        private void FilterControl_Direction_1(object sender, DirectionEventArgs e)
        {
            if (e.Direction == DirectionEnum.Down)
            {
                SearchListCtl.SelectedIndex += 1;
            }
            if (e.Direction == DirectionEnum.Up && SearchListCtl.SelectedIndex > -1)
            {
                SearchListCtl.SelectedIndex -= 1;
            }
            if (e.Direction == DirectionEnum.Right)
            {

                MoveToNextControl(sender);
            }
        }
        static Key pkey;
        private void SearchBox_PreviewKeyDown_1(object sender, KeyEventArgs e)
        {
           
            
            if (SearchListCtl.Items.Count == 1)
                SearchListCtl.SelectedIndex = 0;

            if (e.Key == Key.Enter)
            {
                
                //select the item
                LocalProcesItem(SearchListCtl.SelectedItem);
               

                MoveToNextControl(sender);
            }
            if (pkey == Key.Enter && e.Key == Key.Enter)
            {
                SalesView.GotoNextSalesStep(e.Key);
            }

            pkey = e.Key;
           
        }

      
        private void LocalProcesItem(object itm)
        {
                if (itm == null) return;

                
                if (itm.GetType() == typeof(RMSDataAccessLayer.SearchItem))
                {
                    switch (((ISearchItem)itm).DisplayName)
                    {

                        default:
                            ItemEditor.Content = ((RMSDataAccessLayer.SearchItem)itm).SearchObject;
                            break;
                    }

                }
                else
                {
                    SalesVM.ProcessSearchListItem(itm);
                    MoveToNextControl(ItemEditor);
                }
        }


        SalesView _SalesView;
        public SalesView SalesView
        {
            get
            {
                return _SalesView;
            }
            set
            {
                _SalesView = value;
               
            }
        }

        SalesVM _SalesVM;
        public SalesVM SalesVM
        {
            get
            {
                return _SalesVM;
            }
            set
            {
                _SalesVM = value;
                SearchListCtl.ItemsSource = SalesVM.SearchList;
            }
        }






        private void SearchBox_Filter_1(object sender, FilterEventArgs e)
        {
            if (e.FilterText != "" && e.IsFilterApplied == false)
            {
                ShowSearchList();

            }
            if (e.FilterText == "")
            {
                HideSearchList();
               

            }
           
        }

        private void HideSearchList()
        {
            SearchListCtl.Visibility = System.Windows.Visibility.Collapsed;
            SearchListCtl.Focusable = false;
            SearchListCtl.SelectedIndex = -1;
        }

        private void ShowSearchList()
        {
            SalesVM.UpdateSearchList();
            SearchListCtl.Visibility = System.Windows.Visibility.Visible;
            SearchListCtl.Focusable = true;
            if (SearchListCtl.Items.Count == 1)
                SearchListCtl.SelectedIndex = 0;
        }



        private void TextBox_GotKeyboardFocus_1(object sender, KeyboardFocusChangedEventArgs e)
        {
            (sender as TextBox).SelectAll();
        }

        private void CheckTxt_TextInput_1(object sender, TextCompositionEventArgs e)
        {
            PaymentInfo.Visibility = System.Windows.Visibility.Visible;
            PaymentInfo.Text = "Enter CheckInfo Here!";

        }
        
        
        public void PrintBtn_Click_1(object sender, RoutedEventArgs e)
        {
            SalesVM.SaveTransaction();
            if (SalesVM.TransactionData == null) return;
            if (SalesVM.TransactionData != null && SalesVM.TransactionData.TransactionEntry == null) return;
            if (SalesVM.TransactionData is Ticket)
            {
                SalesVM.Print(SalesVM.TransactionData as Ticket);
                return;
            }
            if (SalesVM.TransactionData is Transaction)
            {
                SalesVM.Print(SalesVM.TransactionData as Transaction);
                return;
            }
            if (ReceiptCol.Width == new GridLength(0) )
            {
               // unhide the colums to print
                ReceiptCol.Width = new GridLength(400);
                ReceiptGrd.UpdateLayout();
                 SalesVM.Print(ref ReceiptGrd);
                 ReceiptCol.Width = new GridLength(0);
               //hide it back
            }
            else
            {
                SalesVM.Print(ref ReceiptGrd);
            }

            
         
        }




        private void CloseTick_Click_1(object sender, RoutedEventArgs e)
        {
           SalesVM.CloseTicket();
        }

    

        
        static bool focusswitch;
        private void TransStatusTxt_LostFocus_1(object sender, RoutedEventArgs e)
        {
            if (focusswitch == true)
            {
                ReBindTranStatusTxt();
            }
            
                focusswitch = !focusswitch;
           
        }

      
        private void Grid_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
LocalProcesItem(SearchListCtl.SelectedItem);
            MoveToNextControl(sender);
        }

        private void SearchListCtl_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            LocalProcesItem(SearchListCtl.SelectedItem);
            MoveToNextControl(sender);
            SearchBox.FilterText = "";
            HideSearchList();
            SearchBox.Focus();
        }


        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            ShowSearchList();
        }
       
       

        private void NextBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SalesView.GotoNextSalesStep(Key.Right);
        }
        private void NewTicket(object sender, RoutedEventArgs e)
        {
            var oldtrans = SalesVM.TransactionData;
            SalesVM.NewTicket();
            ProcessTicket(sender, oldtrans);



        }

        private void NewDelivery(object sender, RoutedEventArgs e)
        {
            var oldtrans = SalesVM.TransactionData;
            SalesVM.NewDelivery();
            ProcessTicket(sender, oldtrans);
        }

        private void ProcessTicket(object sender, TransactionBase oldtrans)
        {
            SalesView.HideTransaction();
            SalesView.ShowReceipt();
            SalesView.UpdateLayout();
            PrintBtn_Click_1(sender, null);
            SalesView.HideReceipt();
            SalesVM.TransactionData = oldtrans;
            SalesView.ShowTransaction();
        }

        private void NewTaxi(object sender, RoutedEventArgs e)
        {
            
            SalesVM.NewTaxi();
            ProcessTransaction(sender); ;
        }

        private void NewLostTicket(object sender, RoutedEventArgs e)
        {
            SalesVM.NewLostTicket();
            ProcessTransaction(sender);
        }

        private void ProcessTransaction(object sender)
        {
            SalesView.HideTransaction();
            SalesView.ShowReceipt();
            SalesView.UpdateLayout();
            PrintBtn_Click_1(sender, null);
            SalesView.HideReceipt();
            SalesView.ShowTransaction();
        }

        private void NewSpecialTicket(object sender, RoutedEventArgs e)
        {
            if (SalesVM.IsSpecialTicketAvailable())
            {
                SalesVM.NewSpecialTicket();
                ProcessTransaction(sender);
                PrintBtn_Click_1(null, null);
            }
            //else
            //{
            //    InputBox.Visibility = Visibility.Visible;
            //}
            
        }

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            SalesVM.CreateSpecialTicket(NameTxt.Text, Convert.ToDouble(PriceTxt.Text));
            InputBox.Visibility = Visibility.Hidden;
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            InputBox.Visibility = Visibility.Hidden;
        }
    }


}
