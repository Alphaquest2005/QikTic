using RMSDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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
using BarCodes;

namespace SalesRegion
{
    /// <summary>
    /// Interaction logic for SalesView.xaml
    /// </summary>
    public partial class SalesView : UserControl
    {
        public SalesView(SalesVM salesVM)
        {
            InitializeComponent();
            DataContext = salesVM;
            salesvm = salesVM;
            SalesPad.SalesVM = salesVM;
            SalesPad.SalesView = this;
            
            salesVM.PropertyChanged += salesVM_PropertyChanged;
     
            HideChange();
            HideTender();
            HideReceipt();
            ShowTransaction();

            SetUpSalesPad();

        }

        private void SetUpSalesPad()
        {
         
            SalesPad.Margin = SalesPadMargin;
            Canvas.SetTop(SalesPad, 0);
            
        }

        void salesVM_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SearchList")
            {
                SalesPad.SearchListCtl.ItemsSource = salesvm.SearchList;
            }
        }




        enum PadPosition
        {
            Above,
            Middle,
            Below,
        }
        PadPosition padPos = PadPosition.Middle;
        
        Thickness SalesPadMargin = new Thickness(0, 0, 0, 0);

   
        SalesVM salesvm;
        FrameworkElement f;


        static SalesRegion.SalesPadTransState SalesPadState = SalesPadTransState.Transaction;
      
       
        private void HideCurrentSalesPadState()
        {
            if (SalesPadState == SalesPadTransState.Transaction) HideTransaction();
            if (SalesPadState == SalesPadTransState.Tender) HideTender();
            if (SalesPadState == SalesPadTransState.Change) HideChange();
            if (SalesPadState == SalesPadTransState.Receipt) HideReceipt();
        }

       
        public void GotoPreviousSalesStep()
        {
           
          PreviousTicketSaleStep();
                

        }

       

        private void PreviousTicketSaleStep()
        {
           //SalesLst.SelectedIndex = 0;
            if (SalesPadState == SalesPadTransState.Tender)//SalesPad.TotalsCol.Width == new GridLength(200) && SalesPad.EntryCol.Width == new GridLength(0)
            {
                HideTender();
                ShowTransaction();
                return;
            }

            if (SalesPadState == SalesPadTransState.Change)//SalesPad.TotalsCol.Width == new GridLength(0) && SalesPad.PaymentCol.Width == new GridLength(0)
            {
                HideChange();
                ShowTender();
                return;
            }
            if (SalesPadState == SalesPadTransState.Receipt)//SalesPad.TotalsCol.Width == new GridLength(0) && SalesPad.PaymentCol.Width == new GridLength(0)
            {
                HideReceipt();
                ShowChange();
                return;
            }
        }

        

        public void HideReceipt()
        {
            SalesPad.ReceiptCol.Width = new GridLength(0);
            SalesPad.ReceiptGrd.Visibility = System.Windows.Visibility.Hidden;
            SalesPad.PrintCol.Width = new GridLength(0);
            SalesPad.PrintGrd.Visibility = System.Windows.Visibility.Hidden;
        }
        public void ShowReceipt()
        {
            SalesPad.ReceiptCol.Width = new GridLength(400);
            SalesPad.ReceiptGrd.Visibility = System.Windows.Visibility.Visible;
            SalesPad.PrintCol.Width = new GridLength(200);
            SalesPad.PrintGrd.Visibility = System.Windows.Visibility.Visible;
            SalesTaskPad.MoveToNextControl(SalesPad.PrintGrd);
            SalesPadState = SalesPadTransState.Receipt;
        }

        public void HideChange()
        {
            SalesPad.ChangeCol.Width = new GridLength(0);
            SalesPad.ChangeGrd.Visibility = System.Windows.Visibility.Hidden;
            //SalesPad.PrintCol.Width = new GridLength(0);
            //SalesPad.PrintGrd.Visibility = System.Windows.Visibility.Hidden;
        }
        public void ShowChange()
        {
            SalesPad.ChangeCol.Width = new GridLength(400);
            SalesPad.ChangeGrd.Visibility = System.Windows.Visibility.Visible;
            //SalesPad.PrintCol.Width = new GridLength(200);
            //SalesPad.PrintGrd.Visibility = System.Windows.Visibility.Visible;
            SalesTaskPad.MoveToNextControl(SalesPad.PrintGrd);
            SalesPadState = SalesPadTransState.Change;
        }

