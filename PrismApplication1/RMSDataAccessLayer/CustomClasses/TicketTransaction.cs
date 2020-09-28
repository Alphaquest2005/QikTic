using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RMSDataAccessLayer
{
    public partial class Ticket
    {
        public Ticket()
        {
           
            
        }

        public bool OpenClose { get { return ((TicketEntry)this.TransactionEntry).EndDateTime is null; } }
    }
}
