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
    public partial class Allstudent : Form
    {
        function fn = new function();
        String query;
        public Allstudent()
        {
            InitializeComponent();
        }

        private void btnExist_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Allstudent_Load(object sender, EventArgs e)
        {
            this.Location = new Point(472, 131);
            query = "SELECT*FROM newStudent WHERE living='Yes'";
            DataSet ds = fn. getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
          
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
