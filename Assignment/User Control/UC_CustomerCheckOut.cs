using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment.User_Control
{
    public partial class UC_CustomerCheckOut : UserControl
    {
        function fn = new function();
        String query;
        public UC_CustomerCheckOut()
        {
            InitializeComponent();
        }

        private void UC_CustomerCheckOut_Load(object sender, EventArgs e)
        {
            query = "SELECT customer.cid,customer.cname,customer.mobile,customer.nationality,customer.gender,customer.dob,customer.idproof,customer.address,customer.checkin,rooms.roomNo,rooms.bed,rooms.price FROM customer INNER JOIN rooms ON customer.roomid=rooms.roomid WHERE chekout='NO'";
            DataSet ds=fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        private void txtname_TextChanged(object sender, EventArgs e)
        {
            query = "SELECT customer.cid,customer.cname,customer.mobile,customer.nationality,customer.gender,customer.dob,customer.idproof,customer.address,customer.checkin,rooms.roomNo,rooms.roomType,rooms.bed,rooms.price FROM customer INNER JOIN rooms ON customer.roomid=rooms.roomid WHERE cname LIKE '"+txtname.Text+"%' AND chekout='NO'";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }
        int id;
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                id = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtCName.Text = guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtRoomNo.Text= guna2DataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            }
        }
        public void ClearAll()
        {
            txtCName.Clear();
            txtname.Clear();
            txtRoomNo.Clear();
            txtcheckin.ResetText();
        }
        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (txtCName.Text != "")
            {
                if (MessageBox.Show("Are You Sure?", "Confiramation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    String cdate = txtcheckin.Text;
                    query = "UPDATE customer SET chekout='YES',checkout='" + cdate + "' WHERE cid=" + id + "";
                    String query2 = "UPDATE rooms SET booked='NO' WHERE roomNo='" + txtRoomNo.Text + "'";
                    fn.SetData(query, "Check Out Succesfully.");
                    fn.SetData(query2, "Check Out Succesfully.");
                    UC_CustomerCheckOut_Load(this, null);
                    ClearAll();
                }
            }
            else
            {
                MessageBox.Show("No Customer Selected.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
        }

        private void UC_CustomerCheckOut_Leave(object sender, EventArgs e)
        {
            ClearAll();
        }
    }
}
