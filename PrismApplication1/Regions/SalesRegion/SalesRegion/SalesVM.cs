using System;
using System.Data;
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
using System.IO;
using System.IO.Packaging;
using System.Runtime.InteropServices;
using System.Windows.Documents;
using System.Windows.Media.Imaging;
using System.Windows.Xps;
using System.Windows.Xps.Packaging;
using PdfSharp.Pdf.Printing;
using SUT.PrintEngine;
using TSP100;

namespace SalesRegion
{
    public class SalesVM : ViewModelBase
    {
        public class WPF2PDF
        {
            private static int PixelsPerInch = 96;
            private static double PaperWidth = 8.5;
            private static int PaperHeight = 28;

            public static string CreatePDF(ref Grid rpt, string reportName)
            {



                XpsDocumentWriter writer;
                MemoryStream lMemoryStream = new MemoryStream();
                Package package = Package.Open(lMemoryStream, FileMode.Create);
                XpsDocument doc = new XpsDocument(package);
                DrawingVisual v = PrintVisual.GetVisual(ref rpt);
                // create XPS file based on a WPF Visual, and store it in a memorystream

                if (rpt.ActualWidth > PaperWidth)
                {


                    PageContent pageCnt = new PageContent();
                    FixedPage page;
                    // var oldParent = RemoveChild(rpt);
                    page = new FixedPage()
                    {
                        Height = rpt.ActualHeight,
                        Width = rpt.ActualWidth,
                    }; // {Height = (PaperWidth*PixelsPerInch), Width = (PaperHeight*PixelsPerInch), };
                    RenderTargetBitmap bmp = new RenderTargetBitmap((int)rpt.ActualWidth, (int)rpt.ActualHeight, 0, 0,
                        PixelFormats.Pbgra32);
                    bmp.Render(v);

                    Image image = new Image();
                    image.Source = bmp;
                    page.Children.Add(image);
                    // ((System.Windows.Markup.IAddChild) pageCnt).AddChild(page);


                    writer = XpsDocument.CreateXpsDocumentWriter(doc);
                    writer.Write(page);

                    //page.Children.Remove(rpt);
                    //AddChild(rpt, oldParent);
                }
                else
                {

                    writer = XpsDocument.CreateXpsDocumentWriter(doc);
                    writer.Write(v);
                }


                doc.Close();
                package.Close();

                var pdfXpsDoc = PdfSharp.Xps.XpsModel.XpsDocument.Open(lMemoryStream);
                string file = Path.Combine(
                    Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location),
                    reportName + ".pdf");

                PdfSharp.Xps.XpsConverter.Convert(pdfXpsDoc, file, 0);

                return file;
            }
        }

        public static class PdfFilePrinter
        {
            private const string PdfPrinterDriveName = "Microsoft Print To PDF";

            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
            private class DOCINFOA
            {
                [MarshalAs(UnmanagedType.LPStr)] public string pDocName;
                [MarshalAs(UnmanagedType.LPStr)] public string pOutputFile;
                [MarshalAs(UnmanagedType.LPStr)] public string pDataType;
            }

