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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void btnExist_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Form1 fn = new Form1();
            fn.Show();
            this.Close();
        }

        private void btnManagerRoom_Click(object sender, EventArgs e)
        {
            AddNewRoom anr = new AddNewRoom();
            anr.Show();
        }

        private void btnNewStudent_Click(object sender, EventArgs e)
        {
            NewStudent nst=new NewStudent();
            nst.Show();
        }

        private void btnUpdateDelete_Click(object sender, EventArgs e)
        {
            UpdateDelete up=new UpdateDelete();
            up.Show();
        }

        private void btnStudentFees_Click(object sender, EventArgs e)
        {
            studentfees fee=new studentfees();
            fee.Show();
        }

        private void btnAllStudent_Click(object sender, EventArgs e)
        {
            Allstudent all=new Allstudent();
            all.Show();
        }

        private void btnLeaveStudent_Click(object sender, EventArgs e)
        {
            leaverStudent lea=new leaverStudent();
            lea.Show();
        }
    }
}
