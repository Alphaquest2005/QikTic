using System;
using System.Data.Objects;
using System.Linq;
using System.Printing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using BarCodes.UPCA;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using PrismMVVMLibrary;
using RMSDataAccessLayer;
using SUT.PrintEngine.Paginators;
using SUT.PrintEngine.Utils;
using System.Data.Entity;
using TSP100;

namespace SalesRegion
{
    public class SalesVM : ViewModelBase
    {
        private readonly IUnityContainer container;
        private readonly IEventAggregator eventAggregator;




        //+ Example Command
        public DelegateCommand ExampleCommand { get; set; }

        IRegionManager regionManager;


   //public RMSModel rms = new RMSModel();

   Cashier ca; Batch batch;  Station station;


        public SalesVM(IUnityContainer container, IEventAggregator eventAggregator, IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            this.container = container;
            this.eventAggregator = eventAggregator;


            StartUp();

        }

        private void StartUp()
        {
            using (RMSModel rms = new RMSModel())
            {
                ca = (from c in rms.CashierLogs
                      where c.MachineName == Environment.MachineName && c.Status == "LogIn"
                      orderby c.LoginTime descending
                      select c.Cashier).FirstOrDefault();


                station = (from s in rms.Stations.Include("Store").Include("Store.Company")
                           where s.MachineName == Environment.MachineName
                           select s).FirstOrDefault();

                batch = rms.Batches
                            .Include("Transactions.TransactionEntry.Item.TicketSetup")
                            .Include("ClosedTransactions.TransactionEntry.Item.TicketSetup")
                            .FirstOrDefault(b => b.StationId == station.StationId && b.Status == "Open" && b.OpeningCashier == ca.Id);
            }
           

            UpdateSearchList();
        }



      

    

       

        public void CreateNewTransaction<T>() where T : TransactionBase
        {
            
                TransactionBase txn;
                if (typeof(T) == typeof(TransactionBase))
                {
                    txn = new Transaction();
                }
                else
                {

                    txn = (T)Activator.CreateInstance(typeof(T));
                }

            //create a dummy and save it then deep copy to new type and don't save


            //if (TransactionNumber != finaltxn) TransactionNumber = finaltxn;
            //
            using (RMSModel rms = new RMSModel())
            {
                rms.Attach(station);
                rms.Attach(ca);
                rms.Attach(batch);

                rms.TransactionBase.AddObject(txn);
                txn.BatchId = batch.BatchId;
                txn.Batch = batch;
                txn.StationId = station.StationId;
                txn.Station = station;
                txn.CashierId = ca.Id;
                txn.StoreCode = station.Store.StoreCode;
                txn.Time = DateTime.Now;
                txn.CashierId = ca.Id;
                txn.Cashier = ca;

                var te = new TenderEntryEx();

                txn.TenderEntryEx.Add(te);
                txn.TransactionNumber = "0";
                rms.SaveChanges();
                txn.TransactionNumber = CreateTxnNumber(txn);
                rms.SaveChanges();
            }
            // SaveTransaction();                             
        // txn.TransactionNumber = CreateTxnNumber(txn);

        // SaveTransaction();
        //TransactionData.Cashier = ca;
        TransactionData = txn;
        }

        public T CreateNewEntity<T>() where T : class
        {

            T obj = (T)Activator.CreateInstance(typeof(T)); 

                return obj;
           
        }

        private string CreateTxnNumber(TransactionBase txn)
        {
            cUPCA barcode = new cUPCA();
            string txnnumber = (station.Store.TransactionSeed + (txn.TransactionId - station.Store.SeedTransaction)).ToString().PadLeft(11, '0');
            string finaltxn = txnnumber + barcode.GetCheckSum(txnnumber).ToString();
            return finaltxn;
        }

        public Boolean SaveTransaction()
        {
            try
            {
                if (TransactionData == null) return true;
                using (RMSModel rms = new RMSModel())
                {
                    if (TransactionData.EntityKey.IsTemporary == true)
                    {
                        rms.TransactionBase.AddObject(TransactionData);
                    }
                    else
                    {
                       rms.TransactionBase.Attach(TransactionData);
                    }
                    
                    rms.SaveChanges();

                    var txnlist = (from t in rms.TransactionBase
                                   where t.TransactionNumber == "000000000000"
                                   select t);
                    foreach (TransactionBase txn in txnlist)
                    {
                        txn.TransactionNumber = CreateTxnNumber(txn);
                    }

                    rms.SaveChanges();
                    //UpdateSearchList();
                }


                    return true;
                
            }
            catch (Exception e)
            {


               // rms.Dispose();
               // rms = new RMSModel();
                StartUp();
                return false;
            }

        }

    
        private TransactionBase transactionData;
        public TransactionBase TransactionData
        {
            get { return transactionData; }
            set
            {
                if (!Equals(transactionData, value))
                {
                    transactionData = value;
                    this.regionManager.Regions["HeaderRegion"].Context = transactionData;
                    RaisePropertyChanged(() => TransactionData);
                }
            }
        }


