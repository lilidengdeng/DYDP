using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DYDP.Domain.Entities;

namespace MainForm.cs
{
    public partial class ticketform : Form
    {
        public ticketform()
        {
            InitializeComponent();
        }

        DYDP.Data.DYDP mydydp = new DYDP.Data.DYDP();
        public ticketform(string name, int selectHid, int selectSid, string selectstarttime,int sellerid)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.label10.Text = name;
            this.label11.Text = selectHid.ToString();
            this.label12.Text = selectSid.ToString();
            this.label13.Text = selectstarttime;
            this.label16.Text = sellerid.ToString();
        }

        private void ticketform_Load(object sender, EventArgs e)
        {
            movieinfo movie = mydydp.GetMovieByName(label10.Text.ToString());
            this.label14.Text = movie.movietime.ToString();
            this.label15.Text = movie.price.ToString();
            this.label9.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = label10.Text.ToString();
            int hallid = Int32.Parse(label11.Text);
            int seatid = Int32.Parse(label12.Text);
            string starttime = label13.Text.ToString();
            int movietime = Int32.Parse(label14.Text);
            int price = Int32.Parse(label15.Text);
            int sellerid = Int32.Parse(label16.Text);
            ticketinfo ticket = new ticketinfo { moviename =name, hallid=hallid,seatid=seatid,starttime=starttime, movietime =movietime,price=price,seller=sellerid};
            mydydp.CreateTicket(ticket);
            MessageBox.Show("订票成功！");
            this.Close();
            selectform selectfo = new selectform(name,sellerid);
            selectfo.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
