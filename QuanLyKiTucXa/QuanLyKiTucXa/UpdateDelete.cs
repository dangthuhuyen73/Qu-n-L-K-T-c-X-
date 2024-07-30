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
    public partial class UpdateDelete : Form
    {
        function fn = new function();
        String query;
        public UpdateDelete()
        {
            InitializeComponent();
        }

        private void txtExist_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateDelete_Load(object sender, EventArgs e)
        {
            this.Location = new Point(472, 131);
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
            txtRoomNo.Clear();
            ComboBoxLiving.SelectedIndex = -1;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            query = "SELECT *FROM newStudent WHERE mobile=" + txtSDT.Text + "";
            DataSet ds = fn.getData(query);
            if(ds.Tables[0].Rows.Count != 0)
            {
                txtName.Text = ds.Tables[0].Rows[0][2].ToString();
                txtFather.Text = ds.Tables[0].Rows[0][3].ToString();
                txtMother.Text = ds.Tables[0].Rows[0][4].ToString();
                txtEmail.Text = ds.Tables[0].Rows[0][5].ToString();
                txtDiachi.Text = ds.Tables[0].Rows[0][6].ToString();
                txtDaihoc.Text = ds.Tables[0].Rows[0][7].ToString();
                txtCCCD.Text = ds.Tables[0].Rows[0][8].ToString();
                txtRoomNo.Text = ds.Tables[0].Rows[0][9].ToString();
                ComboBoxLiving.Text = ds.Tables[0].Rows[0][10].ToString();
            }
            else
            {
                clearAll();
                MessageBox.Show("Số Điện Thoại Không Tồn Tại!","Thông Tin",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Int64 DT = Int64.Parse(txtSDT.Text);
            String ten = txtName.Text;
            String fa = txtFather.Text;
            String mom = txtMother.Text;
            String id = txtEmail.Text;
            String add = txtDiachi.Text;
            String School = txtDaihoc.Text;
            String cccd = txtCCCD.Text;
            Int64 RoomNo = Int64.Parse(txtRoomNo.Text);
            String living = ComboBoxLiving.Text;
            query = "update newStudent set name='" + ten + "', fname= '" + fa + "', mname= '" + mom + "', email= '" + id + "', paddress= '" + add + "', college= '" + School + "', idproof= '" + cccd + "', roomNo= '" + RoomNo + "', living= '" + living + "'where mobile= " + DT + "update rooms set Booked = '" + living + "'where roomNo = " + RoomNo + "";
            fn.setData(query, "Cập Nhập Dữ Liệu Thành Công!");
            fn.setData(query, "Sinh Viên Đăng Ký Thành Công.");
            clearAll();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn Chắc Chắn Xóa Không?","Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                query = "DELETE FROM newStudent WHERE mobile= " + txtSDT.Text + "";
                fn.setData(query, "Đã Xóa Thành Công");
                clearAll();
            }
        }
    }
}