        private ListCollectionView _csv;
        public ListCollectionView SearchList
        {
            get { return _csv; }
           
        }
        public void UpdateSearchList()
        {
            CompositeCollection cc = CreateSearchList();

            _csv = new ListCollectionView(cc);
            RaisePropertyChanged(() => SearchList);
            
        }

        private CompositeCollection CreateSearchList()
        {
            CompositeCollection cc = new CompositeCollection();

            AddInventory(cc);
            AddTransaction(cc);
           
           

            return cc;
        }


        private void AddTransaction(CompositeCollection cc)
        {

            using (RMSModel rms = new RMSModel())
            {
                rms.Attach(station);
                rms.Attach(batch);
                rms.Attach(ca);

               
                rms.TransactionEntryBase.MergeOption = MergeOption.OverwriteChanges;
                var opnlst = rms.TransactionBase.OfType<Ticket>()
                            .Include("TransactionEntry.Item.TicketSetup")
                            .Where(z => EntityFunctions.TruncateTime(z.Time) == EntityFunctions.TruncateTime(DateTime.Now))
                            .OrderBy(x => x.TransactionId); 
                    
                            //(from trn in rms.TransactionEntryBase.OfType<TicketEntry>().Include("Transaction")
                            //    where EntityFunctions.TruncateTime(trn.StartDateTime) == EntityFunctions.TruncateTime(DateTime.Now)// && trn.EndDateTime == null// trn.EndDateTime == null ||
                            //    orderby trn.TransactionTime
                            //    select trn.Transaction);


                foreach (var trns in opnlst)
                {
                    trns.Station = station;
                    trns.Batch = batch;
                    trns.Cashier = ca;
                    if (trns?.TransactionEntry != null)
                    {
                        ((TicketItem)trns?.TransactionEntry?.Item).TicketSetupReference.Load();
                    }
                    cc.Add(trns);
                }

                var transLst = rms.TransactionBase.OfType<Transaction>()
                    .Include("TransactionEntry.Item")
                    .Where(z => EntityFunctions.TruncateTime(z.Time) == EntityFunctions.TruncateTime(DateTime.Now))
                    .OrderBy(x => x.TransactionId);

                foreach (var trns in transLst)
                {
                    trns.Station = station;
                    trns.Batch = batch;
                    trns.Cashier = ca;
                    cc.Add(trns);
                }
            }
        }

       private void AddInventory(CompositeCollection cc)
        {
            using (RMSModel rms = new RMSModel())
            {
                
                    foreach (var itm in rms.Item.OfType<TicketItem>())
                    {
                        cc.Add(itm);
                    }
                    foreach (var itm in rms.Item.OfType<StockItem>())
                    {
                        cc.Add(itm);
                    }
                
            }
        }


        public void ProcessSearchListItem(object SearchItem)
        {

            if (SearchItem != null)
            {

                if (SearchItem is TicketItem)
                {
                    NewItemTransaction((TicketItem) SearchItem);
                    TransactionData = null;
                }
                if (SearchItem is StockItem)
                {
                    NewItemTransaction((StockItem) SearchItem);
                    GoToTransaction(TransactionData);
                }
                if (SearchItem is TransactionBase)
                {
                    GoToTransaction((TransactionBase) SearchItem);
                }

            }

        }


        private void GoToTransaction(TransactionBase trn)
        {
            TransactionData = trn;
            if (TransactionData is Ticket) CloseTicket();
            TransactionData.RefreshData();
        }


        private void InsertItemTransactionEntry(TicketItem itm)
        {
            CreateTransactionEntry<TicketEntry>(itm);
            SaveTransaction();

           
            
        }

        private void InsertItemTransactionEntry(StockItem itm)
        {
           
            CreateTransactionEntry<TransactionEntry>(itm);
        }

        private void CreateTransactionEntry<T>(Item itm) where T: TransactionEntryBase
        {
            using (var rms = new RMSModel())
            {
                rms.Attach(TransactionData);
                T tkt = rms.CreateObject<T>();
                var rItm = rms.Item.Include(x => x.TicketSetup).FirstOrDefault(x => x.Description == itm.Description);
                if (rItm == null)
                {
                    MessageBox.Show($"Add Item {itm.Description}");
                    return;
                }
                tkt.ItemId = rItm.ItemId;
                tkt.Item = rItm;
                if (typeof (T) == typeof (TicketEntry))
                {
                    (tkt as TicketEntry).StartDateTime = DateTime.Now;
                   
                       ((Ticket)TransactionData).OpenClose = true;
                   
                }
               
                tkt.Price = rItm.Price;
                tkt.SalesTaxPercent = .15;
                TransactionData.TransactionEntry = tkt;
                RaisePropertyChanged(nameof(TransactionData));
                rms.SaveChanges();
            }  
        }

       

