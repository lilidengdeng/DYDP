using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DYDP.Data;
using DYDP.Domain.Entities;

namespace MainForm.cs
{
    public partial class login : Form
    {
        public int USERID;

        public login()
        {
            InitializeComponent();
        }

        DYDP.Data.DYDP mydydp = new DYDP.Data.DYDP();

        private void button1_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text.ToString();
            userinfo user1 = mydydp.GetUserById(id);
            if (user1 != null)
            {
                string pass = maskedTextBox1.Text.ToString();
                if (pass == user1.password)
                {
                    MessageBox.Show("登录成功！");
                    this.Hide();
                    DialogResult = DialogResult.OK;
                    USERID = Int32.Parse(textBox1.Text.ToString());

                }
                else
                    MessageBox.Show("密码错误，请核实！");
            }
            else
                MessageBox.Show("系统内无此员工号，请核实！");        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
