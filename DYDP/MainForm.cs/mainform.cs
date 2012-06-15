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
    public partial class mainform : Form
    {
        public mainform()
        {
            InitializeComponent();
        }

        public mainform(int id)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.id = id;
        }

        DYDP.Data.DYDP mydydp = new DYDP.Data.DYDP();
        string selectname;
        private int id;

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            treeView1.BeginUpdate();
            treeView1.Nodes.Clear();

            string date = System.DateTime.Now.ToString("yyyy-MM-dd");

            string movieName = null;
            TreeNode movieNode = null;
            foreach (movieinfo m in mydydp.GetTodaymovieBydate(date))
            {
                if (movieName != m.moviename)
                {
                    movieNode = new TreeNode(m.moviename);
                    treeView1.Nodes.Add(movieNode);                   
                }
                movieName = m.moviename;
            }
            treeView1.EndUpdate();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = treeView1.SelectedNode;
            if (node == null) return;
            string key = node.Text;
            movieinfo movie = mydydp.GetMovieByName(key);
            this.label2.Text = movie.moviename;
            this.label4.Text = movie.director;
            this.label6.Text = movie.actor;
            this.label8.Text = movie.movietime.ToString();
            this.label12.Text = movie.description;
            this.label10.Text = movie.price.ToString();
            this.pictureBox1.Image = Image.FromFile(movie.poster);
            selectname = node.Text;
        }

        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            selectform selectfo = new selectform(selectname,id);
            selectfo.Show();
        }

        private void ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            exit ex = new exit(id);
            ex.ShowDialog();
        }
    }
}
