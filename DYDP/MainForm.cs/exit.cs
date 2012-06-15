using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MainForm.cs
{
    public partial class exit : Form
    {
        public exit()
        {
            InitializeComponent();
        }

        public exit(int id)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.id = id;
        }
        DYDP.Data.DYDP mydydp = new DYDP.Data.DYDP();
        private int id;

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void exit_Load(object sender, EventArgs e)
        {
            label3.Text = mydydp.GetTicketBySeller(id).Count.ToString();
        }
    }
}
