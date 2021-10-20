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
    public partial class UC_Employee : UserControl
    {
        function fc = new function();
        String query;
        public UC_Employee()
        {
            InitializeComponent();
        }
        public void getMaxId()
        {
            query = "SELECT MAX(eid) FROM employee";
            DataSet ds = fc.getData(query);
            if (ds.Tables[0].Rows[0][0].ToString() != "")
            {
                Int64 num = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
                lblToSet.Text = (num + 1).ToString();
            }
        }
        private void UC_Employee_Load(object sender, EventArgs e)
        {
            getMaxId();
        }
        public void ClearAll()
        {
            txtContact.Clear();
            txtEmailId.Clear();
            txtname.Clear();
            txtPassword.Clear();
            txtUserName.Clear();
            txtDelId.Clear();
            cmdgender.SelectedIndex = -1;
        }
        private void btnRegiter_Click(object sender, EventArgs e)
        {
            if(txtname.Text!="" && txtContact.Text!="" && cmdgender.Text!="" && txtEmailId.Text!="" && txtUserName.Text!="" && txtPassword.Text != "")
            {
                String name = txtname.Text;
                Int64 mobile = Int64.Parse(txtContact.Text);
                String gender = cmdgender.Text;
                String email = txtEmailId.Text;
                String username = txtUserName.Text;
                String pass = txtPassword.Text;
                query = "INSERT INTO employee(ename,mobile,gender,emailid,username,pass)VALUES('"+name+"','"+mobile+"','"+gender+"','"+email+"','"+username+"','"+pass+"')";
                fc.getData(query);
                MessageBox.Show("Registered!");
                ClearAll();
                getMaxId();
            }
            else
            {
                MessageBox.Show("Fill all Fields.", "Warning.....!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void setEmployee(DataGridView dgv)
        {
            query = "SELECT * FROM employee";
            DataSet ds = fc.getData(query);
           dgv.DataSource = ds.Tables[0];
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                setEmployee(guna2DataGridView1);
            }else if (tabControl1.SelectedIndex == 2)
            {
                setEmployee(guna2DataGridView2);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtDelId.Text != "")
            {
                if(MessageBox.Show("Are You Sure?", "Confirmation...!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    query = "DELETE FROM employee WHERE eid='" + txtDelId.Text + "'";
                    fc.getData(query);
                    MessageBox.Show("Delete Recored");
                    tabControl1_SelectedIndexChanged(this, null);
                }
                
            }
            
        }

        private void UC_Employee_Leave(object sender, EventArgs e)
        {
            ClearAll();
        }
    }
}