        public void ShowTender()
        {
            SalesPad.TotalsCol.Width = new GridLength(200);
            SalesPad.TotalsGrd.Visibility = System.Windows.Visibility.Visible;
            SalesPad.PaymentCol.Width = new GridLength(400);
            SalesPad.TenderOptionsGrd.Visibility = System.Windows.Visibility.Visible;
            SalesTaskPad.MoveToNextControl(SalesPad.TenderOptionsGrd);
            SalesPadState = SalesPadTransState.Tender;
        }

        public void ShowTransaction()
        {
            SalesPad.EntryCol.Width = new GridLength(408);
            SalesPad.TransactionGrd.Visibility = System.Windows.Visibility.Visible;
            SalesPad.TotalsCol.Width = new GridLength(200);
            SalesPad.TotalsGrd.Visibility = System.Windows.Visibility.Visible;
           // SalesTaskPad.MoveToNextControl(SalesPad.TransactionGrd);
            SalesPad.SearchBox.Focus();
            SalesPadState = SalesPadTransState.Transaction;

        }

        public void GotoNextSalesStep(Key e)
        {
            //SalesLst.SelectedIndex = 0;

            NextTicketSalesSteps(e);
        }

        private void NextTicketSalesSteps(Key e)
        {
            if (SalesPadState == SalesPadTransState.Change && e == Key.Right)
            {
                HideChange();
                salesvm.SaveTransaction();
                ShowReceipt();
                return;
            }
            if ((SalesPadState == SalesPadTransState.Change) && e == Key.Enter)
            {
                HideChange();
                salesvm.CloseTicket();
                salesvm.CreateNewTransaction<Ticket>();
                ShowTransaction();
                return;
            }

            if ((SalesPadState == SalesPadTransState.Receipt) && (e == Key.Enter || e == Key.Right))
            {
                HideReceipt();
                salesvm.CloseTicket();
                salesvm.TransactionData = null;
               // salesvm.CreateNewTransaction<Ticket>();
                ShowTransaction();
                return;
            }

            if (SalesPadState == SalesPadTransState.Transaction)
            {
                
                if(salesvm.TransactionData != null && salesvm.TransactionData is Ticket && ((TicketEntry)salesvm.TransactionData.TransactionEntry).EndDateTime == null)
                {
                    MessageBox.Show("Please Close Ticket");
                    return;
                }

                HideTransaction();
                //ShowTender();
                ShowReceipt();

                return;
            }

            if (SalesPadState == SalesPadTransState.Tender)//SalesPad.EntryCol.Width == new GridLength(0) && SalesPad.TotalsCol.Width != new GridLength(0)
            {
                HideTender();
                ShowChange();

                return;
            }
        }

        

        public void HideTransaction()
        {
            SalesPad.EntryCol.Width = new GridLength(0);
            SalesPad.TransactionGrd.Visibility = System.Windows.Visibility.Hidden;
            SalesPad.TotalsCol.Width = new GridLength(0);
            SalesPad.TotalsGrd.Visibility = System.Windows.Visibility.Hidden;
            SalesRegion.SalesTaskPad.MoveToNextControl(SalesPad.TenderOptionsGrd);
        }

        public void HideTender()
        {
            SalesPad.TotalsCol.Width = new GridLength(0);
            SalesPad.TotalsGrd.Visibility = System.Windows.Visibility.Hidden;
            SalesPad.PaymentCol.Width = new GridLength(0);
            SalesPad.TenderOptionsGrd.Visibility = System.Windows.Visibility.Hidden;
        }

        
        private void UserControl_Unloaded_1(object sender, RoutedEventArgs e)
        {
            salesvm.SaveTransaction();
        }





        
    }
}