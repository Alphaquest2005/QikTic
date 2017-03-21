using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RMSDataAccessLayer;

namespace QicTic_Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void FirstMinuteinFirstHour()
        {
            var ticket = new TicketEntry()
            {
                StartDateTime = DateTime.Parse("1/1/2010 1:00 pm"),
                EndDateTime = DateTime.Parse("1/1/2010 1:00:20 pm"),
                Item = new TicketItem() { Price1 = 3.45, Price2 = 2.70, TicketSetup = new TicketSetup() { FreeMinutes = 1 } },
            };
            Assert.AreEqual(0,ticket.Amount);
        }

        [TestMethod]
        public void TwoMinutesinFirstHour()
        {
            var ticket = new TicketEntry()
            {
                StartDateTime = DateTime.Parse("1/1/2010 1:00 pm"),
                EndDateTime = DateTime.Parse("1/1/2010 1:02 pm"),
                Item = new TicketItem() { Price1 = 3.45, Price2 = 2.70, TicketSetup = new TicketSetup() { FreeMinutes = 1 } },
            };
            Assert.AreEqual(3.45, ticket.Amount);
        }

        [TestMethod]
        public void OneMinutesinSecondHour()
        {
            var ticket = new TicketEntry()
            {
                StartDateTime = DateTime.Parse("1/1/2010 1:00 pm"),
                EndDateTime = DateTime.Parse("1/1/2010 2:00:20 pm"),
                
                Item = new TicketItem() { Price1 = 3.45, Price2 = 2.30, TicketSetup = new TicketSetup() { FreeMinutes = 1 } },
            };
            var diff = ticket.Quantity.TotalMinutes;
            Assert.AreEqual(3.45, ticket.Amount);
        }

        [TestMethod]
        public void TwoMinutesinSecondHour()
        {
            var ticket = new TicketEntry()
            {
                StartDateTime = DateTime.Parse("1/1/2010 1:00 pm"),
                EndDateTime = DateTime.Parse("1/1/2010 2:02 pm"),
                Item = new TicketItem() { Price1 = 3.45, Price2 = 2.30, TicketSetup = new TicketSetup() { FreeMinutes = 1 } },
            };
            Assert.AreEqual(5.75, ticket.Amount);
        }

        [TestMethod]
        public void OneMinutesinThirdHour()
        {
            var ticket = new TicketEntry()
            {
                StartDateTime = DateTime.Parse("1/1/2010 1:00 pm"),
                EndDateTime = DateTime.Parse("1/1/2010 3:00:20 pm"),
                Item = new TicketItem() { Price1 = 3.45, Price2 = 2.30, TicketSetup = new TicketSetup() { FreeMinutes = 1 } },
            };
            var diff = ticket.Quantity.TotalMinutes;
            Assert.AreEqual(5.75, ticket.Amount);
        }


    }
}
