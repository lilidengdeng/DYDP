using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DYDP.Domain.Entities;

namespace DYDP.Data.Test
{
    [TestClass]
    public class DYDPFixture
    {
        public DYDP mydydp;

        [TestMethod]
        public void TestFixtureSetup()
        {
            mydydp = new DYDP();
        }

        [TestMethod]
        public void ComparePassword()
        {
            mydydp = new DYDP();
            userinfo user1 = mydydp.GetUserById("1");
            string id = user1.password;
            Assert.AreEqual("12345", id);
        }

        [TestMethod]
        public void GetScheduleBydate()
        {
            mydydp = new DYDP();
            string s = "2012-06-15";
            IList<schedule> schedules = mydydp.GetScheduleByDate(s);
            Assert.AreEqual(2, schedules.Count);
            s = "10:00";
            foreach (var c in schedules)
            {
                Assert.AreEqual(s, c.starttime);
            }
        }

        [TestMethod]
        public void GetmovieByname()
        {
            mydydp = new DYDP();
            string s = "初恋这件小事";
            movieinfo movie = mydydp.GetMovieByName(s);
            Assert.AreEqual(75, movie.price);
        }

        [TestMethod]
        public void TestGetmoviebydate()
        {
            mydydp = new DYDP();
            string s = "2012-06-15";
            movieinfo movie = mydydp.GetTodaymovieBydate(s).ElementAt(0);
            Assert.AreEqual("初恋这件小事", movie.moviename);
        }

        [TestMethod]
        public void TestGetmovieByNamedate()
        {
            mydydp = new DYDP();
            IList<schedule> sch = mydydp.GetMovieTimeOneday("2012-06-14", "初恋这件小事");
            Assert.AreEqual("10:00", sch[0].starttime);
        }

        [TestMethod]
        public void TestGetSizeofHall()
        {
            mydydp = new DYDP();
            IList<seatinfo> seats = mydydp.GetSeatByhallid(1);
            Assert.AreEqual(10, seats.Count);
        }

        [TestMethod]
        public void createticket()
        {
            DYDP mydydp = new DYDP();
            var ticket = new ticketinfo { ticketid =2, moviename = "黑衣人3", starttime = "11:30", seatid = 8, hallid = 2, movietime = 117, price = 70, seller = 1 };
            mydydp.CreateTicket(ticket);
            ticketinfo tic = mydydp.GetTicketById(2);
            int Id = tic.ticketid;
            Assert.AreEqual(2, Id);
        }

        [TestMethod]
        public void updateseat()
        {
            DYDP mydydp = new DYDP();
            seatinfo seat = mydydp.GetSeatBy(1, 2);
            seat.available = false;
            mydydp.UpdateSeat(seat);
            seatinfo se = mydydp.GetSeatBy(1, 2);
            Assert.AreEqual(false, se.available);
        }
    }
}
