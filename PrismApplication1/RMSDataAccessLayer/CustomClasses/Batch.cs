using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RMSDataAccessLayer
{
    public partial class Batch
    {
        public Batch()
        {
            PropertyChanged += Batch_PropertyChanged;
            OnPropertyChanged(nameof(TotalChangeEx));
            OnPropertyChanged(nameof(EndingCashEx));
            OnPropertyChanged(nameof(TotalSalesEx));
            OnPropertyChanged(nameof(TotalTenderEx));
            OnPropertyChanged(nameof(TicketSales));
            OnPropertyChanged(nameof(DeliverySales));
            OnPropertyChanged(nameof(LostTicketSales));
            OnPropertyChanged(nameof(TaxiSales));
        }

        private void Batch_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "ClosingCasher") OnPropertyChanged("CloseCashier");
            
         
        }

        public IEnumerable<Ticket > Tickets => Transactions.OfType<Ticket>().Where(x => x.TransactionEntry?.Item?.Description == "Ticket");
        public IEnumerable<Ticket> ClosedParkingTickets => ClosedTransactions.OfType<Ticket>().Where(x => x.TransactionEntry?.Item?.Description == "Ticket" && x.OpenClose == false);
        public IEnumerable<Ticket> Deliveries => Transactions.OfType<Ticket>().Where(x => x.TransactionEntry?.Item?.Description == "Delivery");

        public IEnumerable<Ticket> ClosedDeliveries => ClosedTransactions.OfType<Ticket>().Where(x => x.TransactionEntry?.Item?.Description == "Delivery" && x.OpenClose == false);

        public IEnumerable<Transaction> Taxis => Transactions.OfType<Transaction>().Where(x => x.TransactionEntry?.Item?.Description == "Taxi");
        public IEnumerable<Transaction> LostTickets => Transactions.OfType<Transaction>().Where(x => x.TransactionEntry?.Item?.Description == "Lost Ticket");

        public IEnumerable<Transaction> SpecialTickets => Transactions.OfType<Transaction>().Where(x => x.TransactionEntry?.Item?.DateCreated.GetValueOrDefault().Date == DateTime.Today.Date);


        public Int32 OpenedTickets => Tickets.Union(Deliveries).Count(x => x?.OpenClose == true);
        public Int32 ClosedTickets => ClosedParkingTickets.Union(ClosedDeliveries).Count(x => x?.OpenClose == false);

        


        public double TicketSales => ClosedParkingTickets.Sum(x => x.TransactionEntry.Amount);
        public double DeliverySales => ClosedDeliveries.Sum(x => x.TransactionEntry.Amount);
        public double LostTicketSales => LostTickets.Sum(x => x.TransactionEntry.Amount);
        public double TaxiSales => Taxis.Sum(x => x.TransactionEntry.Amount);

        public double SpecialTicketSales => SpecialTickets.Sum(x => x.TransactionEntry.Amount);


        public double TotalTicketTender => Tickets.SelectMany(x => x.TenderEntryEx).Sum(z => z.CashAmount);
        public double TotalDeliveryTender => Deliveries.SelectMany(x => x.TenderEntryEx).Sum(z => z.CashAmount);
        public double TotalTaxiTender => Taxis.SelectMany(x => x.TenderEntryEx).Sum(z => z.CashAmount);
        public double TotalLostTicketTender => LostTickets.SelectMany(x => x.TenderEntryEx).Sum(z => z.CashAmount);
        public double TotalSpecialTicketTender => SpecialTickets.SelectMany(x => x.TenderEntryEx).Sum(z => z.CashAmount);


        public double TotalTenderEx => TotalTicketTender + TotalDeliveryTender + TotalTaxiTender + TotalLostTicketTender + TotalSpecialTicketTender;
        public double TotalSalesEx => TicketSales + DeliverySales + LostTicketSales + TaxiSales + SpecialTicketSales;
        public double EndingCashEx => OpeningCash + TotalSalesEx;


        public double TotalChangeEx => TotalTenderEx - TotalSalesEx;
      
    }
}