        public void CloseTicket()
        {
            if (!(TransactionData is Ticket) || batch == null) return;
            var tic = (Ticket) TransactionData;
            if (tic.OpenClose == false) return;

            using (RMSModel rms = new RMSModel())
            {
                rms.Attach(tic);
                tic.CloseBatchId = batch.BatchId;
                tic.OpenClose = false;
                ((TicketEntry) tic.TransactionEntry).EndDateTimeEx = DateTime.Now;
                RaisePropertyChanged(nameof(TransactionData));
                TransactionData.Status = "Closed";
                rms.SaveChanges();
            }
        }

        public void NewTicket()
        {
            //create new transaction
            
                CreateNewTransaction<Ticket>();
                InsertItemTransactionEntry(new TicketItem() {Description = "Ticket"});
            
        }

        public void NewDelivery()
        {
            CreateNewTransaction<Ticket>();
            InsertItemTransactionEntry(new TicketItem() { Description = "Delivery" });
        }

        public void NewTaxi()
        {
            CreateNewTransaction<Transaction>();
            InsertItemTransactionEntry(new StockItem() { Description = "Taxi" });
        }

        public void NewLostTicket()
        {
            CreateNewTransaction<Transaction>();
            InsertItemTransactionEntry(new StockItem() { Description = "Lost Ticket" });
        }

        private void NewItemTransaction(TicketItem SearchItem)
        {
           
               CreateNewTransaction<Ticket>();
               InsertItemTransactionEntry(SearchItem);
        }
        private void NewItemTransaction(StockItem SearchItem)
        {
            
            CreateNewTransaction<Transaction>();
            InsertItemTransactionEntry(SearchItem);
            
        }

        public void Print(Ticket t)
        {
            // get status of printer and stuff
            PrintTSP100 tsp100 = new PrintTSP100();
             PrintServer printserver = new PrintServer(station.PrintServer);
          
            tsp100.PrintTicket(t, TransactionData.Station.ReceiptPrinterName);

        }

        public void Print(Transaction t)
        {
            // get status of printer and stuff
            PrintTSP100 tsp100 = new PrintTSP100();
            PrintServer printserver = new PrintServer(station.PrintServer);

            tsp100.PrintTicket(t, TransactionData.Station.ReceiptPrinterName);

        }

        public void Print(ref Grid fwe)
        {
            if (TransactionData == null) return;
            LocalPrintServer printServer = new LocalPrintServer();
            if (station.PrintServer == null) return;
            PrintServer printserver = new PrintServer(station.PrintServer);


            var visualSize = new Size(fwe.ActualWidth, fwe.ActualHeight);
           
            DrawingVisual visual = PrintControlFactory.CreateDrawingVisual(fwe, fwe.ActualWidth, fwe.ActualHeight);


            VisualPaginator page = new VisualPaginator(visual, visualSize, new Thickness(0, 0, 0, 0), new Thickness(0, 0, 0, 0));
            page.Initialize(false);

            PrintDialog pd = new PrintDialog();
            pd.PrintQueue = printserver.GetPrintQueue(TransactionData.Station.ReceiptPrinterName);

          //  pd.PrintQueue = printserver.GetPrintQueue("TSC TDP-244");
          //  pd.PrintQueue = printServer.GetPrintQueues(new [] {EnumeratedPrintQueueTypes.Shared} );

            //if (pd.ShowDialog()==true)
            //{

                pd.PrintDocument(page, "");
            //}
        }


        public void GotoTransaction(string filterText)
        {
            using (var ctx = new RMSModel())
            {
                var res = ctx.TransactionBase.Include(x => x.TransactionEntry).Include(x => x.TransactionEntry.Item.TicketSetup).FirstOrDefault(x => x.TransactionNumber.Contains(filterText));
                if(res != null) GoToTransaction(res);
            }
        }

        public bool IsSpecialTicketAvailable()
        {
            return SpecialTicket != null;
        }

        public void NewSpecialTicket()
        {
                CreateNewTransaction<Transaction>();
                InsertItemTransactionEntry(SpecialTicket);
        }

        public void CreateSpecialTicket(string name, double price)
        {
            using (var ctx = new RMSModel())
            {
                SpecialTicket = ctx.Item.OfType<StockItem>().FirstOrDefault(x => x.Description == name);
                if (SpecialTicket == null)
                {
                    var itm = new StockItem() {Description = name, Price = price, Quantity = 1, ItemLookupCode = name, ExtendedDescription = name, SalesTax = .15, DateCreated = DateTime.Now};
                    ctx.Item.AddObject(itm);
                    ctx.SaveChanges();
                    SpecialTicket = ctx.Item.OfType<StockItem>().FirstOrDefault(x => x.Description == name);
                }
            }
            NewSpecialTicket();
        }

        private StockItem _specialTicket = null;

        public StockItem SpecialTicket
        {
            get
            {
                if (_specialTicket == null)
                {
                    using (var ctx = new RMSModel())
                    {
                        var res =
                            ctx.Item.OfType<StockItem>()
                                .FirstOrDefault(x => x.DateCreated.GetValueOrDefault().Date == DateTime.Today.Date);
                        if (res != null) _specialTicket = res;
                    }
                }
                return _specialTicket;
            }
            private set { _specialTicket = value; }
        }
    }
}
