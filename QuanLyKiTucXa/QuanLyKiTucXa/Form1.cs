﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKiTucXa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bnnlogin_Click(object sender, EventArgs e)
        {
            if(txtname.Text=="Dang Thu Huyen"&& txtpass.Text=="0703")
            {
                Dashboard dbs=new Dashboard();
                dbs.Show();
                this.Hide();
            }
        }
    }
}
