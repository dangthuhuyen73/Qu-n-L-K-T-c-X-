using System;
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
    public partial class leaverStudent : Form
    {
        function fn = new function();
        String query;
        public leaverStudent()
        {
            InitializeComponent();
        }

        private void btnExist_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void leaverStudent_Load(object sender, EventArgs e)
        {
            this.Location = new Point(472, 131);
            query = "SELECT*FROM newStudent WHERE living='No'";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }
    }
}
