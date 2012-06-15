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
    public partial class selectform : Form
    {
        public string name;   //电影名
        public int selectHid = 1;   //此界面内选定的影厅ID，默认为1
        public int selectSid = 1;   //此界面内选定的座位ID，默认为1
        public string selectstarttime;  //此界面内选定的开场时间
        public int sellerid;  //系统此时的售票员编号

        public selectform()
        {
            InitializeComponent();
        }
        public selectform(string na,int id)
        {
            InitializeComponent();
            label3.Text = na;
            name = na;
            sellerid = id;
        }

        DYDP.Data.DYDP mydydp = new DYDP.Data.DYDP();
        string date = System.DateTime.Now.ToString("yyyy-MM-dd");
        
        private void selectform_Load(object sender, EventArgs e)
        {           
            treeView1.BeginUpdate();
            treeView1.Nodes.Clear();

            string starttime = null;
            TreeNode timeNode = null;
            int hid = 0;
            foreach (schedule s in mydydp.GetMovieTimeOneday(date,label3.Text))
            {
                if (starttime != s.starttime)  //界面初始化时间树
                {
                    timeNode = new TreeNode(s.starttime);
                    treeView1.Nodes.Add(timeNode);
                }
                starttime = s.starttime;

                if (hid != s.hallid)    //界面初始化影厅选项
                    comboBox1.Items.Add(s.hallid);
                hid = s.hallid;

            }
            foreach (seatinfo seat in mydydp.GetSeatByhallid(selectHid))
            {
                if (seat.available == true)
                    comboBox2.Items.Add(seat.seatid);
            }
            treeView1.EndUpdate();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s = comboBox1.SelectedItem.ToString();
            selectHid = Int32.Parse(s);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s = comboBox2.SelectedItem.ToString();
            selectSid = Int32.Parse(s);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            seatinfo seat = mydydp.GetSeatBy(selectHid, selectSid);
            seat.available = false;
            mydydp.UpdateSeat(seat);
            ticketform tform = new ticketform(name, selectHid, selectSid, selectstarttime,sellerid);
            tform.Show();
            this.Close();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = treeView1.SelectedNode;
            if (node == null) return;
            selectstarttime = node.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (schedule s in mydydp.GetMovieTimeOneday(date, label3.Text))
            {
                int h = s.hallid;
                foreach (seatinfo seat in mydydp.GetSeatByhallid(h))
                {
                    if (seat.available == false)
                    {
                        seat.available = true;
                        mydydp.UpdateSeat(seat);
                    }
                }
            }
            this.Close();
            selectform sele =new selectform(name,sellerid);
            sele.Show();
        }
    }
}
