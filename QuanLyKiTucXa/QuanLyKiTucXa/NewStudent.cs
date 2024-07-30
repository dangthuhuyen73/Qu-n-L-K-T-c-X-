using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;

namespace QuanLyKiTucXa
{
    public partial class NewStudent : Form
    {
        function fn = new function();
        String query;
        public NewStudent()
        {
            InitializeComponent();
        }

        private void NewStudent_Load(object sender, EventArgs e)
        {
            this.Location = new Point(472, 131);
            query = "SELECT roomNo from rooms WHERE roomStatus='Yes' AND Booked='No'";
            DataSet ds = fn.getData(query);
            for(int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Int64 room = Int64.Parse(ds.Tables[0].Rows[i][0].ToString());
                ComboRoomNo.Items.Add(room);
            }
        }

        private void btnExist_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void clearAll()
        {
            txtSDT.Clear();
            txtName.Clear();
            txtFather.Clear();
            txtMother.Clear();
            txtEmail.Clear();
            txtDiachi.Clear();
            txtDaihoc.Clear();
            txtCCCD.Clear();
            ComboRoomNo.SelectedIndex = -1;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
         if(txtSDT.Text != "" && txtName.Text != "" && txtFather.Text != ""&& txtMother.Text!=""&& txtEmail.Text!=""&& txtDiachi.Text!=""&& txtDaihoc.Text!="" && txtCCCD.Text!=""&& ComboRoomNo.SelectedIndex != -1)
            {
               Int64 DT=Int64.Parse(txtSDT.Text);
                String ten = txtName.Text;
                String fa=txtFather.Text;
                String mom=txtMother.Text;
                String id = txtEmail.Text;
                String add=txtDiachi.Text;
                String School=txtDaihoc.Text;
                String cccd=txtCCCD.Text;
                Int64 roomNo = Int64.Parse(ComboRoomNo.Text);
                query = "insert into newStudent(mobile,name,fname,mname,email,paddress,college,idproof,roomNo) values (" + DT + ",'" + ten + "','" + fa + "','" + mom + "','" + id + "','" + add + "','" + School + "','" + cccd + "'," + roomNo + ") update rooms set Booked = 'Yes' where roomNo = " + roomNo + "";
                fn.setData(query, "Sinh Viên Đăng Ký Thành Công.");
                clearAll();
            }
            else
            {
                MessageBox.Show("Vui Lòng Nhập Đầy Đủ!","Thông Tin",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearAll();
        }
    }
}
