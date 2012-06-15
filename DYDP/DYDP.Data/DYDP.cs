using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using DYDP.Domain.Entities;
using NHibernate.Criterion;

namespace DYDP.Data
{
    public class DYDP
    {
        protected ISession Session;
        public DYDP()
        {
            // TODO: Complete member initialization          
            Session = NHibernateHelper.GetSession();
        }

        public DYDP(ISession session)
        {
            Session = session;
        } 
     
        public void CreateTicket(ticketinfo ticket)   //产生电影票
        {
            Session.Save(ticket);
            Session.Flush();
        }

        public void UpdateSeat(seatinfo seat)
        {
            Session.Update(seat);
            Session.Flush();
        }

        public seatinfo GetSeatBy(int h, int s)
        {
            IList<seatinfo> seats = Session.CreateCriteria(typeof(seatinfo))
                .Add(Restrictions.Like("hallid", h))
                .Add(Restrictions.Like("seatid", s)).List<seatinfo>();
            return seats[0];
        }

        public ticketinfo GetTicketById(int ticketid)   //由票号获取票的内容
        {
            return Session.Get<ticketinfo>(ticketid);
        }

        public userinfo GetUserById(string userid)   //由工号获取员工信息
        {
            return Session.Get<userinfo>(userid);
        }

        public IList<schedule> GetScheduleByDate(string date)  //由放映日期获取单项日程内容
        {
            IList<schedule> schedules = Session.CreateCriteria(typeof(schedule))
                .Add(Restrictions.Like("date", date)).List<schedule>();
            return schedules;
        }

        public movieinfo GetMovieByName(string moviename)  //由电影名得电影内容
        {
            return Session.Get<movieinfo>(moviename);
        }

        public IList<movieinfo> GetTodaymovieBydate(string date)   //由日期得该日期放映的电影信息
        {
            IList<schedule> todayschedules = GetScheduleByDate(date);
            int size = todayschedules.Count;
            string[] moviename = new string[size];
            int i = 0;
            foreach (var c in todayschedules)
            {
                moviename[i] = c.moviename;
                i++;
            }
            IList<movieinfo> movies;
            movieinfo m;
            movies = new List<movieinfo>();
            for (int j = 0; j < moviename.Length; j++)
            {
                if (moviename[j] != null)
                {
                    m = Session.Get<movieinfo>(moviename[j]);
                    movies.Insert(j, m);
                }
            }
            return movies;
        }

        public IList<schedule> GetMovieTimeOneday(string date, string moviename)  //由时间和日期得到日程表
        {
            IList<schedule> sch = GetScheduleByDate(date);
            sch = Session.CreateCriteria(typeof(schedule))
                .Add(Restrictions.Like("moviename", moviename)).List<schedule>();
            return sch;
        }

        public IList<seatinfo> GetSeatByhallid(int hallid)  //由影厅号得到该影厅的座位号
        {
            IList<seatinfo> seats = Session.CreateCriteria(typeof(seatinfo))
                .Add(Restrictions.Like("hallid", hallid)).List<seatinfo>();
            return seats;
        }

        public IList<ticketinfo> GetTicketBySeller(int sellerid)  //由售票员得出电影票以求出个人售票情况
        {
            IList<ticketinfo> tickets = Session.CreateCriteria(typeof(ticketinfo))
                .Add(Restrictions.Like("seller", sellerid)).List<ticketinfo>();
            return tickets;
        }

    }
}