            [DllImport("winspool.drv", EntryPoint = "OpenPrinterA", SetLastError = true, CharSet = CharSet.Ansi,
                ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            private static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter,
                out IntPtr hPrinter, IntPtr pd);

            [DllImport("winspool.drv", EntryPoint = "ClosePrinter", SetLastError = true, ExactSpelling = true,
                CallingConvention = CallingConvention.StdCall)]
            private static extern bool ClosePrinter(IntPtr hPrinter);

            [DllImport("winspool.drv", EntryPoint = "StartDocPrinterA", SetLastError = true, CharSet = CharSet.Ansi,
                ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            private static extern int StartDocPrinter(IntPtr hPrinter, int level,
                [In, MarshalAs(UnmanagedType.LPStruct)]
                DOCINFOA di);

            [DllImport("winspool.drv", EntryPoint = "EndDocPrinter", SetLastError = true, ExactSpelling = true,
                CallingConvention = CallingConvention.StdCall)]
            private static extern bool EndDocPrinter(IntPtr hPrinter);

            [DllImport("winspool.drv", EntryPoint = "StartPagePrinter", SetLastError = true, ExactSpelling = true,
                CallingConvention = CallingConvention.StdCall)]
            private static extern bool StartPagePrinter(IntPtr hPrinter);

            [DllImport("winspool.drv", EntryPoint = "EndPagePrinter", SetLastError = true, ExactSpelling = true,
                CallingConvention = CallingConvention.StdCall)]
            private static extern bool EndPagePrinter(IntPtr hPrinter);

            [DllImport("winspool.drv", EntryPoint = "WritePrinter", SetLastError = true, ExactSpelling = true,
                CallingConvention = CallingConvention.StdCall)]
            private static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, int dwCount, out int dwWritten);

            public static void PrintXpsToPdf(byte[] bytes, string outputFilePath, string documentTitle)
            {
                // Get Microsoft Print to PDF print queue
                var pdfPrintQueue = GetMicrosoftPdfPrintQueue();

                // Copy byte array to unmanaged pointer
                var ptrUnmanagedBytes = Marshal.AllocCoTaskMem(bytes.Length);
                Marshal.Copy(bytes, 0, ptrUnmanagedBytes, bytes.Length);

                // Prepare document info
                var di = new DOCINFOA
                {
                    pDocName = documentTitle,
                    pOutputFile = outputFilePath,
                    pDataType = "RAW"
                };

                // Print to PDF
                var errorCode = SendBytesToPrinter(pdfPrintQueue.Name, ptrUnmanagedBytes, bytes.Length, di,
                    out var jobId);

                // Free unmanaged memory
                Marshal.FreeCoTaskMem(ptrUnmanagedBytes);

                // Check if job in error state (for example not enough disk space)
                var jobFailed = false;
                try
                {
                    var pdfPrintJob = pdfPrintQueue.GetJob(jobId);
                    if (pdfPrintJob.IsInError)
                    {
                        jobFailed = true;
                        pdfPrintJob.Cancel();
                    }
                }
                catch
                {
                    // If job succeeds, GetJob will throw an exception. Ignore it. 
                }
                finally
                {
                    pdfPrintQueue.Dispose();
                }

                if (errorCode > 0 || jobFailed)
                {
                    try
                    {
                        if (File.Exists(outputFilePath))
                        {
                            File.Delete(outputFilePath);
                        }
                    }
                    catch
                    {
                        // ignored
                    }
                }

                if (errorCode > 0)
                {
                    throw new Exception($"Printing to PDF failed. Error code: {errorCode}.");
                }

                if (jobFailed)
                {
                    throw new Exception("PDF Print job failed.");
                }
            }

            private static int SendBytesToPrinter(string szPrinterName, IntPtr pBytes, int dwCount,
                DOCINFOA documentInfo, out int jobId)
            {
                jobId = 0;
                var dwWritten = 0;
                var success = false;

                if (OpenPrinter(szPrinterName.Normalize(), out var hPrinter, IntPtr.Zero))
                {
                    jobId = StartDocPrinter(hPrinter, 1, documentInfo);
                    if (jobId > 0)
                    {
                        if (StartPagePrinter(hPrinter))
                        {
                            success = WritePrinter(hPrinter, pBytes, dwCount, out dwWritten);
                            EndPagePrinter(hPrinter);
                        }

                        EndDocPrinter(hPrinter);
                    }

                    ClosePrinter(hPrinter);
                }

                // TODO: The other methods such as OpenPrinter also have return values. Check those?

                if (success == false)
                {
                    return Marshal.GetLastWin32Error();
                }

                return 0;
            }

            private static PrintQueue GetMicrosoftPdfPrintQueue()
            {
                PrintQueue pdfPrintQueue = null;

                try
                {
                    using (var printServer = new PrintServer())
                    {
                        var flags = new[] { EnumeratedPrintQueueTypes.Local };
                        // FirstOrDefault because it's possible for there to be multiple PDF printers with the same driver name (though unusual)
                        // To get a specific printer, search by FullName property instead (note that in Windows, queue name can be changed)
                        pdfPrintQueue = printServer.GetPrintQueues(flags)
                            .FirstOrDefault(lq => lq.QueueDriver.Name == PdfPrinterDriveName);
                    }

                    if (pdfPrintQueue == null)
                    {
                        throw new Exception($"Could not find printer with driver name: {PdfPrinterDriveName}");
                    }

                    if (!pdfPrintQueue.IsXpsDevice)
                    {
                        throw new Exception(
                            $"PrintQueue '{pdfPrintQueue.Name}' does not understand XPS page description language.");
                    }

                    return pdfPrintQueue;
                }
                catch
                {
                    pdfPrintQueue?.Dispose();
                    throw;
                }
            }
        }

        private static SalesVM _instance;

       

        public static SalesVM Instance
        {
            get { return _instance; }
        }


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

            _instance = this;
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
                    GoToTransaction(((TransactionBase)SearchItem).TransactionNumber.ToString());

                }

            }

        }


        private void GoToTransaction(TransactionBase trn)
        {
            TransactionData = trn;
            if (TransactionData is Ticket) CloseTicket();
            TransactionData.RefreshData();
            CheckForOverage();
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
            try
            {
                
                if (!(TransactionData is Ticket) || batch == null) return;
                var tic = (Ticket) TransactionData;
                if (tic == null) return;
                if (tic.OpenClose == false) return;

                using (RMSModel rms = new RMSModel())
                {
                    var res = rms.TransactionBase.OfType<Ticket>().Include("TransactionEntry.Item.TicketSetup")
                        .Include("Station")
                        .Include("Cashier")
                        .Include("TenderEntryEx")
                        .Include("Batch")
                        .Include("Customer").FirstOrDefault(x => x.TransactionId == tic.TransactionId);
                    if (res.OpenClose == true)
                    {
                        res.CloseBatchId = batch.BatchId;
                        ((TicketEntry) res.TransactionEntry).EndDateTime = DateTime.Now;
                      
                        rms.SaveChanges();
                        rms.AcceptAllChanges();
                        TransactionData = res;
                        TransactionData.RefreshData();
                        RaisePropertyChanged(nameof(TransactionData));
                    }
                }

                CheckForOverage();
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        private void CheckForOverage()
        {
            if (TransactionData.TotalSales > 32.00)
                MessageBox.Show(
                    $"This ticket is total charge is ${TransactionData.TotalSales}. Please double check and Mark it for Accounts");
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
            InsertItemTransactionEntry(new TicketItem() { Description = "Delivery", });
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
          if(Environment.MachineName.ToUpper() != "Joseph-PC".ToUpper())
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

        public void Transaction2Pdf(ref Grid fwe)
        {
           
            if (!Directory.Exists($@"{AppDomain.CurrentDomain.BaseDirectory}\Archieve"))
                Directory.CreateDirectory($@"{AppDomain.CurrentDomain.BaseDirectory}\Archieve");
            var fileName = $@"{AppDomain.CurrentDomain.BaseDirectory}\Archieve\{batch.BatchId}";
            //WPF2PDF.CreatePDF(ref fwe,fileName);

           
          


            Size visualSize;

            visualSize = new Size(fwe.ActualWidth, fwe.ActualHeight); // paper size
             fwe.Measure(visualSize);
            fwe.Arrange(new Rect(visualSize));
            fwe.UpdateLayout();

            DrawingVisual visual =
                PrintControlFactory.CreateDrawingVisual(fwe, fwe.ActualWidth, fwe.ActualHeight);


            SUT.PrintEngine.Paginators.VisualPaginator page = new SUT.PrintEngine.Paginators.VisualPaginator(
                visual, visualSize, new Thickness(0, 0, 0, 0), new Thickness(0, 0, 0, 0));
            page.Initialize(false);

            var ms = new MemoryStream();
            var package = Package.Open(ms, FileMode.Create);
            var doc = new XpsDocument(package);
            var writer = XpsDocument.CreateXpsDocumentWriter(doc);
            writer.Write(page);
            doc.Close();
            package.Close();

            // Get XPS file bytes
            var bytes = ms.ToArray();
            ms.Dispose();

            // Print to PDF

            PdfFilePrinter.PrintXpsToPdf(bytes, fileName + ".pdf", "");
        }

        public void GoToTransaction(string filterText)
        {
            using (var ctx = new RMSModel())
            {
                var res = ctx.TransactionBase.Include(x => x.TransactionEntry)
                    .Include(x => x.Station)
                    .Include(x => x.Cashier)
                    .Include(x => x.TransactionEntry.Item.TicketSetup)
                    .FirstOrDefault(x => x.TransactionNumber.EndsWith(filterText));
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
                            ctx.Item.OfType<StockItem>().ToList()
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
