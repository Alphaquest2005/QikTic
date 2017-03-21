using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using RMSDataAccessLayer;
using System.Printing;
//using StarMicronics.StarIO;



namespace TSP100
{
    public class PrintTSP100
    {

        public class RawPrinterHelper
        {
            // Structure and API declarions:
            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
            public class DOCINFOA
            {
                [MarshalAs(UnmanagedType.LPStr)]
                public string pDocName;
                [MarshalAs(UnmanagedType.LPStr)]
                public string pOutputFile;
                [MarshalAs(UnmanagedType.LPStr)]
                public string pDataType;
            }
            [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter, out IntPtr hPrinter, IntPtr pd);

            [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool ClosePrinter(IntPtr hPrinter);

            [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool StartDocPrinter(IntPtr hPrinter, Int32 level, [In, MarshalAs(UnmanagedType.LPStruct)] DOCINFOA di);

            [DllImport("winspool.Drv", EntryPoint = "EndDocPrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool EndDocPrinter(IntPtr hPrinter);

            [DllImport("winspool.Drv", EntryPoint = "StartPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool StartPagePrinter(IntPtr hPrinter);

            [DllImport("winspool.Drv", EntryPoint = "EndPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool EndPagePrinter(IntPtr hPrinter);

            [DllImport("winspool.Drv", EntryPoint = "WritePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, Int32 dwCount, out Int32 dwWritten);

            // SendBytesToPrinter()
            // When the function is given a printer name and an unmanaged array
            // of bytes, the function sends those bytes to the print queue.
            // Returns true on success, false on failure.
            public static bool SendBytesToPrinter(string szPrinterName, IntPtr pBytes, Int32 dwCount)
            {
                Int32 dwError = 0, dwWritten = 0;
                IntPtr hPrinter = new IntPtr(0);
                DOCINFOA di = new DOCINFOA();
                bool bSuccess = false; // Assume failure unless you specifically succeed.

                di.pDocName = "Ticket";
                di.pDataType = "RAW";

                // Open the printer.
                if (OpenPrinter(szPrinterName.Normalize(), out hPrinter, IntPtr.Zero))
                {
                    // Start a document.
                    if (StartDocPrinter(hPrinter, 1, di))
                    {
                        // Start a page.
                        if (StartPagePrinter(hPrinter))
                        {
                            // Write your bytes.
                            bSuccess = WritePrinter(hPrinter, pBytes, dwCount, out dwWritten);
                            EndPagePrinter(hPrinter);
                        }
                        EndDocPrinter(hPrinter);
                    }
                    ClosePrinter(hPrinter);
                }
                // If you did not succeed, GetLastError may give more information
                // about why not.
                if (bSuccess == false)
                {
                    dwError = Marshal.GetLastWin32Error();
                }
                return bSuccess;
            }


            public static bool SendStringToPrinter(string szPrinterName, string szString)
            {
                IntPtr pBytes;
                Int32 dwCount;
                // How many characters are in the string?
                dwCount = szString.Length;
                // Assume that the printer is expecting ANSI text, and then convert
                // the string to ANSI text.
                pBytes = Marshal.StringToCoTaskMemAnsi(szString);
                // Send the converted ANSI string to the printer.
                SendBytesToPrinter(szPrinterName, pBytes, dwCount);
                Marshal.FreeCoTaskMem(pBytes);
                return true;
            }
        }


        public void PrintTicket(Ticket ticket, string PrinterName)
        {
            TicketEntry ticketentry = (TicketEntry) ticket.TransactionEntry;


            string buffer = "\x1b\x1d\x61\x1";             //Center Alignment - Refer to Pg. 3-29
            //buffer = buffer + "\x5B" + "If loaded.. Logo1 goes here" + "\x5D\n";
            //buffer = buffer + "\x1B\x1C\x70\x1\x0";          //Stored Logo Printing - Refer to Pg. 3-38

            buffer = buffer + "\x1b\x69\x1\x1" + "Grenreal" + "\x1b\x69\x0\x0" + "\n";
            buffer = buffer + "Property Corperation Ltd\n";
            buffer = buffer + "Bruce Street, St. George's\n";
            buffer = buffer + "Tel: +1 473 435-8372, Fax: +1 473 435-8373 \n";
            buffer = buffer + "VAT#: 1601993 \n\n";
            buffer = buffer + "------------------------------------------------ \n";
            buffer = buffer + "\x1b\x62\x6\x2\x2" + ticket.TransactionNumber + "\x1e\n";             //Barcode - Pg. 3-39 - 3-40
            buffer = buffer + "\x1b\x1d\x61\x0";             //Left Alignment - Refer to Pg. 3-29
            buffer = buffer + "\x1b\x44\x2\x10\x22\x0";      //Setting Horizontal Tab - Pg. 3-27
            buffer = buffer + "\x1b\x45";                    //Select Emphasized Printing - Pg. 3-14
                                                             //  buffer = buffer + "Entry Time: " + TransactionDate.ToShortDateString() + "\x9" + " Time: " + TransactionDate.ToString("hh:mm") + "\n";      //Moving Horizontal Tab - Pg. 3-26
            buffer = buffer + "\x1b\x69\x1\x1" + ticketentry.Item.ExtendedDescription + "\x1b\x69\x0\x0" + "\n";
            buffer = buffer + "------------------------------------------------ \n";

            //buffer = buffer + "\x1b\x45";                    //Select Emphasized Printing - Pg. 3-14
            buffer = buffer + "Cashier: " + "\x9  " + ticket.Cashier.Intitals + "\n";
            buffer = buffer + "Station: " + "\x9  " + ticket.Station.StationCode + "\n";
            if (ticketentry.VehicleNumber != null) buffer = buffer + "Vehicle#: " + "\x9  " + ticketentry.VehicleNumber + "\n";
            if (ticketentry.Item.Description == "Delivery")
            {
                buffer = buffer + "[] Celina's      [] DutyFree CB\n";
                buffer = buffer + "[] S.Traditions  [] Ganzee\n";
                buffer = buffer + "[] Subway        [] K-Star\n";
                buffer = buffer + "[] NY Bagles     [] Bar. Shop\n";
                buffer = buffer + "\n";
                buffer = buffer + "Other:______________________\n";
                buffer = buffer + "\n";
                buffer = buffer + "Tenent:\n";
                buffer = buffer + "\n";
                buffer = buffer + "------------------------------------------------ \n";
                buffer = buffer + "\n";
                buffer = buffer + "Delivery\n";
                buffer = buffer + "Agent:\n";
                buffer = buffer + "------------------------------------------------ \n";
            }

            buffer = buffer + "\x1b\x46";                    //Cancel Emphasized Printing - Pg. 3-14

            if (ticketentry.EndDateTime != null)
            {
                buffer = buffer + "Entry Time: " + "\x9  " + ticketentry.StartDateTime.ToString("M/d/yyyy h:mm:ss tt") + "\n";
                buffer = buffer + "Departure Time: " + "\x6  " + ((DateTime)ticketentry.EndDateTime).ToString("M/d/yyyy h:mm:ss tt") + "\n";
                buffer = buffer + "Duration: " + "\x9  " + String.Format("{0} Hours:{1} Min:{2} Sec", ticketentry.Quantity.Hours, ticketentry.Quantity.Minutes , ticketentry.Quantity.Seconds) + "\n";

                buffer = buffer + "Subtotal " + "\x9" + "" + "\x9" + ticketentry.Amount.ToString("c").PadLeft(14) + "\n";
                buffer = buffer + "Tax " + "\x9" + "" + "\x9" + "" + ticketentry.SalesTax.ToString("c").PadLeft(14) + "\n";
                
                buffer = buffer + "------------------------------------------------ \n";
                buffer = buffer + "Total" + "\x6" + "" + "\x9   " + "\x1b\x69\x1\x1" + ticket.TotalSales.ToString("c").PadLeft(14) + "\n";    //Character Expansion - Pg. 3-10
                buffer = buffer + "\x1b\x69\x0\x0";                                                          //Cancel Expansion - Pg. 3-10
                buffer = buffer + "\nTender" + "\x6" + "\x6" + "\x9               " + ticket.TotalTender.ToString("c").PadLeft(14) + "\n";
                buffer = buffer + "Change" + "\x6" + "\x6" + "\x9               " + ticket.TotalChange.ToString("c").PadLeft(14) + "\n\n";
                buffer = PriceDetails(buffer, ticketentry.Item.Description);
                // buffer = buffer + "\x1b\x34" + "Refunds and Exchanges" + "\x1b\x35\n";                       //Specify/Cencel White/Black Invert - Pg. 3-16
                // buffer = buffer + "Within " + "\x1b\x2d\x1" + "30 days" + "\x1b\x2d\x0" + " with receipt\n"; //Specify/Cancel Underline Printing - Pg. 3-15
                //buffer = buffer + "And tags attached\n\n";
            }
            else
            {
                buffer = buffer + "Entry Time: " + ticketentry.StartDateTime.ToString("M/d/yyyy") + "\x1b\x69\x1\x1" + " " + ticketentry.StartDateTime.ToString("h:mm:ss tt") + "\x1b\x69\x0\x0" + "\n";
                buffer = PriceDetails(buffer, ticketentry.Item.Description);
               
            }
            buffer = buffer + "------------------------------------------------ \n\n";
            buffer = buffer + "\x1b\x1d\x61\x1";             //Center Alignment - Refer to Pg. 3-29
            buffer = buffer + "\x1b\x62\x6\x2\x2" + ticket.TransactionNumber + "\x1e\n";             //Barcode - Pg. 3-39 - 3-40
            buffer = buffer + "\x1b\x64\x02";                                            //Cut  - Pg. 3-41
            buffer = buffer + "\x7";                                                    //Open Cash Drawer
            
            if (PrinterName != null)
            {
                    // Send a printer-specific to the printer.
                    RawPrinterHelper.SendStringToPrinter(PrinterName, buffer);
            }
            else
            {
                // Allow the user to select a printer.
                PrintDialog pd = new PrintDialog();
                pd.PrinterSettings = new PrinterSettings();
                if (DialogResult.OK == pd.ShowDialog())
                {
                    // Send a printer-specific to the printer.
                    RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, buffer);
                }
            }
        }

        private static string PriceDetails(string buffer, string itemDescription)
        {
            buffer = buffer + "------------------------------------------------ \n";
            buffer = buffer + "\x1b\x45";                    //Select Emphasized Printing - Pg. 3-14
            buffer = buffer + "All Prices bleow include 15% VAT Tax \n";
            if(itemDescription == "Delivery")
                buffer = buffer + "First 15 mins. Free\n";
            buffer = buffer + " $3.45 for 1st Hour\n";
            buffer = buffer + " $2.30 for EVERY Hour After\n";
            buffer = buffer + "$23.00 for Lost Ticket\n";
            buffer = buffer + "\x1b\x46";                    //Cancel Emphasized Printing - Pg. 3-14
            return buffer;
        }

        public void PrintTicket(Transaction transaction, string PrinterName)
        {
            TransactionEntry transactionEntry = (TransactionEntry)transaction.TransactionEntry;


            string buffer = "\x1b\x1d\x61\x1";             //Center Alignment - Refer to Pg. 3-29
            //buffer = buffer + "\x5B" + "If loaded.. Logo1 goes here" + "\x5D\n";
            //buffer = buffer + "\x1B\x1C\x70\x1\x0";          //Stored Logo Printing - Refer to Pg. 3-38

            buffer = buffer + "\x1b\x69\x1\x1" + "Grenreal" + "\x1b\x69\x0\x0" + "\n";
            buffer = buffer + "Property Corperation Ltd\n";
            buffer = buffer + "Bruce Street, St. George's\n";
            buffer = buffer + "Tel: +1 473 435-8372, Fax: +1 473 435-8373 \n";
            buffer = buffer + "VAT#: 1601993 \n\n";
            buffer = buffer + "------------------------------------------------ \n";
            buffer = buffer + "\x1b\x62\x6\x2\x2" + transaction.TransactionNumber + "\x1e\n";             //Barcode - Pg. 3-39 - 3-40
            buffer = buffer + "\x1b\x1d\x61\x0";             //Left Alignment - Refer to Pg. 3-29
            buffer = buffer + "\x1b\x44\x2\x10\x22\x0";      //Setting Horizontal Tab - Pg. 3-27
            buffer = buffer + "\x1b\x45";                    //Select Emphasized Printing - Pg. 3-14
                                                             //  buffer = buffer + "Entry Time: " + TransactionDate.ToShortDateString() + "\x9" + " Time: " + TransactionDate.ToString("hh:mm") + "\n";      //Moving Horizontal Tab - Pg. 3-26
            buffer = buffer + "\x1b\x69\x1\x1" + transactionEntry.Item.ExtendedDescription + "\x1b\x69\x0\x0" + "\n";
            buffer = buffer + "------------------------------------------------ \n";

            //buffer = buffer + "\x1b\x45";                    //Select Emphasized Printing - Pg. 3-14
            buffer = buffer + "Cashier: " + "\x9  " + transaction.Cashier.Intitals + "\n";
            buffer = buffer + "Station: " + "\x9  " + transaction.Station.StationCode + "\n";
            if (transactionEntry.VehicleNumber != null) buffer = buffer + "Vehicle#: " + "\x9  " + transactionEntry.VehicleNumber + "\n";
            buffer = buffer + "\x1b\x46";                    //Cancel Emphasized Printing - Pg. 3-14

           
                buffer = buffer + "Transaction Time: " + "\x4  " + transaction.Time.ToString("M/d/yyyy h:mm:ss tt") + "\n";
                buffer = buffer + "Subtotal " + "\x9" + "" + "\x9" + transactionEntry.Amount.ToString("c").PadLeft(14) + "\n";
                buffer = buffer + "Tax " + "\x9" + "" + "\x9" + "" + transactionEntry.SalesTax.ToString("c").PadLeft(14) + "\n";

                buffer = buffer + "------------------------------------------------ \n";
                buffer = buffer + "Total" + "\x6" + "" + "\x9   " + "\x1b\x69\x1\x1" + transaction.TotalSales.ToString("c").PadLeft(14) + "\n";    //Character Expansion - Pg. 3-10
                buffer = buffer + "\x1b\x69\x0\x0";                                                          //Cancel Expansion - Pg. 3-10
                buffer = buffer + "\nTender" + "\x6" + "\x6" + "\x9               " + transaction.TotalTender.ToString("c").PadLeft(14) + "\n";
                buffer = buffer + "Change" + "\x6" + "\x6" + "\x9               " + transaction.TotalChange.ToString("c").PadLeft(14) + "\n\n";
                buffer = PriceDetails(buffer, transactionEntry.Item.Description);
             
            buffer = buffer + "------------------------------------------------ \n\n";
            buffer = buffer + "\x1b\x1d\x61\x1";             //Center Alignment - Refer to Pg. 3-29
            buffer = buffer + "\x1b\x62\x6\x2\x2" + transaction.TransactionNumber + "\x1e\n";             //Barcode - Pg. 3-39 - 3-40
            buffer = buffer + "\x1b\x64\x02";                                            //Cut  - Pg. 3-41
            buffer = buffer + "\x7";                                                    //Open Cash Drawer

            if (PrinterName != null)
            {
                // Send a printer-specific to the printer.
                RawPrinterHelper.SendStringToPrinter(PrinterName, buffer);
            }
            else
            {
                // Allow the user to select a printer.
                PrintDialog pd = new PrintDialog();
                pd.PrinterSettings = new PrinterSettings();
                if (DialogResult.OK == pd.ShowDialog())
                {
                    // Send a printer-specific to the printer.
                    RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, buffer);
                }
            }
        }

    }
}
