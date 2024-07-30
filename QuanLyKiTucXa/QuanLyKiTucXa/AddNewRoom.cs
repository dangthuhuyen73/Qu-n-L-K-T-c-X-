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
    public partial class AddNewRoom : Form
    {
        function fn = new function();
        string query;
        public AddNewRoom()
        {
            InitializeComponent();
        }

        private void btnExist_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddNewRoom_Load(object sender, EventArgs e)
        {
            this.Location = new Point(472,131);
            labelRoom.Visible=false;
            labelRoomExist.Visible=false;
            query = "SELECT*FROM rooms";
            DataSet ds = fn.getData(query);
            dataGridView1.DataSource=ds.Tables[0];
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            query = "SELECT*FROM rooms WHERE roomNo=" + txtRoomNo1.Text + "";
            DataSet ds = fn.getData(query);
            if(ds.Tables[0].Rows.Count == 0)
            {
                string status;
                if(checkBox.Checked)
                {
                    status = "Yes";
                }
                else
                {
                    status = "No";
                }
                labelRoomExist.Visible = false;
                query = "insert into rooms(roomNo,roomStatus)values(" + txtRoomNo1.Text + ",'" + status + "')";
                fn.setData(query, "ĐÃ Thêm Phòng.");
                AddNewRoom_Load(this, null);
            }
            else
            {
                labelRoomExist.Text = "Phòng Đã Có";
                labelRoomExist.Visible = true;
            }
        }
        //tìm kiếm
        private void btnSearch_Click(object sender, EventArgs e)
        {
            query = "SELECT*FROM rooms WHERE roomNo=" + txtRoomNo2.Text + "";
            DataSet ds = fn.getData(query);
            if(ds.Tables[0].Rows.Count == 0)
            {
                labelRoom.Text = "Phòng Này Không Tồn Tại";
                labelRoom.Visible = true;
                checkBox1.Checked = false;
            }
            else
            {
                labelRoom.Text = "Phòng Này Đã Tìm Thấy";
                labelRoom.Visible = true;
                if (ds.Tables[0].Rows[0][1].ToString() == "Yes")
                {
                    checkBox1.Checked = true;
                }
                else
                {
                    checkBox1.Visible = false;
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string status;
            if(checkBox1.Checked)
            {
                status = "Yes";
            }
            else
            {
                status = "No";
            }
            query = "update rooms set roomStatus='" + status + "'where roomNo=" + txtRoomNo2.Text + "";
            fn.setData(query, "Cập Nhập Chi Tiết Thành Công!");
            AddNewRoom_Load(this, null);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(labelRoom.Text=="Phòng Này Đã Tìm Thấy")
            {
                query = "delete from rooms where roomNo=" + txtRoomNo2.Text + "";
                fn.setData(query, "Đã xóa chi tiết phòng!");
                AddNewRoom_Load(this, null);
            }
            else
            {
                MessageBox.Show("Xóa lại Không Tìm Thấy Phòng!","Lỗi",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
