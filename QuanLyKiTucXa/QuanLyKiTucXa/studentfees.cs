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
    public partial class studentfees : Form
    {
        function fn = new function();
        String query;
        public studentfees()
        {
            InitializeComponent();
        }

        private void txtExist_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void studentfees_Load(object sender, EventArgs e)
        {
            this.Location = new Point(472, 131);
            DateTimePicker.Format= DateTimePickerFormat.Custom;
            DateTimePicker.CustomFormat = "MMMM yyyy";
        }
        public void setDataGrid(Int64 mobile)
        {
            query = "SELECT*FROM fees WHERE mobileNo=" + mobile + "";
            DataSet ds = fn.getData(query);
            dataGridView1.DataSource=ds.Tables[0];
        }
        private void clearAll()
        {
            txtSDT.Clear();
            txtName.Clear();
            txtEmail.Clear();
            txtRoomNo.Clear();
            txtAmount.Clear();
            dataGridView1.DataSource = 0;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(txtSDT.Text != "")
            {
                query = "SELECT name,email,roomNo from newStudent WHERE mobile=" + txtSDT.Text + "";
                DataSet ds = fn.getData(query);
                if(ds.Tables[0].Rows.Count != 0)
                {
                    txtName.Text = ds.Tables[0].Rows[0][0].ToString();
                    txtEmail.Text = ds.Tables[0].Rows[0][1].ToString();
                    txtRoomNo.Text = ds.Tables[0].Rows[0][2].ToString();
                    setDataGrid(Int64.Parse(txtSDT.Text));

                }
                else
                {
                    MessageBox.Show("Không Tồn Tại.","Thông Tin",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            query = "SELECT * FROM fees WHERE mobileNo=" + Int64.Parse(txtSDT.Text) + "and fmonth='" + DateTimePicker.Text + "'";
            DataSet ds=fn.getData(query);
            if(ds.Tables[0].Rows.Count == 0)
            {
                Int64 mobile=Int64.Parse(txtSDT.Text);
                String month = DateTimePicker.Text;
                Int64 amount=Int64.Parse(txtAmount.Text);
                query = "insert into fees values(" + mobile + ",'" + month + "'," + amount + ")";
                fn.setData(query, "Phí Đã Trả");
                clearAll();
            }
            else
            {
                MessageBox.Show("Không có lệ phí của" + DateTimePicker.Text + "Còn lại.", "Thông Tin", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearAll();
        }
    }
}
