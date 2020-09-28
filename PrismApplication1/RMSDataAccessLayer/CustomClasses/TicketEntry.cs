using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Threading;


namespace RMSDataAccessLayer
{
    public partial class TicketEntry: ISearchItem
    {
      
        public string Status
        {
            get
            {
                if (EndDateTime == null)
                {
                    return "Open";
                }
                else
                {
                    return "Closed";
                }
            }
           
        }

        public override double Amount
        {
            get
            {
                if (Item == null) throw new Exception("Inventory Item Not Loaded");

                
                TicketItem  ticitm = ((TicketItem)Item);

                if (ticitm.TicketSetupReference.IsLoaded == false && ticitm.TicketSetup == null) throw new Exception("TicketSetup Not Loaded");

                if (Item != null && ticitm.TicketSetup != null && Quantity.TotalMinutes <= ticitm.TicketSetup.FreeMinutes)
                {
                    if (Price != ticitm.Price1)
                    Price = ticitm.Price1;
                    
                    return 0;
                }

                if (Price != ticitm.Price2)
                        Price = ticitm.Price2;

                double hours;
                var firstHour = 1;
                var oneHour = 1;
                if (Quantity.TotalMinutes%60 <= ticitm.TicketSetup.FreeMinutes)
                {
                    hours = Math.Ceiling(Quantity.TotalHours) - firstHour - oneHour ;
                    if (hours < 0) hours = 0;
                }
                else
                {
                    hours = Math.Ceiling(Quantity.TotalHours) - firstHour;
                }
                
                return ((ticitm.Price1) + ((ticitm.Price2) * ((hours)))) - Discount.GetValueOrDefault();
                

            }
        }




        public new TimeSpan Quantity
        {
            get
            {
                if (EndDateTime == null || EndDateTime < StartDateTime)
                {
                    return ( DateTime.Now - StartDateTime);
                }
                else
                {
                    return ((DateTime)EndDateTime - StartDateTime); 
                }
            }
            
            

        }
        public string SearchCriteria
        {
            get { return TransactionId.ToString(); }
            set
            {
            }
        }

        public string DisplayName
        {
            get { throw new NotImplementedException(); }
        }

        public string Key
        {
            get { throw new NotImplementedException(); }
        }
    }
}
